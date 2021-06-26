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
    public class AccountRepository : GeneralRepository<Account, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        //private readonly MyContext myContext;

        public AccountRepository(Address address, string request = "account/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }

        public async Task<List<RegisterVM>> GetAllProfile()
        {
            List<RegisterVM> entities = new List<RegisterVM>();
            using (var response = await httpClient.GetAsync(request + "GetAllProfile"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterVM>>(apiResponse);
            }
            return entities;
            /// isi codingan kalian disini
        }
        public async Task<RegisterVM> GetProfileById(int nip)
        {
            RegisterVM entity = new RegisterVM();
            using (var response = await httpClient.GetAsync(request + "GetProfileById/" + nip))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<RegisterVM>(apiResponse);
            }
            return entity;
            /// isi codingan kalian disini
        }
    }
}