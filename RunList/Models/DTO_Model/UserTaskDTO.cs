using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Models.DTO_Model
{
   
    public class UserTaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime date { get; set; }
        public DayOfWeek StarttDay { get; set; }
        public DayOfWeek ChangeDay { get; set; }
        public Difficulty Difficulty { get; set; }
        public int Week { get; set; }
        public bool Completed { get; set; }
        public bool Changed { get; set; }
    }
}
