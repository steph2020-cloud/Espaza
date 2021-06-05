using eSpazaShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Creating specific Repositoy which dont use named tables and classes eg. Cart

namespace eSpazaShop.Repositories.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCart(Guid cartId);
        int DeleteItem(Guid cartId, int itemId);
        int UpdateQuantity(Guid cartId, int itemId, int Quantity);
        int UpdateCart(Guid cartId, int userId);
    }
}
 