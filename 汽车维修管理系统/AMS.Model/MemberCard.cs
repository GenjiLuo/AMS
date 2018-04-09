namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberCard")]
    public partial class MemberCard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberCard()
        {
            MemberCardCharges = new HashSet<MemberCardCharge>();
            MemberCardChargeOrders = new HashSet<MemberCardChargeOrder>();
            MemberCardConsumes = new HashSet<MemberCardConsume>();
            MemberCardScores = new HashSet<MemberCardScore>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string CardNo { get; set; }

        public int? MemberTypeId { get; set; }

        public double? CurrentScore { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ExpireDate { get; set; }

        public double? DiscountRate { get; set; }

        public decimal CurrentMoney { get; set; }

        public decimal CurrentEmoney { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public decimal NeedConfirmedMoney { get; set; }

        public decimal NeedConfirmedEMoney { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual MemberType MemberType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardCharge> MemberCardCharges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardChargeOrder> MemberCardChargeOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardConsume> MemberCardConsumes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardScore> MemberCardScores { get; set; }
    }
}
