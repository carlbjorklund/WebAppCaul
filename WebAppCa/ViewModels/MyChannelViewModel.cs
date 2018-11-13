using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAppCa.Models;

namespace WebAppCa.ViewModels
{
    public class MyChannelViewModel
    {
        public string UserName { get; set; }
      
        [Key]
        public string UserID { get; set; }
        public List<Channel> MyChannels { get; set; }

        public MyChannelViewModel()
        {
            MyChannels = new List<Channel>();
        }
        
    }
}

