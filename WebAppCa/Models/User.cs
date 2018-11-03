using System;
using System.Collections.Generic;
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
        }

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }

        private string Email { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

       
    }
    
}
