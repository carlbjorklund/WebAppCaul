using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppCa.Models;

namespace WebAppCa.ViewModels
{
    public class MySchedulesViewModel
    {
        [Key]
        public int MyScheduleId { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public List<Schedule> MySchedules { get; set; }


        public MySchedulesViewModel()
        {
            MySchedules = new List<Schedule>();
        }
            
    }
}
