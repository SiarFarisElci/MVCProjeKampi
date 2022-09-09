using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Category : BaseEntity
    {
        [StringLength(50)]

        public string CategoryName { get; set; }
        [StringLength(200)]

        public string Description { get; set; }


        //Relational Properties

        public virtual List<Heading>  Headings { get; set; }

    }
}
