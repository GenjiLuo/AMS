namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdvertisementBanner")]
    public partial class AdvertisementBanner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdvertisementBanner()
        {
            FilesBanners = new HashSet<FilesBanner>();
        }

        public int Id { get; set; }

        public int OrganizationId { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Ellipsis { get; set; }

        public int Status { get; set; }

        public int Sequence { get; set; }

        public int PresentationMode { get; set; }

        [StringLength(4000)]
        public string PurchaseNotes { get; set; }

        public int? ProjectType { get; set; }

        public int? ProjectId { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesBanner> FilesBanners { get; set; }
    }
}
