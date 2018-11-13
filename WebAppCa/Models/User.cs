using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCa.Models
{
    public class User
    {
        private int _userId;

        public User(int userId)
        {
            UserId = userId;

            MyChannels = new List<Channel>();
            MyProgrammes = new List<Programme>();
            MySchedules = new List<Schedule>();
        }

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }

        private string Email { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }
        public ICollection<Channel> MyChannels { get; set; }

        public ICollection<Programme> MyProgrammes { get; set; }

        public ICollection<Schedule> MySchedules { get; set; }
        public static object Identity { get; internal set; }
    }

}
