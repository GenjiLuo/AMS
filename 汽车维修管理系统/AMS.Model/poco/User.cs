﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.poco
{
    public class User:BaseModel
    {
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual Organization Org { get; set; }

    }
}
