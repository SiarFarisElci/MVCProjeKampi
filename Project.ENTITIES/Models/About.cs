using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class About : BaseEntity
    {
        [StringLength(1000)]
        public string AboutDetail1 { get; set; }
        [StringLength(1000)]

        public string AboutDetail2 { get; set; }
        [StringLength(100)]

        public string AboutImage1 { get; set; }
        [StringLength(100)]

        public string AboutImage2 { get; set; }



        //Relational Properties
    }
}
