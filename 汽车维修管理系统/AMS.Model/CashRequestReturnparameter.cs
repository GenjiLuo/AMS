namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CashRequestReturnparameter")]
    public partial class CashRequestReturnparameter
    {
        public int Id { get; set; }

        public int CashRequestRequestparameterId { get; set; }

        [Required]
        [StringLength(255)]
        public string ReturnCode { get; set; }

        [Required]
        [StringLength(500)]
        public string ReturnMsg { get; set; }

        [Required]
        [StringLength(255)]
        public string MchAppid { get; set; }

        [Required]
        [StringLength(255)]
        public string Mchid { get; set; }

        [Required]
        [StringLength(255)]
        public string DeviceInfo { get; set; }

        [Required]
        [StringLength(255)]
        public string NonceStr { get; set; }

        [Required]
        [StringLength(255)]
        public string ResultCode { get; set; }

        [Required]
        [StringLength(255)]
        public string ErrCode { get; set; }

        [Required]
        [StringLength(255)]
        public string ErrCodeDes { get; set; }

        [Required]
        [StringLength(255)]
        public string PartnerTradeNo { get; set; }

        [Required]
        [StringLength(255)]
        public string PaymentNo { get; set; }

        [Required]
        [StringLength(255)]
        public string PaymentTime { get; set; }

        public virtual CashRequestRequestparameter CashRequestRequestparameter { get; set; }
    }
}
