using CarDealer_Cars.Interfaces;
using CarDealer_Cars.Interfaces.DTO;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System;
using Microsoft.AspNetCore.Authentication;

namespace CarDealer_Cars.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserDTO GetUserInfo(int id, string access_token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7172/api/User/" + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" ,access_token);

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                return response.Content.ReadFromJsonAsync<UserDTO>().Result;
                //Make sure to add a reference to System.Net.Http.Formatting.dll
                
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return new UserDTO();
        }

        
    }
    
}
