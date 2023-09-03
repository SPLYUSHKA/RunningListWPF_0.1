using Microsoft.Extensions.DependencyInjection;
using RunList.Servises;
using RunList.Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Servises
{
    static class ServicesRegistator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
         .AddTransient<IUserLoginAndSignInServises,UserLoginAndSignInServises>()
         .AddTransient<IUserTaskServises,UserTaskServises>()
         .AddTransient<IUserDialog, UserDialog>()
         .AddTransient<IDialogWithHistory,DialogWithHistory>()
         .AddTransient<IUserDialogMessage,WindowUserDialogServises>()
       ;
    }
}
