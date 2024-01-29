using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public  class ServiceResponse
    {
        public bool success { get; set; }

        public string message { get; set; }

        public string errors { get; set; }

        public object data { get; set; }
    }
}
