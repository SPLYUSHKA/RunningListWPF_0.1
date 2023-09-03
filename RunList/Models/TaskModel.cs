using RunList.Models.DTO_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RunList.Models
{
    public enum Difficulty { Easy = 1, Medium = 2, Hard = 3 };
    [Serializable]
    public class UserTask
    {

        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DayOfWeek StartDay { get; set; }
        public DayOfWeek ChangeDay { get; set; }
        public Difficulty Difficulty { get; set; }
        public int WeekNumber { get; set; }
        public bool Completed { get; set; }
        public bool Changed { get; set; }
        public bool TemplateTask { get; set; }

        [JsonIgnore]
        public string[] ImagesItem { get; set; } 
    }
}
