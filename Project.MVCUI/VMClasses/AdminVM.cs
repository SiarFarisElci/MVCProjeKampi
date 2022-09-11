using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.VMClasses
{
    public class AdminVM
    {
        public Admin   Admin { get; set; }
        public List<Admin>   Admins { get; set; }
    }
}