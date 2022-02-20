using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Errors
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusCode, string spanish = null, string english = null)
        {
            StatusCode = statusCode;
            ErrorMessageSpanish = spanish ?? GetDefaultMessageStatusCodeSpanish(statusCode);
            ErrorMessageEnglish = english ?? GetDefaultMessageStatusCodeEnglish(statusCode);
        }

        public int StatusCode { get; set; }
        public string ErrorMessageSpanish { get; set; }
        public string ErrorMessageEnglish { get; set; }

        private string GetDefaultMessageStatusCodeSpanish(int statusCode)
        {
            return statusCode switch
            {
                400 => "El Request enviado tiene errores",
                401 => "No tienes autorización para este recurso",
                404 => "El recurso no se encontró",
                500 => "Se produjo errores en el servidor",
                _ => throw new System.NotImplementedException()
            };
        }

        private string GetDefaultMessageStatusCodeEnglish(int statusCode)
        {
            return statusCode switch
            {
                400 => "El Request has errors",
                401 => "You dont have access",
                404 => "The resource does not exist",
                500 => "There are some errors in the server",
                _ => throw new System.NotImplementedException()
            };
        }
    }
}
