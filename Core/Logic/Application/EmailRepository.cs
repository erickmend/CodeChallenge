using System;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.Email;
using Domain.DTOs.Response;
using RestSharp;
using Newtonsoft.Json;
using Domain.DTOs.Errors;

namespace Core.Logic.Application
{
    public class EmailRepository : Requestor, IGenericRepositoryAPP<EmailInput>
    {

        public async Task<ApiResponse> Add(EmailInput dto, int? studentId = null)
        {
            string endpoint = $"Email/{studentId}";
            var result = await Execute(endpoint, dto, Method.POST);
            return GetResult(result, false);
        }
        public async Task<ApiResponse> Update(int id, EmailInput dto)
        {
            string endpoint = $"Email/{id}";
            var result = await Execute(endpoint, dto, Method.PUT);
            return GetResult(result, false);
        }
        public async Task<ApiResponse> Delete(int id)
        {
            string endpoint = $"Email/{id}";
            var result = await Execute(endpoint, null, Method.DELETE);
            return GetResult(result, false);
        }
        public async Task<ApiResponse> GetAllAsync(int? studentId = null)
        {
            string endpoint = $"Email/Student/{studentId}";
            var result = await Execute(endpoint, null, Method.GET);
            return GetResult(result, true);
        }
        public async Task<ApiResponse> GetByIdAsync(int id)
        {
            string endpoint = $"Email/{id}";
            var result = await Execute(endpoint, null, Method.GET);
            return GetResult(result, false);
        }




        private ApiResponse GetResult(IRestResponse restResponse, bool isList)
        {
            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (isList)
                {
                    var output = JsonConvert.DeserializeObject<List<EmailOutput>>(restResponse.Content);
                    return new ApiResponse { IsCompleted = true, Result = output };
                }
                else
                {
                    var output = JsonConvert.DeserializeObject<EmailOutput>(restResponse.Content);
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
