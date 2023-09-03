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
    internal class DialogWithHistory : IDialogWithHistory
    {
        public bool ShowHistory(int weekNumber)
        {
            var usertask_windowHistoryTasksTheCurrentWeekVM_model = new WindowHistoryTasksTheCurrentWeekVM(weekNumber);
            var usertask_windowHistoryTasksTheCurrentWeekVM_window = new WindowHistoryTasksTheCurrentWeek
            {
                DataContext = usertask_windowHistoryTasksTheCurrentWeekVM_model

            };
            if (usertask_windowHistoryTasksTheCurrentWeekVM_window.ShowDialog() != true) return false;
            else
            {
               
                return true;
            }
        }
    }
}
