namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DailyFinanceItem")]
    public partial class DailyFinanceItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DailyFinanceItem()
        {
            DailyFinanceDetails = new HashSet<DailyFinanceDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? Type { get; set; }

        [StringLength(250)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(50)]
        public string NamePinYin { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyFinanceDetail> DailyFinanceDetails { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
