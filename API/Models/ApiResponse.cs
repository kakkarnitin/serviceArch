using System;
namespace API.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Result = 0; // Success
        }
        public int Result { get; set; }

        public string Message { get; set; }
    }
}
