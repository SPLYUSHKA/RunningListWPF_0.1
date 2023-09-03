using RunList.Models;
using RunList.Models.DTO_Model;
using RunList.Servises.Base;
using RunList.Servises.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RunList.Servises
{
    internal class UserTaskServises : IUserTaskServises
    {
        public async Task<IEnumerable<UserTask>> GetTaskWeekNumber(int numberweek) 
        {
                     
            UriBuilder builder = new UriBuilder(ClientHttp.AllTaskWeekNumber);
            builder.Query = $"weeknumer={numberweek}";
            var Response = await ClientHttp.client.GetFromJsonAsync<List<UserTask>>(builder.Uri);

            foreach (var userTask in Response)
            {
                userTask.ImagesItem = GetPathImages(userTask);
            }

            return Response;

        }
        public async Task<IEnumerable<UserTask>> GetTaskWeekNumberCompleted(int numberweek) 
        {
            UriBuilder builder = new UriBuilder(ClientHttp.AllTaskWeekNumberCompleted);
            builder.Query = $"weeknumer={numberweek}";
            var Response = await ClientHttp.client.GetFromJsonAsync<List<UserTask>>(builder.Uri);
            foreach (var userTask in Response)
            {
                userTask.ImagesItem = GetPathImages(userTask);
            }
            return Response;

        }
        public async Task EditTaskDiff(UserTask Edittask, Difficulty NewDifficulty) 
        {
            var builder2 = new UriBuilder(ClientHttp.EditTaskDiff);                  
            builder2.Query = $"difficulty={(int)NewDifficulty}";
            using var response2222 = await ClientHttp.client.PostAsJsonAsync(builder2.Uri, Edittask);

        }
        public async Task EditTaskMove(UserTask EditTask, int op) 
        {
            UriBuilder builder = new UriBuilder(ClientHttp.EditTaskMove);
            builder.Query = $"operations={op}";
            using var response = await ClientHttp.client.PostAsJsonAsync(builder.Uri, EditTask);  
        }

        public async Task AddTask(UserTaskDTO userTask, bool template)
        {
           
            UriBuilder builder = new UriBuilder(ClientHttp.AddTask);
            builder.Query = $"templete={template}";
            using var response = await ClientHttp.client.PostAsJsonAsync(builder.Uri, userTask);

        }

        public async Task DeleteTask(UserTask userTask)
        {
            using var response = await ClientHttp.client.PostAsJsonAsync(ClientHttp.DeleteTask, userTask);
            var responseMessage = await response.Content.ReadAsStringAsync();

        }
        public int GetWeekNumber() 
        {
            var dt = DateTime.Now;
            var cal = new GregorianCalendar();
            var weekNumber = cal.GetWeekOfYear(dt, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            return weekNumber;
        }
        
        public string[] GetPathImages(UserTask userTask) 
        {

           

            string[] image = new string[8] { "pack://application:,,,/Images/ImageItem/completed.png", "pack://application:,,,/Images/ImageItem/completed2.png", "pack://application:,,,/Images/ImageItem/empty2.png", "pack://application:,,,/Images/ImageItem/next.png", "pack://application:,,,/Images/ImageItem/taskfire.png", "pack://application:,,,/Images/ImageItem/easy.png", "pack://application:,,,/Images/ImageItem/medium.png", "pack://application:,,,/Images/ImageItem/hard.png" };
            var dayimegemass = new string[7];
            int startday = (int)userTask.StartDay - 1;
            int endday = (int)userTask.ChangeDay - 1;

            if (userTask.StartDay == DayOfWeek.Sunday) 
            {
                endday = 6;
                startday = 6;
            }
          

            if (userTask.ChangeDay == 0)
            {
                endday = 6;
            }
           
            for (int i = 0; i < startday; i++)
            {
                dayimegemass[i] = image[2];

            }
            if (endday <= 6)
            {
                for (int i = endday; i < 7; i++) 
                {
                    dayimegemass[i] = image[2];                
                
                }
            }
            if (startday!= endday)
            {
                if (startday < endday)
                {
                    for (int i = startday; i < endday; i++)
                    {
                        dayimegemass[i] = image[3];

                    }

                }
                else if(startday > endday)
                {
                    for (int i = endday; i < startday; i++) 
                    {
                        dayimegemass[i] = image[3]; // добавить обрат. изображение 
                    }                 
                }

            
            }

            if (userTask.Completed == true)
            {
                dayimegemass[endday] = image[0];

            }
            else
            {  
                if (userTask.Difficulty == Difficulty.Easy)
                {
                    dayimegemass[endday] = image[5];
                }
                else if (userTask.Difficulty == Difficulty.Medium)
                {
                    dayimegemass[endday] = image[6];

                }
                else if (userTask.Difficulty == Difficulty.Hard) 
                {
                    dayimegemass[endday] = image[7];
                }

            }

            return dayimegemass;
        }
        

    }
}
