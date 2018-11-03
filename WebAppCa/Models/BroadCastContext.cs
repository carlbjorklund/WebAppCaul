using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAppCa.Models
{
    public class BroadCastContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-O84LAFN;Database=UlcaDB;Trusted_Connection=True;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
       
    }
}