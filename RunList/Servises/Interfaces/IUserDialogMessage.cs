using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Servises.Interfaces
{
    internal interface IUserDialogMessage
    {
        void ShowWarning(string Message, string Caption);
        void ShowInformation(string Information, string Caprion);
        void ShowError(string Message, string Caption);
        bool Confirm(string Message, string Caption, bool Exclamation = false);
    }
}
