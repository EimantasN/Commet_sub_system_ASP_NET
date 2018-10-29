using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T120B143.Models
{
    public class HttpError
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }

        public HttpError(string msg)
        {
            Message = msg;
            Time = DateTime.Now;
        }
    }
}
