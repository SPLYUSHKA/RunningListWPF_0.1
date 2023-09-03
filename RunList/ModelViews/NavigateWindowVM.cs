using Microsoft.Extensions.DependencyInjection;
using RunList.Infrastructure.Commands;
using RunList.ModelViews.Base;
using RunList.Servises;
using RunList.Servises.Interfaces;
using RunList.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RunList.ModelViews
{
    internal class NavigateWindowVM : ViewModel
    {
        private readonly IUserDialog dialog;
        private readonly IUserTaskServises servises;
        private readonly IDialogWithHistory dialogWithHistory;
        private UserTaskServises _taskServises = new UserTaskServises();
      
        private string _title = "Окно навигации";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #region Переключение представлений

        private ViewModel _currentModel;

        public ViewModel CurrentModel
        {
            get => _currentModel;
            private set => Set(ref _currentModel, value); 
        }
        private ICommand _showCurrentWeeekNumber;

        public ICommand ShowTheCurrentWeekNumber => _showCurrentWeeekNumber ?? new LamdaCommand(OnShowTheCurrentWeekNumber, CanShowWindowTheCurrentWeekNumber);

        private void OnShowTheCurrentWeekNumber(object obj)
        {
            //  weeknumber = _taskServises.GetWeekNumber();
         
         
            CurrentModel = new TaskTheCurrertNumberVM(dialog,servises);

        }

        private bool CanShowWindowTheCurrentWeekNumber(object arg) => true;


        private ICommand _showCalendarWeekNumber;

        public ICommand ShowCalendarWeekNumbers => _showCalendarWeekNumber ?? new LamdaCommand(OnShowCalendarWeekNumber,CanShowCalendarWeekNumber);

        private bool CanShowCalendarWeekNumber(object arg) => true;
       

        private void OnShowCalendarWeekNumber(object obj)
        {
            CurrentModel = new CalendarWeekNumbersVM(dialogWithHistory);
        }

        private ICommand _showAboutSystem;

        public ICommand ShowAboutSystem => _showAboutSystem ?? new LamdaCommand(OnShowAboutSystem, CanShowAboutSystem);

        private void OnShowAboutSystem(object obj)
        {
            CurrentModel = new AboutSystemVM();
        }

        private bool CanShowAboutSystem(object arg) => true;

        private ICommand _WindowClose;
        public ICommand WindowClose => _WindowClose ?? new LamdaCommand(o => ((Window)o).Close(), CanWindowClose);
        private bool CanWindowClose(object arg) => true;



        #endregion
    }
}

