﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.dto
{
    public class UserDto:BaseDto
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public Guid OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgHope { get; set; }
    }
}
