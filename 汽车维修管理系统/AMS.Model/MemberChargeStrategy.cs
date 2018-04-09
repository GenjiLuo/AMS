namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberChargeStrategy")]
    public partial class MemberChargeStrategy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberChargeStrategy()
        {
            MemberCardCharges = new HashSet<MemberCardCharge>();
            MemberCardChargeOrders = new HashSet<MemberCardChargeOrder>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(255)]
        public string ActivityName { get; set; }

        public decimal? RechargeAmount { get; set; }

        public decimal? GiftAmount { get; set; }

        public DateTime? Deadline { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardCharge> MemberCardCharges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardChargeOrder> MemberCardChargeOrders { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
