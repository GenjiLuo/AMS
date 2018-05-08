using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using Newtonsoft.Json;

namespace AMS.Model.poco
{
    public class Warehouse : BaseModel
    {
        public bool IsDefault { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
    }
}
