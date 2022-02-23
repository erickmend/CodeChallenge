using Domain.DTOs.Errors;
using Domain.DTOs.Response;
using Domain.DTOs.Student;
using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic.Application
{
    public class StudentRepository : Requestor, IGenericRepositoryAPP<StudentInput>
    {

        public async Task<ApiResponse> Add(StudentInput dto, int? studentId = null)
        {
            string endpoint = $"Student/";
            var result = await Execute(endpoint, dto, Method.POST);
            return GetResult(result,false);
        }
        public async Task<ApiResponse> Update(int id, StudentInput dto)
        {
            string endpoint = $"Student/{id}";
            var result = await Execute(endpoint, dto, Method.PUT);
            return GetResult(result,false);
        }
        public async Task<ApiResponse> Delete(int id)
        {
            string endpoint = $"Student/{id}";
            var result = await Execute(endpoint, null , Method.DELETE);
            return GetResult(result,false);
        }
        public async Task<ApiResponse> GetAllAsync(int? studentId = null)
        {
            string endpoint = $"Student/";
            var result = await Execute(endpoint, null, Method.GET);
            return GetResult(result,true);
        }
        public async Task<ApiResponse> GetByIdAsync(int id)
        {
            string endpoint = $"Student/{id}";
            var result = await Execute(endpoint,null, Method.GET);
            return GetResult(result, false);
        }




        private ApiResponse GetResult(IRestResponse restResponse , bool isList)
        {
            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (isList)
                {
                    var output = JsonConvert.DeserializeObject<List<StudentOutput>>(restResponse.Content);
                    return new ApiResponse { IsCompleted = true, Result = output };
                }
                else
                {
                    var output = JsonConvert.DeserializeObject<StudentOutput>(restResponse.Content);
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
