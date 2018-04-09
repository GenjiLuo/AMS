namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarFaultsMessage")]
    public partial class CarFaultsMessage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarFaultsMessage()
        {
            CarFaultyCarMessageHandleHistories = new HashSet<CarFaultyCarMessageHandleHistory>();
        }

        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int CarId { get; set; }

        public bool HasProcessed { get; set; }

        [StringLength(255)]
        public string DeviceSn { get; set; }

        [StringLength(255)]
        public string ErrorCode { get; set; }

        [StringLength(255)]
        public string ErrorContent { get; set; }

        public DateTime? ErrorDate { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public virtual Car Car { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarFaultyCarMessageHandleHistory> CarFaultyCarMessageHandleHistories { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
