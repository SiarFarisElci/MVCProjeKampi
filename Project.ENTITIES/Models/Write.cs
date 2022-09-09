using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Write : BaseEntity
    {
        [StringLength(50)]

        public string Name { get; set; }
        [StringLength(50)]

        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }
        }
        [StringLength(100)]

        public string WriteImage { get; set; }
        [StringLength(100)]

        public string WriteMail { get; set; }
        [StringLength(20)]

        public string WritePassword { get; set; }

        //Relational Properties
        public virtual List<Heading>  Headings { get; set; }

        public virtual List<Content>  Contents { get; set; }

    }
}
