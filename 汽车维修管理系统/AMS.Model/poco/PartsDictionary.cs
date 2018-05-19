using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;

namespace AMS.Model.poco
{
    public class PartsDictionary : BaseModel
    {
        public PartsDictionary()
        {
            PartsDictionarySuitedCarModel=new HashSet<PartsDictionarySuitedCarModel>();
            PartsIns=new HashSet<PartsIn>();
        }
        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Code { get; set; }
        public Guid PartsTypeId { get; set; }
        [ForeignKey("PartsTypeId")]
        public virtual PartsType PartsType { get; set; }

        public string MeasurementUnit { get; set; }

        public virtual ICollection<PartsDictionarySuitedCarModel> PartsDictionarySuitedCarModel { get; set; }

        public decimal SupplierPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal TradePrice { get; set; }
        public decimal AdjustPrice { get; set; }
        public decimal ClaimPrice { get; set; }

        public int? HighestAlertCount { get; set; }
        public int? LowestAlertCount { get; set; }

        public string BrandName { get; set; }
        public string Specifications { get; set; }
        public string ProducedAddress { get; set; }
        public string Label { get; set; }

        public virtual ICollection<PartsIn> PartsIns { get; set; }
    }
}
