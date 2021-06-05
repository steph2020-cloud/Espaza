using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSpazaShop.Entities
{
    public class Role : IdentityRole<int>
    {
        // TO DO:
        //you add extra properties to customise package
        public string Description { get; set; }
    }
}
