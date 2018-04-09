namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EhrSetting")]
    public partial class EhrSetting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EhrSetting()
        {
            EhrPushUrls = new HashSet<EhrPushUrl>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganizationId { get; set; }

        public bool HasEnableEhr { get; set; }

        [StringLength(255)]
        public string EhrCompanyName { get; set; }

        [StringLength(255)]
        public string EhrUserName { get; set; }

        [StringLength(255)]
        public string EhrUserPwd { get; set; }

        public int EhrSetKey { get; set; }

        public int ProvinceId { get; set; }

        [Required]
        [StringLength(255)]
        public string ProvinceName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EhrPushUrl> EhrPushUrls { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
