using Nito.AsyncEx;
using RunList.Infrastructure.Commands;
using RunList.Infrastructure.Commands.Base;
using RunList.Models.DTO_Model;
using RunList.ModelViews.Base;
using RunList.Views.Windows;
using System;
using RunList.Servises;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RunList.Servises.Interfaces;
using System.Windows;

namespace RunList.ModelViews
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly UserLoginAndSignInServises users = new UserLoginAndSignInServises();
        private readonly WindowUserDialogServises dialogServises = new WindowUserDialogServises();
        public Cursor Cursor { get; set; }
        public MainWindowViewModel() 
        {

            var uri = new Uri("pack://application:,,,/Images/Cursors/PawLoading.ani");
            var stream = Application.GetResourceStream(uri).Stream;
            var cursor = new Cursor(stream);
            Cursor = cursor;
        }
        #region Заголовок окна 
        private string _title = "Окно входа";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region Свойства для Login


        private string? _emailUserLog;

        public string? EmailUserLog
        {
            get => _emailUserLog;
            set => Set(ref _emailUserLog, value);
        }

        public string _password;

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public bool _readme;

        public bool Readme
        {
            get => _readme;
            set => Set(ref _readme, value);
        }
        public  bool _isGoNavigate =false;

        

        #endregion

        private async Task GoAsync()
        {
            if (EmailUserLog != null && Password != null)
            {
                DTOUser user = new DTOUser(){ name = "  ", email = EmailUserLog, password = Password };
                _isGoNavigate = await users.LogIn(user);
            
            }
            else
            {
               _isGoNavigate = false;
                dialogServises.ShowError("Все поля должны быть заполенны", "Ошибка");
            }
          
        }

        #region Команды перехода
        //Это пустой регион
        //да.

        #endregion
        private bool _showcanbutton = true;

        public bool CanButton
        {
            get { return _showcanbutton; }
            set { _showcanbutton = value; }
        }


        private ICommand _showWindowNavigate;
        public ICommand ShowWindowNavigate => _showWindowNavigate ?? new LamdaCommand(OnShowWindowNavigate, CanShowWindowNavigate);
        private bool CanShowWindowNavigate(object arg) => CanButton;
       
        public object CurrentModel { get; private set; }

        private async void OnShowWindowNavigate(object obj)
        {
            CanButton = false;
            await GoAsync();
            
            if (_isGoNavigate == true)
            {  

                var CurrentWindow = new NavigateWindow();
                CurrentWindow.ShowDialog();
                CanButton = true;
               
            }
            else 
            {

                if (_isGoNavigate == true)
                {

                    var CurrentWindow = new NavigateWindow();
                    CurrentWindow.ShowDialog();

                }
                else
                {
                    dialogServises.ShowWarning("Невернные данные", "Предупреждение");
                    CanButton = true;
                }
            }
          
        }
        private ICommand _showWindowRegist;
        public ICommand ShowWindowRegist => _showWindowRegist ?? new LamdaCommand(OnShowWindowRegist, CanShowWindowNRegist);
        private bool CanShowWindowNRegist(object arg) => true;


        private async void OnShowWindowRegist(object obj)
        {
           

                var CurrentWindow = new RegistrWindow();
                CurrentWindow.ShowDialog();
                CanButton = true;
        
            

        }
    }
}
