using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Servises.Interfaces
{
    internal interface IDialogWithHistory
    {
        public bool ShowHistory(int weekNumber);
    }
}
