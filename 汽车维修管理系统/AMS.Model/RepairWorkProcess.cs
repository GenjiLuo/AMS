namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RepairWorkProcess")]
    public partial class RepairWorkProcess
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RepairWorkProcess()
        {
            ServiceCarWorkProcesses = new HashSet<ServiceCarWorkProcess>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string PinYin { get; set; }

        public int OrderNum { get; set; }

        public int? RepairItemTypeId { get; set; }

        public int Status { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual RepairItemType RepairItemType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarWorkProcess> ServiceCarWorkProcesses { get; set; }
    }
}
