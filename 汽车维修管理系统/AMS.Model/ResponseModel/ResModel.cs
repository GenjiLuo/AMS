using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.ResponseModel
{
    public class ResModel
    {
        public string Msg { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }

        public ResModel(string msg, bool success, object data)
        {
            Msg = msg;
            Success = success;
            Data = data;

        }
        public ResModel()
        {


        }
    }
}
