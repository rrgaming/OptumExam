using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Models
{
    public class ApiException : Exception
    {
        public string Error { get; }

        public ApiException(string error, string message) : base(message)
        {
            Error = error;
        }
    }
}
