using RunList.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Infrastructure.Commands
{
    internal class LamdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canexecute;

        public LamdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canexecute = CanExecute;
        }
        public override bool CanExecute(object? parameter) => _canexecute?.Invoke(parameter) ?? true;

        public override void Execute(object? parameter) => _execute(parameter);

    }
}
