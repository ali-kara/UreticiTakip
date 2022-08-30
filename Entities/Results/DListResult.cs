using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Results
{
    public class DListResult<T>
    {
        public DListResult()
        {

        }
        public DListResult(List<T> data, string message, bool Success = true)
        {
            this.Message = message;
            this.Data = data;
            this.Success = Success;
        }

        public string Message { get; set; }
        public bool Success { get; set; } = true;
        public List<T> Data { get; set; }

    }
}
