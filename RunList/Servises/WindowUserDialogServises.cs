using Microsoft.VisualBasic;
using RunList.Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RunList.Servises
{
    internal class WindowUserDialogServises : IUserDialogMessage
    {
        public bool Confirm(string Message, string Caption, bool Exclamation = false)=>
        
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.YesNo,
                Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
                == MessageBoxResult.Yes;


        public void ShowError(string Message, string Caption) =>
            MessageBox.Show(Message,Caption,MessageBoxButton.OK,MessageBoxImage.Error);
      

        public void ShowInformation(string Information, string Caprion)=>
           MessageBox.Show(Information, Caprion, MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string Message, string Caption)=>
       
            MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);
       
    }
}
