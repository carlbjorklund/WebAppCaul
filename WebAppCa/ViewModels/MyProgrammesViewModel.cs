using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppCa.Models;

namespace WebAppCa.ViewModels
{
    public class MyProgrammesViewModel
    {
        [Key]
        public int MyProgrammeId { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public List<Programme> MyProgrammes { get; set; }

        public MyProgrammesViewModel()
        {
            MyProgrammes = new List<Programme>();
        }
    }
}
