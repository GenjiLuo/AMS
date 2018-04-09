namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsUniqueSN")]
    public partial class PartsUniqueSN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartsUniqueSN()
        {
            PartsInventoryChangeRefSNs = new HashSet<PartsInventoryChangeRefSN>();
            PartsInventoryRefSNs = new HashSet<PartsInventoryRefSN>();
        }

        public int Id { get; set; }

        public int ShopId { get; set; }

        public int PartsDictionaryId { get; set; }

        [StringLength(200)]
        public string SerialNum { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryChangeRefSN> PartsInventoryChangeRefSNs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRefSN> PartsInventoryRefSNs { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
