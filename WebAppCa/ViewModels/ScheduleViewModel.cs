using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebAppCa.ViewModels
{
    public class ScheduleViewModel
    {
        [Key]
        public int ScheduleViewModelId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string ChannelName { get; set; }
        public string ProgrameName { get; set; }
        public string ProgrameDescription { get; set; }
        public int Length { get; set; }
        public DateTime AirDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

    }


}