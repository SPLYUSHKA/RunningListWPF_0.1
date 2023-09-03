using RunList.Infrastructure.Commands;
using RunList.Models.DTO_Model;
using RunList.ModelViews.Base;
using RunList.Servises;
using RunList.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RunList.ModelViews
{
    internal class RegistrViewModel : ViewModel
    {
        private readonly UserLoginAndSignInServises users = new UserLoginAndSignInServises();
        private readonly WindowUserDialogServises dialogServises = new WindowUserDialogServises();
        public Cursor Cursor { get; set; }
        public RegistrViewModel()
        {

            var uri = new Uri("pack://application:,,,/Images/Cursors/PawLoading.ani");
            var stream = Application.GetResourceStream(uri).Stream;
            var cursor = new Cursor(stream);
            Cursor = cursor;
        }
        #region Заголовок окна 
        private string _title = "Окно регистрации";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region Свойства для Login


        private string? _username;

        public string? UserName
        {
            get => _username;
            set => Set(ref _username, value);
        }


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
        private string? _passwordReapit;

        public string? PasswordReapit
        {
            get => _passwordReapit;
            set => Set(ref _passwordReapit, value);
        }
        public bool _isRegistr = false;

        private ICommand _WindowClose;
        public ICommand WindowClose => _WindowClose ?? new LamdaCommand(o => ((Window)o).Close(), CanWindowClose);
        private bool CanWindowClose(object arg) => true;


        private async Task GoAsync()
        {
            if (EmailUserLog != null && Password != null && PasswordReapit != null && UserName != null)
            {
                if (PasswordReapit == Password)
                {
                    string email = EmailUserLog;
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);
                    if (match.Success)
                    {
                        regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{9,}$");
                        match = regex.Match(Password);
                        if (match.Success)
                        {
                            DTOUser user = new DTOUser() { name = UserName, email = EmailUserLog, password = Password };
                            _isRegistr = await users.SignIn(user);
                        }
                        else 
                        {
                            dialogServises.ShowError("Некорректный пароль.Пароль должен содержать в себе буквы латинского алфавита заглавные и прописные, содержать хотя бы одну цифру и не должен содержать спец. символы", "Ошибка");
                        }
                    }
                    else
                    {
                        dialogServises.ShowError("Некорректная почта","Ошибка");
                    }
                  
                }
                else 
                {
                    _isRegistr = false;
                    dialogServises.ShowWarning("Пароли не совпадают", "Предупреждение");
                }

            }
            else
            {
                _isRegistr = false;
                dialogServises.ShowError("Все поля должны быть заполенны","Ошибка");
            }

        }

        private bool _showcanbutton = true;
        public bool CanButton
        {
            get { return _showcanbutton; }
            set { _showcanbutton = value; }
        }

        private ICommand _registr;
        public ICommand Regist => _registr ?? new LamdaCommand(RegistMethod, CanRegistr);
        private bool CanRegistr(object arg) => CanButton;

        public object CurrentModel { get; private set; }

        public bool _isGoEnter = false;

        private async void RegistMethod(object obj)
        {
            CanButton = false;
            await GoAsync();

            if (_isRegistr == true)
            {

                dialogServises.ShowInformation("Регистрация в систему прошла успешно.Вернитесь на окно логина", "Регистрация успешна");
                CanButton = false;
            }
            else
            {

                if (_isRegistr == true)
                {
                    dialogServises.ShowInformation("Регистрация в систему прошла успешно.Вернитесь на окно логина", "Регистрация успешна");
                    CanButton = false;
                }
                else
                {
                    dialogServises.ShowInformation("При регистрации в систему произошла ошибка", "Ошибка регистрации");
                    CanButton = true;
                }
            }
            
        }



        #endregion
    }
}
