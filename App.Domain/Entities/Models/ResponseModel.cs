using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class ResponseModel
    {
        public string Message { get; set; } = "Message not set";
        public int StatusCode { get; set; } = 200;
        public bool IsSuccess { get; set; } = false;
    }
}
