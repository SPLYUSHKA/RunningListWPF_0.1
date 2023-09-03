using RunList.Infrastructure.Commands;
using RunList.Models;
using RunList.ModelViews.Base;
using RunList.Servises;
using RunList.Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RunList.ModelViews
{
    internal class CalendarWeekNumbersVM : ViewModel
    {
        private UserTaskServises _taskServises = new UserTaskServises();
        private IDialogWithHistory dialogWithHistory;
        public int CurrentWeek { get; set; }

        public CalendarWeekNumbersVM(IDialogWithHistory dialogWith) 
        {
            dialogWithHistory = dialogWith;
            var week = _taskServises.GetWeekNumber();
            CurrentWeek = week;
            Now = Convert.ToString($"{CalculationStartAndEnd(week)[0].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}-{CalculationStartAndEnd(week)[1].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}");
            First = Convert.ToString($"{CalculationStartAndEnd(week - 1)[0].Day.ToString().PadLeft(2,'0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}-{CalculationStartAndEnd(week - 1)[1].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}");
            Second = Convert.ToString($"{CalculationStartAndEnd(week - 2)[0].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}-{CalculationStartAndEnd(week - 2)[1].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}");
            Thrid = Convert.ToString($"{CalculationStartAndEnd(week - 3)[0].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}-{CalculationStartAndEnd(week - 3)[1].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}");
            Four = Convert.ToString($"{CalculationStartAndEnd(week - 4)[0].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}-{CalculationStartAndEnd(week - 4)[1].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}");
            Five = Convert.ToString($"{CalculationStartAndEnd(week - 5)[0].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}-{CalculationStartAndEnd(week - 5)[1].Day.ToString().PadLeft(2, '0')}.{CalculationStartAndEnd(week)[0].Month.ToString().PadLeft(2, '0')}");
        }
        private DateTime[] CalculationStartAndEnd(int week) 
        {
            DateTime[] dateTimes = new DateTime[2];
            string s = DateTime.Now.Year.ToString();
            DateTime d = new DateTime(int.Parse(s), 1, 1);
            dateTimes[0] = d.AddDays(week * 7 - 6);
            dateTimes[1] = d.AddDays(week * 7);

            return dateTimes;

        }
        public CalendarWeekNumbersVM(IDialogWithHistory dialogWith, IUserDialog dialog) : this(dialogWith)
        {
            this.dialog = dialog;
        }
        #region Свойство для недель
        private string _now;

        public string Now
        {
            get => _now;
            set => Set(ref _now, value);
        }
        private string _five;

        public string Five
        {
            get => _five;
            set => Set(ref _five, value);
        }
        private string _thrid;

        public string Thrid
        {
            get => _thrid;
            set => Set(ref _thrid, value);
        }
        private string _first;

        public string First
        {
            get => _first;
            set => Set(ref _first, value);
        }
        private string _four;

        public string Four
        {
            get => _four;
            set => Set(ref _four, value);
        }
        private string _second;

        public string Second
        {
            get => _second;
            set => Set(ref _second, value);
        }

        #endregion

        #region Переходы
        private ICommand _showHistoryFirst;
        private IUserDialog dialog;

        public ICommand ShowHistoryFirst => _showHistoryFirst ?? new LamdaCommand(OnShowHistoryFirst, CanShowHistoryFirst);

        private bool CanShowHistoryFirst(object arg) => true;


        private async void OnShowHistoryFirst(object obj)
        {
            if (dialogWithHistory.ShowHistory(CurrentWeek-1))
            {
                dialogWithHistory.ShowHistory(CurrentWeek-1);
                return;
            }
        }
        private ICommand _showHistorySecond;


        public ICommand ShowHistorySecond => _showHistorySecond ?? new LamdaCommand(OnShowHistorySecond, CanShowHistorySecond);

        private bool CanShowHistorySecond(object arg) => true;


        private async void OnShowHistorySecond(object obj)
        {
            if (dialogWithHistory.ShowHistory(CurrentWeek-2))
            {
                dialogWithHistory.ShowHistory(CurrentWeek-2);
                return;
            }
        }
        private ICommand _showHistoryThrid;


        public ICommand ShowHistoryThrid=> _showHistoryThrid ?? new LamdaCommand(OnShowHistoryThrid, CanShowHistoryThrid);

        private bool CanShowHistoryThrid(object arg) => true;


        private async void OnShowHistoryThrid(object obj)
        {
            if (dialogWithHistory.ShowHistory(CurrentWeek - 3))
            {
                dialogWithHistory.ShowHistory(CurrentWeek - 3);
                return;
            }
        }
        private ICommand _showHistoryFour;


        public ICommand ShowHistoryFour => _showHistoryFour ?? new LamdaCommand(OnShowHistoryFour, CanShowHistoryFour);

        private bool CanShowHistoryFour(object arg) => true;


        private async void OnShowHistoryFour(object obj)
        {
            if (dialogWithHistory.ShowHistory(CurrentWeek - 4))
            {
                dialogWithHistory.ShowHistory(CurrentWeek - 4);
                return;
            }
        }
        private ICommand _showHistoryFive;


        public ICommand ShowHistoryFive => _showHistoryFive ?? new LamdaCommand(OnShowHistoryFive, CanShowHistoryFive);

        private bool CanShowHistoryFive(object arg) => true;


        private async void OnShowHistoryFive(object obj)
        {
            if (dialogWithHistory.ShowHistory(CurrentWeek - 5))
            {
                dialogWithHistory.ShowHistory(CurrentWeek - 5);
                return;
            }
        }
        private ICommand _showHistoryNow;
       

        public ICommand ShowHistoryNow => _showHistoryNow ?? new LamdaCommand(OnShowHistoryNow, CanShowHistoryNow);

        private bool CanShowHistoryNow(object arg) => true;
       

        private async void OnShowHistoryNow(object obj)
        {   
            if (dialogWithHistory.ShowHistory(CurrentWeek))
            {
                dialogWithHistory.ShowHistory(CurrentWeek);
                return;
            }
        }


        #endregion
    }
}
