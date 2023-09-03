using RunList.Models;
using RunList.Models.DTO_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Servises.Interfaces
{
    internal interface IUserTaskServises
    {
        public Task<IEnumerable<UserTask>> GetTaskWeekNumber(int numberweek);
        public Task<IEnumerable<UserTask>> GetTaskWeekNumberCompleted(int numberweek);
        public Task EditTaskDiff(UserTask Edittask, Difficulty NewDifficulty);
        public Task EditTaskMove(UserTask EditTask, int op);
        public Task AddTask(UserTaskDTO userTask, bool template);
        public Task DeleteTask(UserTask userTask);
        public int GetWeekNumber();      
        public string[] GetPathImages(UserTask userTask);
       

    }
}
