using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 汽车维修管理系统.Models
{
    public class LoginVM
    {
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { set; get; }
    }
}