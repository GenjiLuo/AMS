namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsPriceChange")]
    public partial class PartsPriceChange
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartsPriceChange()
        {
            PartsPriceChangeDetails = new HashSet<PartsPriceChangeDetail>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string BillNo { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public int? ConfirmUserId { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public int? RequestUserId { get; set; }

        public DateTime? RequestDate { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsPriceChangeDetail> PartsPriceChangeDetails { get; set; }
    }
}
