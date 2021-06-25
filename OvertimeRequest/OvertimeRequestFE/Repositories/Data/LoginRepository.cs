using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OvertimeRequest.Models;
using OvertimeRequest.ViewModels;
using OvertimeRequestFE.Base;
using OvertimeRequestFE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OvertimeRequestFE.Repositories.Data
{
    public class LoginRepository : GeneralRepository<Account, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        public LoginRepository(Address address, string request = "Account/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public async Task<JWTokenVM> Auth(LoginVM loginVM)
        {
            JWTokenVM token = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(request + "login", content);

            if (result.IsSuccessStatusCode)
            {
                string apiResponse = await result.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<JWTokenVM>(apiResponse);
            }
            return token;
        }
    }
}