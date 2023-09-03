using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunList.ModelViews
{
    class ModelViewLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
        
        public NavigateWindowVM NavigateWindowVM => App.Services.GetRequiredService<NavigateWindowVM>();

        public TaskTheCurrertNumberVM TaskTheCurrertNumberVMt => App.Services.GetRequiredService<TaskTheCurrertNumberVM>();

        public EditUserTaskVM EditUserTaskVM => App.Services.GetRequiredService<EditUserTaskVM>();

        public AddUserTask AddUserTask => App.Services.GetRequiredService<AddUserTask>();
        public CalendarWeekNumbersVM CalendarWeekNumbersVM => App.Services.GetRequiredService<CalendarWeekNumbersVM>();

        public WindowHistoryTasksTheCurrentWeekVM windowHistoryTasksTheCurrentWeekVM => App.Services.GetRequiredService<WindowHistoryTasksTheCurrentWeekVM>();

        public RegistrViewModel RegistrViewModel => App.Services.GetRequiredService<RegistrViewModel>();
    }
}

