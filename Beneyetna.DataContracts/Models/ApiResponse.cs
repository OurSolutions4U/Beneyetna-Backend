using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DataContracts.Models
{
    public class ApiResponse
    {
        public string Message { set; get; }
        public int Code { set; get; }
        public string Result { set; get; }
        public int Count { set; get; }
        public object Data { set; get; }
        public int TotalCount { set; get; }


        public ApiResponse(string message, int code, object data, int count)
        {
            Message = message;
            Code = code;
            Data = data;
            Count = count;
            Result = code == 200 ? "Success" : "Failed";
            TotalCount = count;
        }
    }
}
