using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAppCa.ViewModels;

namespace WebAppCa.Models
{
    public class User
    {
        private string Email { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        public List<Channel> MyChannels { get; set; }

        public List<Programme> MyProgrammes { get; set; }

        
        public List<MySchedule> MySchedules { get; set; }

        public static object Identity { get; internal set; }
        private int _userId;

        public User(int userId)
        {
            UserId = userId;

            MyChannels = new List<Channel>();
            MyProgrammes = new List<Programme>();
            MySchedules = new List<MySchedule>();
        }

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }
        public List<Channel> AddChannels(Channel channel)
        {

            MyChannels.Add(channel);
            
            return MyChannels;
        }

       
    }

 

}
