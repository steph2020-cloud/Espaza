using eSpazaShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSpazaShop.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetUserOrders(int userId);
    }
}
