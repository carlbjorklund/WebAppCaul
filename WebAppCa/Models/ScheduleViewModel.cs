using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppCa.Models
{
    public class ScheduleViewModel: BroadCastContext
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Channel { get; set; }
        public string ProgrameName { get; set; }
        public string ProgrameDescription { get; set; }
        public int Length { get; set; }
        public DateTime AirDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }



        public static List<ScheduleViewModel> GetAllSchedules()
        {
            // BroadCastContext context = new BroadCastContext();
            //var Schedules = context.Database.ExecuteSqlCommand("SELECT Vardas as FirstName, Pavarde as LastName FROM ZAIDEJAS")
            //        .ToList<ScheduleViewModel>();


            //using (var Context = new BroadCastContext())
            //    var schedules = Context.Programmes
            //        .Include(p=>p.pr)
            ////        .Include(c=>c.c)

            return schedules;
        }
    }
}