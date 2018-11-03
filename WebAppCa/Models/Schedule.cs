using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCa.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public string Image { get; set; }

        [Display(Name = "Air Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime AirDate { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public System.TimeSpan StartTime { get; set; }


        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public System.TimeSpan EndTime { get; set; }
        public int Sorting { get; set; }
       
        public  int ChannelId { get; set; }
        public int ProgrammeId { get; set; }


     

    }
}
