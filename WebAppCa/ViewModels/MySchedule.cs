using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppCa.Models;

namespace WebAppCa.ViewModels
{
    public class MySchedule
    {
        [Key]
        public int MyScheduleId { get; set; }
        public string UserName { get; set; }

        //public string UserID { get; set; }
        public User User { get; set; }  
        
        public Schedule Schedule { get; set; }
        public int ScheduleID { get; set; }
    
        public MySchedule()
        {
    
        }
            
    }
}
