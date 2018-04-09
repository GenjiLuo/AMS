namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCarPlannedFinishTimeChangeHistory")]
    public partial class ServiceCarPlannedFinishTimeChangeHistory
    {
        public int Id { get; set; }

        public int? ServiceCarId { get; set; }

        public DateTime ServiceCarPlanedFinishTime { get; set; }

        [Required]
        [StringLength(200)]
        public string Reason { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
