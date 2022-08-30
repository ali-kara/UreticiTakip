using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Results
{
    public class DResult<T>
    {
        public DResult()
        {

        }

        public DResult(T data, string message = "", bool Success = true)
        {
            this.Message = message;
            this.Data = data;
            this.Success = Success;
        }

        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
