using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic.Application
{
    public class Requestor
    {
        public static async Task<IRestResponse> Execute(string endPoint, Object dto, RestSharp.Method method)
        {
            var clientRest = new RestClient($"https://localhost:44387/api/{endPoint}");
            var request = new RestRequest(method);
            request.AddHeader("Content-Type", "application/json");
            if (method != RestSharp.Method.GET)
            {
                request.AddJsonBody(dto, "application/json");
            }

            return await clientRest.ExecuteAsync(request);
        }
    }
}
