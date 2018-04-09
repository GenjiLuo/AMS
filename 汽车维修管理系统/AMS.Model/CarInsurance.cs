namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarInsurance")]
    public partial class CarInsurance
    {
        public int Id { get; set; }

        public decimal? Commercial { get; set; }

        public decimal? Compulsory { get; set; }

        public decimal? Tax { get; set; }

        public decimal? TotalInsuranceCost { get; set; }

        public DateTime? InsuranceStartTime { get; set; }

        public DateTime? InsuranceEndTime { get; set; }

        [StringLength(50)]
        public string InsurancePolicyNo { get; set; }

        [StringLength(100)]
        public string InsuranceCompany { get; set; }

        public int? OutPolicyWay { get; set; }

        public int? PaymentWay { get; set; }

        public DateTime? PaymentTime { get; set; }

        [StringLength(200)]
        public string InsuranceRemark { get; set; }

        public int OrganizationId { get; set; }

        public decimal? AccountAmount { get; set; }

        [StringLength(50)]
        public string BelongPerson { get; set; }

        [StringLength(50)]
        public string Gift { get; set; }

        public decimal? FreeAmount { get; set; }

        [StringLength(50)]
        public string ArchiveNo { get; set; }

        [StringLength(200)]
        public string AttachInfoRemark { get; set; }

        public int CarId { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }

        public bool? IsSysPublic { get; set; }

        public virtual Car Car { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
