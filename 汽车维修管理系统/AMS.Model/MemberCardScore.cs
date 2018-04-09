namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberCardScore")]
    public partial class MemberCardScore
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberCardScore()
        {
            FinanceBusinessRecords = new HashSet<FinanceBusinessRecord>();
            MemberCardCharges = new HashSet<MemberCardCharge>();
            MemberCardConsumes = new HashSet<MemberCardConsume>();
        }

        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int MemberCardId { get; set; }

        public int ChangeType { get; set; }

        public double Score { get; set; }

        public double CurrentScore { get; set; }

        public int? OperatorId { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinanceBusinessRecord> FinanceBusinessRecords { get; set; }

        public virtual MemberCard MemberCard { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardCharge> MemberCardCharges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardConsume> MemberCardConsumes { get; set; }

        public virtual User User { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
