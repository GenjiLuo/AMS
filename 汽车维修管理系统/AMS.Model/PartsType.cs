namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsType")]
    public partial class PartsType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartsType()
        {
            PartsDictionaries = new HashSet<PartsDictionary>();
            PartsType1 = new HashSet<PartsType>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public int? ParentId { get; set; }

        public bool IsBuidIn { get; set; }

        public decimal? SalesMarkupRatio { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsDictionary> PartsDictionaries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsType> PartsType1 { get; set; }

        public virtual PartsType PartsType2 { get; set; }
    }
}
