using eSpazaShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSpazaShop.WebUI.Interfaces
{
    public interface IUserAccessor
    {
        User GetUser();
    }
}
