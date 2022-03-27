using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactCodeChallenges.Models
{
    public class Response<T>
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public T ResponseObject { get; set; }


        public static Response<T> GetSuccessfulResponse(T responseObject)
        {
            return new Response<T>
            {
                HasError = false,
                ResponseObject = responseObject
            };
        }
        public static Response<T> GetErrorResponse(string errorMessage = null)
        {
            return new Response<T>
            {
                HasError = true,
                ErrorMessage = errorMessage,
            };
        }
    }
}
