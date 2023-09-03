using Nito.AsyncEx;
using RunList.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Infrastructure.Commands
{
    public class AsyncCommand<TResult> : AsyncCommandBase, INotifyPropertyChanged
    {
        private readonly Func<Task<TResult>> _command;
        private MyNotifyTaskCompletion<TResult> _execution;

        public event PropertyChangedEventHandler? PropertyChanged;

        public AsyncCommand(Func<Task<TResult>> command)
        {
            _command = command;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override Task ExecuteAsync(object parameter)
        {
            Execution = new MyNotifyTaskCompletion<TResult>(_command());
            return Execution.TaskCompletion;
        }
      
        public MyNotifyTaskCompletion<TResult> Execution { get; private set; }
    }
}