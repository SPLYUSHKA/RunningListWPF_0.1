using Nito.AsyncEx;
using RunList.Infrastructure.Commands;
using RunList.Models;
using RunList.ModelViews.Base;
using RunList.Servises;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RunList.ModelViews
{
    internal class WindowHistoryTasksTheCurrentWeekVM : ViewModel
    {
        private UserTaskServises _taskServises = new UserTaskServises();
        //свойство которому будем присваивать номер недели

        public WindowHistoryTasksTheCurrentWeekVM(int weeknumber)
        {
            WeekNumber = weeknumber;
            InitializationNotifier = NotifyTaskCompletion.Create(InitializeAsync());
        }

        private int _weeknumber;

		public int WeekNumber
		{
			get { return _weeknumber; }
			set { _weeknumber = value; }
		}

        private bool _taskCompleted;

        public bool TaskCompleted
        {
            get => _taskCompleted;
            set => Set(ref _taskCompleted, value);
        }

        private UserTask? _selectedTask;

        public UserTask SelectedTask
        {
            get => _selectedTask;
            set => Set(ref _selectedTask, value);
        }

        public INotifyTaskCompletion InitializationNotifier { get; private set; }


        private async Task InitializeAsync()
        {
            _taskServises = new UserTaskServises();          
            var data = await _taskServises.GetTaskWeekNumber(WeekNumber);
            _reserve = new ObservableCollection<UserTask>(data);
            UserTasks = new ObservableCollection<UserTask>(data.Where(t => t.Completed == false));
           
          

        }

        private ObservableCollection<UserTask> _userTask;

        private ObservableCollection<UserTask> _reserve;

        public ObservableCollection<UserTask> UserTasks
        {
            get => _userTask;
            set
            {
                if (value != null)
                {
                    Set(ref _userTask, value);
                }
            }
        }

      



        #region Выполненные Задачи
        private ICommand _showTaskCompleted;

        public ICommand ShowTaskCompleted => _showTaskCompleted ?? new LamdaCommand(OnShowTaskCompleted, CanShowTaskCompleted);

        private bool CanShowTaskCompleted(object arg) => true;


        private void OnShowTaskCompleted(object obj)
        {


            if (TaskCompleted == true)
            {
                var data = _reserve.Where(t => t.Completed == true);
                UserTasks = new ObservableCollection<UserTask>(data);
            }
            else if (TaskCompleted == false)
            {
                var data = _reserve.Where(t => t.Completed == false);
                UserTasks = new ObservableCollection<UserTask>(data);

            }
        }
        #endregion
    }
}
