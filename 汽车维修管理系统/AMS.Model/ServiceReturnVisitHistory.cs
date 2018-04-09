namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceReturnVisitHistory")]
    public partial class ServiceReturnVisitHistory
    {
        public int Id { get; set; }

        public int ServiceCarId { get; set; }

        public int? ServiceReturnVisitTypeId { get; set; }

        public int? ServiceReturnEvaluateId { get; set; }

        [StringLength(20)]
        public string ReturnVisitNo { get; set; }

        public DateTime? PlanReturnVisitDate { get; set; }

        public DateTime? NextReturnVisitDate { get; set; }

        public DateTime? ActualReturnVisitDate { get; set; }

        [StringLength(500)]
        public string CustomerAdvice { get; set; }

        [StringLength(500)]
        public string WeTaskAction { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public bool? IsWithinService { get; set; }

        public bool? IsSatisfiedQuality { get; set; }

        public bool? IsSatisfiedSurroundings { get; set; }

        public bool? IsSatisfiedMaterial { get; set; }

        public bool? IsSatisfiedService { get; set; }

        public bool? IsSatisfiedTech { get; set; }

        public bool? IsSatisfiedServiceTime { get; set; }

        public bool? IsSatisfiedOther { get; set; }

        public bool Deleted { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        public virtual ServiceReturnEvaluate ServiceReturnEvaluate { get; set; }

        public virtual ServiceReturnVisitType ServiceReturnVisitType { get; set; }
    }
}
