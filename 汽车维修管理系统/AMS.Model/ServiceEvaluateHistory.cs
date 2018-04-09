namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceEvaluateHistory")]
    public partial class ServiceEvaluateHistory
    {
        public int Id { get; set; }

        public int ServiceCarId { get; set; }

        public int Level { get; set; }

        public double MaintenanceQuality { get; set; }

        public double ServiceAttitude { get; set; }

        public double RestingEnvironment { get; set; }

        public double MaintenanceLevel { get; set; }

        public string Suggest { get; set; }

        public int CommentatorId { get; set; }

        public DateTime CommentTime { get; set; }

        public string Remark { get; set; }

        public bool Deleted { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }
    }
}
