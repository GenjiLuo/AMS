using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.Enum;

namespace AMS.Model.dto
{
    public class PartsBuyDto : BaseDto
    {
        public PartsBuyDto()
        {
            Parts=new List<PartsDto>();
        }
        public string SupplierName { get; set; }
        public Guid SupplierId { get; set; }
        public string OrderNo { get; set; }
        public string BillNo { get; set; } 
        public new PartsBuyState State { get; set; }
        public string ApplyUser { get; set; }
        public string CheckUser { get; set; }
        public DateTime? OperationTime { get; set; }
        public int? CategoryCount { get; set; }

        public int TotalPartsCount => Parts.Count;

        public decimal TotalMoney
        {
            get { return Parts.Sum(i => i.Price * i.Count); }
        }

        public decimal ReadyToPay { get; set; }

        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public List<PartsDto> Parts { get; set; }
    }
}
