using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class PartsTypeDto : BaseDto
    {
        public PartsTypeDto()
        {
            SubPartsType = new List<PartsType>();
        }

        public Guid? ParentId { get; set; }
        public string ParentName { get; set; }
        public List<PartsType> SubPartsType { get; set; }
    }
}
