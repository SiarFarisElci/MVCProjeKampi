using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.VMClasses
{
    public class HeadingVM
    {
        public Heading  Heading  { get; set; }
        public Category  Category { get; set; }
        public Write Write { get; set; }
        public List<Heading>  Headings  { get; set; }
        public List<Category>  Categories   { get; set; }
        public List<Write>   Writes   { get; set; }
    }
}