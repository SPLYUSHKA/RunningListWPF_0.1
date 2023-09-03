using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using System.Threading.Tasks;

namespace RunList.Servises.Base
{

    internal static class ClientHttp
    {
        static public HttpClient client = new HttpClient();
        static public string BaseUrl = $"http://runninglist.310ultraects.keenetic.pro";
        static public string Login = BaseUrl + "/api/User/login";
        static public string Registration = BaseUrl + "/api/User/registration";
        static public string AllTask = BaseUrl + "/api/RunningList/GetAllTask";
        static public string AllTaskCompleted = BaseUrl + "/api/RunningList/GetAllTaskCompledet";
        static public string AllTaskWeekNumber = BaseUrl + "/api/RunningList/GetAllTaskWeekNumber";
        static public string AllTaskWeekNumberCompleted = BaseUrl + "/api/RunningList/GetAllTaskWeekNumberCompleted";
        static public string AddTask = BaseUrl + "/api/RunningList/AddTask";
        static public string EditTaskMove = BaseUrl + "/api/RunningList/EditTaskMove";
        static public string EditTaskDiff = BaseUrl + "/api/RunningList/EditTaskDif";
        static public string DeleteTask = BaseUrl + "/api/RunningList/DeleteTask";
        static public string FindTask = BaseUrl + "/api/RunningList/FindTask";
    }
}
