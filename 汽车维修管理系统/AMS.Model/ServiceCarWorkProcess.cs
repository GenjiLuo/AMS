namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCarWorkProcess")]
    public partial class ServiceCarWorkProcess
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceCarWorkProcess()
        {
            ServiceCarWorkProcessChanges = new HashSet<ServiceCarWorkProcessChange>();
        }

        public int Id { get; set; }

        public int ServiceCarId { get; set; }

        public int RepairWorkProcessId { get; set; }

        public int ServiceCarRepairItemId { get; set; }

        [Required]
        [StringLength(255)]
        public string ServiceCarRepairItemName { get; set; }

        public int OrderNum { get; set; }

        public int Status { get; set; }

        public int? RepairManId { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }

        public int ReworkTimes { get; set; }

        public int BatchNo { get; set; }

        public virtual RepairWorkProcess RepairWorkProcess { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        public virtual ServiceCarRepairItem ServiceCarRepairItem { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarWorkProcessChange> ServiceCarWorkProcessChanges { get; set; }
    }
}
