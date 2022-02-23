using System;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.Phone;
using Domain.DTOs.Response;
using RestSharp;
using Newtonsoft.Json;
using Domain.DTOs.Errors;

namespace Core.Logic.Application
{
    public class PhoneRepository : Requestor, IGenericRepositoryAPP<PhoneInput>
    {

        public async Task<ApiResponse> Add(PhoneInput dto, int? studentId = null)
        {
            string endpoint = $"Phone/{studentId}";
            var result = await Execute(endpoint, dto, Method.POST);
            return GetResult(result, false);
        }
        public async Task<ApiResponse> Update(int id, PhoneInput dto)
        {
            string endpoint = $"Phone/{id}";
            var result = await Execute(endpoint, dto, Method.PUT);
            return GetResult(result, false);
        }
        public async Task<ApiResponse> Delete(int id)
        {
            string endpoint = $"Phone/{id}";
            var result = await Execute(endpoint, null, Method.DELETE);
            return GetResult(result, false);
        }
        public async Task<ApiResponse> GetAllAsync(int? studentId = null)
        {
            string endpoint = $"Phone/Student/{studentId}";
            var result = await Execute(endpoint, null, Method.GET);
            return GetResult(result, true);
        }
        public async Task<ApiResponse> GetByIdAsync(int id)
        {
            string endpoint = $"Phone/{id}";
            var result = await Execute(endpoint, null, Method.GET);
            return GetResult(result, false);
        }



        private ApiResponse GetResult(IRestResponse restResponse, bool isList)
        {
            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (isList)
                {
                    var output = JsonConvert.DeserializeObject<List<PhoneOutput>>(restResponse.Content);
                    return new ApiResponse { IsCompleted = true, Result = output };
                }
                else
                {
                    var output = JsonConvert.DeserializeObject<PhoneOutput>(restResponse.Content);
                    return new ApiResponse { IsCompleted = true, Result = output };
                }
            }
            else
            {
                var output = JsonConvert.DeserializeObject<CodeErrorResponse>(restResponse.Content);
                return new ApiResponse { IsCompleted = false, Result = output };
            }
        }
    }
}
