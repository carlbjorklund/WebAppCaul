using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCa.Models
{

    public class Programme
    {
        [Key] public int ProgrammeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Length { get; set; }
       

     

        public Category Category { get; set; }
        public int? CategoryId { get; set; }
    
        public virtual ICollection<Schedule> Schedules { get; set; }



    }
}
