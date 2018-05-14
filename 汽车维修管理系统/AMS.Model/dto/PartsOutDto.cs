using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class PartsOutDto : BaseModel
    {
        public Guid PartsId { get; set; }
        public Guid PartsReturnId { get; set; }
        public string PartsName  { get; set; }
        public string PartsCode { get; set; }
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int Count { get; set; }
    }
}
