using System;
using Microsoft.AspNetCore.Mvc;

namespace capgemini_test.src.Core.CrossCutting.Exceptions
{
    public class HttpResponseException : Exception
    {
        private bool ehJson = false;
        public int Status { get; }        
        public string[] Linhas { get; }

        private HttpResponseException(int status, params string[] linhas)
        {
            Status = status;
            Linhas = linhas;
        }

        public static HttpResponseException BadRequest(params string[] linhas)
        {
            return Create(400, linhas);
        }

        public static HttpResponseException NotFound(params string[] linhas)
        {
            return Create(404, linhas);
        }

        public static HttpResponseException FromJson(string json, int status)
        {
            var result = Create(status, json);
            result.ehJson = true;
            return result;
        }

        public IActionResult ToResult()
        {
            IActionResult result;
            if (ehJson)
            {
                result = new ContentResult()
                {
                    Content = string.Join("", Linhas),
                    StatusCode = Status,
                    ContentType = "application/problem+json"
                };
            }
            else
            {
                result = new JsonResult(new { erros = Linhas })
                {
                    StatusCode = Status,
                    ContentType = "application/problem+json"
                };
            }

            return result;
        }

        private static HttpResponseException Create(int status, params string[] linhas)
        {
            return new HttpResponseException(status, linhas);
        }
    }
}