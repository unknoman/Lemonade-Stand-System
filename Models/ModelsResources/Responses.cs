using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsResources
{
    public class Responses<T> 
    {
        public Responses() { }
        public Responses(T Data, string Message) { 
         success= true;
         message = Message;
         data = Data;
        }

        public Responses(string Message)
        {
            success = false;
            message = Message;
        }

        public bool? success { get; set; }

        public string? message { get; set; }

        public List<string>? errors { get; set; }

        public T? data { get; set; }


    }

}
