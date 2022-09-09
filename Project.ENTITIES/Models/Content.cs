using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Content : BaseEntity
    {
        [StringLength(1000)]

        public string  ContentValue { get; set; }

        public int? HeadingID { get; set; }
        public int? WriteID { get; set; }

        //Relational Properties

        public virtual Heading Heading  { get; set; }
        public virtual Write    Write  { get; set; }
    }
}
