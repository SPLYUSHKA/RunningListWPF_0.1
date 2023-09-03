using RunList.Models;
using RunList.Models.DTO_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Servises.Interfaces
{
    internal interface IUserDialog
    {
        public bool Edit(UserTask task,ref int  operations,ref Difficulty NewDif );
        public bool Add(UserTaskDTO task,ref bool template);
 
    }
}
