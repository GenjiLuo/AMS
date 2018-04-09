namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserDefinedMainMenu")]
    public partial class UserDefinedMainMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDefinedMainMenu()
        {
            FilesMainMenus = new HashSet<FilesMainMenu>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string PinYin { get; set; }

        [Required]
        [StringLength(255)]
        public string PictureURL { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [StringLength(255)]
        public string URL { get; set; }

        public int OrderNum { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesMainMenu> FilesMainMenus { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
