using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.Enum;

namespace AMS.Model.dto
{
    public class PartsReturnDto : BaseDto
    {
        public PartsReturnDto()
        {
            PartsOuts = new List<PartsOutDto>();
        }
        public string SupplierName { get; set; }
        public Guid SupplierId { get; set; }
        public string OrderNo { get; set; }
        public string BillNo { get; set; } 
        public PartsReturnState PartsReturnState { get; set; }
        public string ApplyUser { get; set; }
        public string CheckUser { get; set; }
        public DateTime? OperationTime { get; set; }

        public int? CategoryCount => PartsOuts.Count;

        public int TotalPartsOutCount
        {
            get
            {
                var totalPartsOutCount = 0;
                foreach (var item in PartsOuts)
                {
                    totalPartsOutCount += item.Count;
                }

                return totalPartsOutCount;
            }
        }
        public List<PartsOutDto> PartsOuts { get; set; }
    }
}
