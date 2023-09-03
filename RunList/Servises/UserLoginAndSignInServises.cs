using RunList.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using RunList.Models.DTO_Model;
using System.Net.Http.Json;
using RunList.Servises.Base;
using System.Net.Http.Headers;
using RunList.Servises.Interfaces;
using System.IO;

namespace RunList.Servises
{
    internal class UserLoginAndSignInServises : IUserLoginAndSignInServises
    {
     
        public async Task<bool> SignIn(DTOUser user)
        {
            var content = JsonContent.Create(user);
            using var responseMessage = await ClientHttp.client.PostAsync(ClientHttp.Registration, content);
           
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {

              /*  ClientHttp.client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", response.token);*/
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LogIn(DTOUser user)
        {
            var content = JsonContent.Create(user);
            using var responseMessage = await ClientHttp.client.PostAsync(ClientHttp.Login, content);
             var response = await responseMessage.Content.ReadFromJsonAsync<LoginResponse>();
               if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
               { 

                   ClientHttp.client.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", response.token);
                   return true;
               }
               else 
               {
                   return false;
               }
            return true;
        }

        public void SaveDateUser(DTOUser user)
        {
            using (var sr = new StreamWriter("log.txt")) 
            {
                sr.WriteLine(user.email);
                sr.WriteLine(user.password);
                sr.Close();
            }
        }
    }
}
