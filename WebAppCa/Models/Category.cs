using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCa.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Programme> Programmes { get; set; }
    }
}
