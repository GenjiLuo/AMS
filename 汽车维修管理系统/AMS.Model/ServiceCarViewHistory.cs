namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCarViewHistory")]
    public partial class ServiceCarViewHistory
    {
        public int Id { get; set; }

        public int ServiceCarId { get; set; }

        public int OperatorId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        public virtual User User { get; set; }
    }
}
