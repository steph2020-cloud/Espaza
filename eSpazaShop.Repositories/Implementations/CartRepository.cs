using eSpazaShop.Entities;
using eSpazaShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSpazaShop.Repositories.Implementations
{
    //Specific Item inside the cart 
    //class requires that you pass the db to the child because of inheritance from a concrete class
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext AppDbContext
        {
            get
            {
                //_dbContext is the parent class thats why the casting is possible to access the types inside the child
                return _dbContext as AppDbContext;
            }
        }

        public CartRepository(DbContext db)
           : base(db)
        {

        }
        public Cart GetCart(Guid _cartId)
        {
            //eager loading of the entity using Linq
            //maps to public virtual List<CartItem> Items { get; private set; }
            return AppDbContext.Carts.Include("Items").Where(c =>c.Id == _cartId && c.IsActive ==true).FirstOrDefault();
        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            //delet from a list of cartItems list
            var item = AppDbContext.CartItems.Where(c => c.CartId == cartId && c.Id == itemId).FirstOrDefault();
            if (item != null)
            {
                //CartItems must be deleted and not the entire collection
               AppDbContext.CartItems.Remove(item);
              return AppDbContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
        //only the quantity needs to be updated in the chart 
        public int UpdateQuantity(Guid cartId, int itemId, int Quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);
            if (cart != null)
            {
                for (int i = 0; i < cart.Items.Count; i++)
                {
                    if (cart.Items[i].Id == itemId)
                    {
                        flag = true;
                        //remove item from the quantitty
                        //for minus quantity check if item is zero or greater than 1 to minus
                        if (Quantity < 0 && cart.Items[i].Quantity > 1)
                            cart.Items[i].Quantity += (Quantity);
                        //Add item to quantity check if its greater than 0 to add
                        else if (Quantity > 0)
                            cart.Items[i].Quantity += (Quantity);
                        break;
                    }
                }
                //check if flag is true before you commit
                if (flag)
                    return AppDbContext.SaveChanges();
            }
            return 0;
        }
        //this when inserting another item
        public int UpdateCart(Guid cartId, int userId)
        {
            Cart cart = GetCart(cartId);
            cart.UserId = userId;
           return AppDbContext.SaveChanges();
        }
    }
}
