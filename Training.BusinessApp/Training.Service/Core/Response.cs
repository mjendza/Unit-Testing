using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Service.Core
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public static Response OK => new Response() {Success = true};
        public static Response Error => new Response() { Success = false };
    }
}
