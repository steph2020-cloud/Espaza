using eSpazaShop.Entities;
using eSpazaShop.WebUI.Interfaces;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSpazaShop.WebUI.Helpers
{
    //Infor details here are only accessible to areas folder will be injected in over views 
    public abstract class BaseViewPage <TModel> : RazorPage<TModel>
    {
        [RazorInject]
        public IUserAccessor _userAccessor { get; set; }
        public User CurrentUser
        {
            get
            {
                if (User != null)
                    return _userAccessor.GetUser();
                else
                    return null;
            }
        }
    }
}
