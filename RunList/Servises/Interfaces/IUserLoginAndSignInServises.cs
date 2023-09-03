using RunList.Models.DTO_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Servises.Interfaces
{
    internal interface IUserLoginAndSignInServises
    {
       public Task<bool> SignIn(DTOUser user);
       public Task<bool> LogIn(DTOUser user);
        public void SaveDateUser(DTOUser user);
    }
}
