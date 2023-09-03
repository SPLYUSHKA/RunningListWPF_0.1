using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.ModelViews
{
    static class ModelViewRegistrator
    {
        public static IServiceCollection AddViewModel(this IServiceCollection services) => services
          .AddSingleton<MainWindowViewModel>()
          .AddSingleton<NavigateWindowVM>()
          .AddSingleton<TaskTheCurrertNumberVM>()
          .AddSingleton<CalendarWeekNumbersVM>()
           .AddSingleton<RegistrViewModel>()
       ;
    }
}
