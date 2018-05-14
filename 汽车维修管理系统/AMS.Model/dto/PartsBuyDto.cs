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
            PartsIns = new List<PartsInDto>();
        }
        public string SupplierName { get; set; }
        public Guid SupplierId { get; set; }
        public string OrderNo { get; set; }
        public string BillNo { get; set; } 
        public PartsBuyState PartsBuyState { get; set; }
        public string ApplyUser { get; set; }
        public string CheckUser { get; set; }
        public DateTime? OperationTime { get; set; }

        public int? CategoryCount => PartsIns.Count;

        public int TotalPartsCount
        {
            get
            {
                var totalPartsCount = 0;
                foreach (var item in PartsIns)
                {
                    totalPartsCount += item.Count;
                }

                return totalPartsCount;
            }
        }

        public decimal TotalMoney
        {
            get { return PartsIns.Sum(i => i.SupplierPrice * i.Count); }
        }

        public decimal ReadyToPay { get; set; }

        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public List<PartsInDto> PartsIns { get; set; }
    }
}
