namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceReturnVisit")]
    public partial class ServiceReturnVisit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceCarId { get; set; }

        public int? ReturnEvaluateId { get; set; }

        [StringLength(50)]
        public string ReturnEvaluateName { get; set; }

        public DateTime? LastReturnVisitDate { get; set; }

        public DateTime? NextReturnVisitDate { get; set; }

        [StringLength(500)]
        public string FirstUnstatisFiedElem { get; set; }

        [StringLength(500)]
        public string FirstReturnVistiSuggestion { get; set; }

        [StringLength(500)]
        public string LastUnstatisFiedElem { get; set; }

        [StringLength(500)]
        public string LastReturnVistiSuggestion { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }
    }
}
