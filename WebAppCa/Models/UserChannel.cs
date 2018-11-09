using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCa.Models
{
    public class UserChannel
    {
        public int UserChannelId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("ChannelId")]
        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}
