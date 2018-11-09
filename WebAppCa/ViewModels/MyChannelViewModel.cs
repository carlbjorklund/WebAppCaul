using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAppCa.ViewModels
{
    public class MyChannelViewModel
    {
        [Key]
        public int MyChannelId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
    }
}
