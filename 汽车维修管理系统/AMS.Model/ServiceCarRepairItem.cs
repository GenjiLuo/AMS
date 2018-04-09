namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCarRepairItem")]
    public partial class ServiceCarRepairItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceCarRepairItem()
        {
            ServiceCarWorkProcesses = new HashSet<ServiceCarWorkProcess>();
        }

        public int Id { get; set; }

        public int ServiceCarId { get; set; }

        public int ServiceAccountTypeId { get; set; }

        public int RepairItemCodeId { get; set; }

        public int? RepairManId { get; set; }

        public double? LaborHours { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? LaborHoursPrice { get; set; }

        public decimal? CheckLaborHoursPrice { get; set; }

        [StringLength(10)]
        public string FlowStatus { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public decimal? PicCount { get; set; }

        public virtual RepairItemCode RepairItemCode { get; set; }

        public virtual ServiceAccountType ServiceAccountType { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarWorkProcess> ServiceCarWorkProcesses { get; set; }
    }
}
