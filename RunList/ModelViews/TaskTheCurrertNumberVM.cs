using Microsoft.Extensions.DependencyInjection;
using Nito.AsyncEx;
using RunList.Infrastructure.Commands;
using RunList.Models;
using RunList.Models.DTO_Model;
using RunList.ModelViews.Base;
using RunList.Servises;
using RunList.Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace RunList.ModelViews
{
    internal class TaskTheCurrertNumberVM :ViewModel
    { 
        private UserTaskServises _taskServises = new UserTaskServises();
        private readonly WindowUserDialogServises dialogServises = new WindowUserDialogServises();
        private readonly IUserDialog _userDialog;
        private readonly IUserTaskServises  _servises;
        public int Weeknumber { get; set; }
        public TaskTheCurrertNumberVM(IUserDialog dialog, IUserTaskServises servises) 
        {
            _userDialog = dialog;
            _servises = servises;           
            InitializationNotifier = NotifyTaskCompletion.Create(InitializeAsync());
           
        }

        private bool _taskCompleted;

        public bool TaskCompleted
        {
            get=> _taskCompleted;
            set => Set(ref _taskCompleted, value);
        }

        private UserTask _selectedTask;

        public UserTask SelectedTask
        {
            get => _selectedTask;
            set => Set(ref _selectedTask, value);
        }


        public INotifyTaskCompletion InitializationNotifier { get; private set; }


        private async Task InitializeAsync()
        {
            _taskServises = new UserTaskServises();
            Weeknumber = _taskServises.GetWeekNumber();
            var data = await _taskServises.GetTaskWeekNumber(Weeknumber);
            _reserve = new ObservableCollection<UserTask>(data);
            UserTasks = new ObservableCollection<UserTask>(data.Where(t=>t.Completed ==false));

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

       

        #region Команды для работы с задачами 
        private ICommand _deleteTask;

        public ICommand DeleteTask => _deleteTask ?? new LamdaCommand(OnDeleteTaskCommandExecute, CanDeleteTaskCanExecute);
        private bool CanDeleteTaskCanExecute(object arg) => true;
        private async void OnDeleteTaskCommandExecute(object obj)
        {    
            if (SelectedTask != null)
            {
                if (SelectedTask.Completed != true)
                {

                    var task = SelectedTask;
                    await _taskServises.DeleteTask(SelectedTask);
                    if (SelectedTask != null)
                    {
                        if (task.Completed == SelectedTask.Completed)
                        {
                            if (task.Changed == true)
                            {
                                if (task.ChangeDay < DateTime.Now.DayOfWeek)
                                {
                                    dialogServises.ShowInformation("День выполнения задачи уже прошёл, её невозможно закрыть", "Информация о задаче");
                                }
                                else
                                {
                                    dialogServises.ShowInformation("Так как не наступил день выполнения задачи, её невозможно закрыть", "Информация о задаче");
                                }

                            }
                            else
                            {
                                if (task.StartDay != DateTime.Now.DayOfWeek)
                                {
                                    if (task.StartDay < DateTime.Now.DayOfWeek) 
                                    {
                                        dialogServises.ShowInformation("День выполнения задачи уже прошёл, её невозможно закрыть", "Информация о задаче");
                                    }
                                    else
                                    {
                                        dialogServises.ShowInformation("Так как не наступил день выполнения задачи, её невозможно закрыть", "Информация о задаче");
                                    }
                                }
                            }

                        }
                    }
                    await InitializeAsync();

                }
                else
                {
                    dialogServises.ShowWarning("Эта задача уже была завершена", "Предупреждение");
                }
            }
        }

        private ICommand _showWindowAddTask;
        public ICommand ShowWindowAddTask =>
            _showWindowAddTask ?? new LamdaCommand(OnShowWondowAddTaskCommandExecute,CanShowWindowAddTaskCanExecute);

        private bool CanShowWindowAddTaskCanExecute(object arg) => true;
       

        private async void OnShowWondowAddTaskCommandExecute(object obj)
        {
            var new_task = new UserTaskDTO();
            new_task.Week = _taskServises.GetWeekNumber();
            bool template = false;
            if (_userDialog.Add(new_task, ref template))
            {
                await _taskServises.AddTask(new_task,template);
                await InitializeAsync();               
                return;
            }
           
        }

        private ICommand _showWindowEditTask;
        public ICommand ShowWindowEditTask =>
         _showWindowEditTask ?? new LamdaCommand(OnShowWindowEditTaskCommandExecute, CanShowWindowEditTaskCanExecute);

        private bool CanShowWindowEditTaskCanExecute(object arg) => true;


        private  async void OnShowWindowEditTaskCommandExecute(object obj)
        {
            var new_task = new UserTask();
            int operations = 0;
          
            if (SelectedTask != null)
            {
                if (SelectedTask.Completed != true)
                {
                    new_task = SelectedTask;
                    Difficulty NewDif = SelectedTask.Difficulty;


                    if (_userDialog.Edit(new_task, ref operations, ref NewDif))
                    {
                        SelectedTask = new_task;
                        if (NewDif != SelectedTask.Difficulty)
                        {

                            await _taskServises.EditTaskDiff(new_task, NewDif);
                            await InitializeAsync();
                        }
                        if (operations != 0)
                        {
                            await _taskServises.EditTaskMove(new_task, operations);
                            await InitializeAsync();

                        }
                        return;
                    }
                }
                else 
                {
                    dialogServises.ShowWarning("Эта задача уже была завершена","Предупреждение");
                }
            }
            
        }

        #endregion

        #region Выполненные Задачи
        private ICommand _showTaskCompleted;

        public ICommand ShowTaskCompleted => _showTaskCompleted ?? new LamdaCommand(OnShowTaskCompleted, CanShowTaskCompleted);

        private bool CanShowTaskCompleted(object arg) => true;


        private void OnShowTaskCompleted(object obj)
        {


            if (TaskCompleted == true)
            {
                if (_reserve.Count() != null)
                {
                    var data = _reserve.Where(t => t.Completed == true);
                    UserTasks = new ObservableCollection<UserTask>(data);
                }
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
