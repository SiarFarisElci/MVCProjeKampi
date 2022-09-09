using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.VMClasses
{
    public class WriteVM
    {
        public Write   Write { get; set; }
        public List<Write>   Writes { get; set; }
    }
}