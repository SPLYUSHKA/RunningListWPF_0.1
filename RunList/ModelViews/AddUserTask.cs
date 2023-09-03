using RunList.Models;
using RunList.Models.DTO_Model;
using RunList.ModelViews.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RunList.ModelViews
{
    internal class AddUserTask : ViewModel
    {
        private string _titleWindow = "Окно для создания задачи";
        public string TitleWindow
        {
            get => _titleWindow;
            set => Set(ref _titleWindow, value);
        }
        #region Свойства для задачи
        private string _title = "Название задачи";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private string _description ="Описание задачи";

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }
        private DayOfWeek _startDay;

        public DayOfWeek StartDay
        {
            get { return _startDay; }
            set { _startDay = value; }
        }

        private Difficulty _difficulty;

        public Difficulty Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }

        public List<DayOfWeek> _days { get; set; } =
        new List<DayOfWeek>
        {
                {  DayOfWeek.Monday},
                {  DayOfWeek.Tuesday },
                {  DayOfWeek.Wednesday },
                {  DayOfWeek.Thursday},
                { DayOfWeek.Friday },
                {DayOfWeek.Saturday },
                {DayOfWeek.Sunday }
        };


        public List<Difficulty> _difficulties { get; set; } =
        new List<Difficulty>
        {
                {  Difficulty.Easy},
                {  Difficulty.Medium },
                {  Difficulty.Hard }
        };

        private bool _template;

        public bool Template
        {
            get { return _template; }
            set { _template = value; }
        }

        public Cursor Cursor { get; set; }

        #endregion
        public AddUserTask(UserTaskDTO task, ref bool template) 
        {

            var uri = new Uri("pack://application:,,,/Images/Cursors/cat.cur");
            var stream = Application.GetResourceStream(uri).Stream;
            var cursor = new Cursor(stream);
            Cursor = cursor;
        }

    }
}
