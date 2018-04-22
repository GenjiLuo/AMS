﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.poco
{
    public class Organization
    {
        public Organization()
        {
            User = new HashSet<User>();
            SubOrg = new HashSet<Organization>();
        }
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual ICollection<Organization> SubOrg { get; set; }
        public virtual Organization ParentOrg { get; set; }
    }
}
