using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RunList.Models
{
    [Serializable]
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
