using RunList.Infrastructure.Commands;

using RunList.Models;
using RunList.ModelViews.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RunList.ModelViews
{
    internal class EditUserTaskVM : ViewModel
    {
        private string _titleWindow = "Окно для редактирования задачи";
        public string TitleWindow
        {
            get => _titleWindow;
            set => Set(ref _titleWindow, value);
        }


        #region Свойства для Задачи

        private int _operations;

        public int Operations
        {
            get { return _operations; }
            set { _operations = value; }
        }

        private string _title;

        public string Title
        {
            get =>  _title;
            set => Set(ref _title, value);
        }

        private string _description;

        public string Description
        {
            get =>_description;
            set => Set(ref _description, value);
        }
        private DayOfWeek _changeDay;

        public DayOfWeek ChangeDay
        {
            get { return _changeDay; }
            set { _changeDay = value; }
        }

        private Difficulty _difficulty;

        public Difficulty Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }

     

        public List<Difficulty> _difficulties { get; set; } =
        new List<Difficulty>
        {
                {  Difficulty.Easy},
                {  Difficulty.Medium },
                {  Difficulty.Hard }
        };

        private ICommand _addDay;
        public ICommand AddDay => 
            _addDay?? new LamdaCommand(OnAddDayCommandExecute, CanAddDayCanExecute);

        private bool CanAddDayCanExecute(object arg) => _operations == 0 ? true : false;
        

        private void OnAddDayCommandExecute(object obj)
        {
            Operations = 1;
        }

        private ICommand _difDay;
        public ICommand DifDay =>
            _addDay ?? new LamdaCommand(OnDifDayCommandExecute, CanDifDayCanExecute);

        private bool CanDifDayCanExecute(object arg) => _operations == 0 ? true : false;


        private void OnDifDayCommandExecute(object obj)
        {
            Operations = 2;
        }
        #endregion

        public EditUserTaskVM(UserTask task,ref int operations, ref Difficulty difficulty)
        {
          

            Title = task.Title;
            Description = task.Description;
            Difficulty = difficulty;        
            ChangeDay = task.ChangeDay;
            Operations = operations;
               
        }
    }
}
