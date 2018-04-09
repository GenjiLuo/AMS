namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CashRequestRequestparameter")]
    public partial class CashRequestRequestparameter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CashRequestRequestparameter()
        {
            CashRequestReturnparameters = new HashSet<CashRequestReturnparameter>();
        }

        public int Id { get; set; }

        public int CustomerCashRequestId { get; set; }

        [Required]
        [StringLength(255)]
        public string MchAppid { get; set; }

        [Required]
        [StringLength(500)]
        public string Mchid { get; set; }

        [Required]
        [StringLength(255)]
        public string DeviceInfo { get; set; }

        [Required]
        [StringLength(255)]
        public string NonceStr { get; set; }

        [Required]
        [StringLength(255)]
        public string Sign { get; set; }

        [Required]
        [StringLength(255)]
        public string PartnerTradeNo { get; set; }

        [Required]
        [StringLength(255)]
        public string Openid { get; set; }

        [Required]
        [StringLength(255)]
        public string CheckName { get; set; }

        [Required]
        [StringLength(255)]
        public string ReUserName { get; set; }

        public int Amount { get; set; }

        [Required]
        [StringLength(255)]
        public string Desc { get; set; }

        [Required]
        [StringLength(255)]
        public string SpbillCreateIp { get; set; }

        public virtual CustomerCashRequest CustomerCashRequest { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CashRequestReturnparameter> CashRequestReturnparameters { get; set; }
    }
}
