using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class ApiResponse
    {
        public bool IsCompleted { get; set; }
        public object Result { get; set; }
    }
}
