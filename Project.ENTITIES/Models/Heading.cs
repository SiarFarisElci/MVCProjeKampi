using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Heading : BaseEntity
    {
        [StringLength(100)]

        public string HeadingName { get; set; }

        public int? CategoryID { get; set; }
        public int? WriteID { get; set; }

        //Relational Properties

        public virtual Category  Category { get; set; }
        public virtual Write   Write { get; set; }

        public virtual List<Content>  Contents { get; set; }
    }
}
