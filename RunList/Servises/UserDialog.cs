using RunList.Models;
using RunList.Models.DTO_Model;
using RunList.ModelViews;
using RunList.Servises.Interfaces;
using RunList.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Servises
{
    internal class UserDialog : IUserDialog
    {
        public bool Add(UserTaskDTO task, ref bool template)
        {
            var usertask_add_model = new AddUserTask(task, ref template);
            var usertask_add_window = new AddTask
            {
                DataContext = usertask_add_model

            };
            if (usertask_add_window.ShowDialog() != true) return false;
            else
            {
                task.Title = usertask_add_model.Title;
                task.Description = usertask_add_model.Description;
                task.StarttDay = usertask_add_model.StartDay;
                task.Difficulty = usertask_add_model.Difficulty;
                template = usertask_add_model.Template;
                task.date = DateTime.Now;
                task.Completed = false;
                task.Changed = false;
                task.ChangeDay = usertask_add_model.StartDay;
                return true;
            }
        }

        public bool Edit(UserTask task, ref int operations, ref Difficulty NewDif)
        {
            var usertask_editor_model = new EditUserTaskVM(task, ref operations,ref NewDif);
            var usertask_editor_window = new WindowEditTask
            {
                DataContext = usertask_editor_model

            };
            if (usertask_editor_window.ShowDialog() != true) return false;
            else
            {                
                NewDif = usertask_editor_model.Difficulty;
                operations = usertask_editor_model.Operations;
                return true;
            }
        }
       
    }
}
