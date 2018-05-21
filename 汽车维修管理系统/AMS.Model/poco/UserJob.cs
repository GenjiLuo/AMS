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
    public class UserJob : BaseModel
    {
        public Guid JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
