using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.VMClasses
{
    public class ContentVM
    {
        public Content   Content { get; set; }
        public List<Content>   Contents { get; set; }
        public List<Heading>    Headings { get; set; }
        public List<Write>    Writes { get; set; }
    }
}