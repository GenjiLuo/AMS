namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FileResource")]
    public partial class FileResource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FileResource()
        {
            CustomerDistributionActivities = new HashSet<CustomerDistributionActivity>();
            CustomerDistributionActivities1 = new HashSet<CustomerDistributionActivity>();
            CustomerDistributionActivityChanges = new HashSet<CustomerDistributionActivityChange>();
            CustomerDistributionActivityChanges1 = new HashSet<CustomerDistributionActivityChange>();
            FileBrowsers = new HashSet<FileBrowser>();
            FilesAdvertisements = new HashSet<FilesAdvertisement>();
            FilesBanners = new HashSet<FilesBanner>();
            FilesCars = new HashSet<FilesCar>();
            FilesMainMenus = new HashSet<FilesMainMenu>();
            FilesPackages = new HashSet<FilesPackage>();
            FilesServiceCars = new HashSet<FilesServiceCar>();
        }

        public int Id { get; set; }

        public Guid Uid { get; set; }

        [Required]
        [StringLength(512)]
        public string Domain { get; set; }

        [Required]
        [StringLength(512)]
        public string Endpoint { get; set; }

        [Required]
        [StringLength(512)]
        public string Bucket { get; set; }

        [Required]
        [StringLength(512)]
        public string OriginalFileName { get; set; }

        [Required]
        [StringLength(512)]
        public string NewFileName { get; set; }

        [Required]
        [StringLength(1024)]
        public string Key { get; set; }

        [Required]
        [StringLength(1024)]
        public string Url { get; set; }

        public double Size { get; set; }

        [Required]
        [StringLength(50)]
        public string Extension { get; set; }

        [Required]
        [StringLength(50)]
        public string ContentType { get; set; }

        public double ContentLength { get; set; }

        [Required]
        [StringLength(128)]
        public string Etag { get; set; }

        public bool HasSubmit { get; set; }

        public DateTime? SubmitTime { get; set; }

        public bool HasSync { get; set; }

        public DateTime? SyncTime { get; set; }

        public bool HasDelete { get; set; }

        public DateTime? DeleteTime { get; set; }

        public bool HasAudit { get; set; }

        public DateTime? AuditTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerDistributionActivity> CustomerDistributionActivities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerDistributionActivity> CustomerDistributionActivities1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerDistributionActivityChange> CustomerDistributionActivityChanges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerDistributionActivityChange> CustomerDistributionActivityChanges1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileBrowser> FileBrowsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesAdvertisement> FilesAdvertisements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesBanner> FilesBanners { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesCar> FilesCars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesMainMenu> FilesMainMenus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesPackage> FilesPackages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesServiceCar> FilesServiceCars { get; set; }
    }
}
