using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCa.ViewModels
{ 
    public class UserStuff
    {
        [Key]
        public string UserID { get; set; }
        public string UserName { get; set; }

        public List<MyStuffViewModel> myStuffs { get; set; }

        public UserStuff()
        {
            myStuffs = new List<MyStuffViewModel>();
        }

    }    
    
    public class MyStuffViewModel
    {
        [Key]
        public int MyStuffID { get; set; }


        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

        public int ScheduleId { get; set; }

        [Display(Name = "Channel")]
        public string ChannelName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Programme name")]
        public string ProgrameName { get; set; }

        [Display(Name = "Programme Description")]
        public string ProgrameDescription { get; set; }
        public int Length { get; set; }


        [Display(Name = "Air Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime AirDate { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan EndTime { get; set; }
    }
}
