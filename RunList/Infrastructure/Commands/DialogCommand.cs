using RunList.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Infrastructure.Commands
{
    class DialogCommand : Command
    {
        public event EventHandler CanExetureChanged;
        public bool DialogResult { get; set; }
        public override bool CanExecute(object? parameter) => App.CurrentWindow != null;

        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;
            var window = App.CurrentWindow;
            var dialog_result = DialogResult;
            if (parameter != null)
            {
                dialog_result = (bool)Convert.ChangeType(parameter, typeof(bool));
            }
            window.DialogResult = dialog_result;
            window.Close();
        }
    }
}
