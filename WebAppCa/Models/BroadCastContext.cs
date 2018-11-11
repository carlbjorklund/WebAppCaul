using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebAppCa.ViewModels;
using WebAppCa.Models;

namespace WebAppCa.Models
{
    public class BroadCastContext : IdentityDbContext
    {
        public BroadCastContext()
        {
        }

        public BroadCastContext(DbContextOptions<BroadCastContext> options)
            : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<User> User { get; set; }
      


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}

