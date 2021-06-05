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
    public class OrderRepository :Repository<Order>, IOrderRepository
    {
        protected AppDbContext AppDbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        //Dependance injection object is not initialized its addede through the ServiceDepandancies class
        public OrderRepository(DbContext _dbContext):base(_dbContext)
        {
          
        }
        public IEnumerable<Order> GetUserOrders(int userId)
        {
            //public ICollection<OrderItem> OrderItems { get; set; }
           return AppDbContext.Orders
                .Include(oi =>oi.OrderItems)
               .Where(o => o.UserId == userId).ToList();
        }
    }
}
