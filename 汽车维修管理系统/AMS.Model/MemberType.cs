namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberType")]
    public partial class MemberType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberType()
        {
            MemberCards = new HashSet<MemberCard>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(400)]
        public string Remarks { get; set; }

        public double? WorkloadDiscount { get; set; }

        public double? MaterialDiscount { get; set; }

        public double? ManageDiscount { get; set; }

        public int? CreateBy { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public decimal? NeedMoney { get; set; }

        [StringLength(255)]
        public string PromoteMode { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public bool ShowOnWechat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCard> MemberCards { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
