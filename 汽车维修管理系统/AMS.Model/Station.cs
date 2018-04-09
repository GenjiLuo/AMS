namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Station")]
    public partial class Station
    {
        public int Id { get; set; }

        public int? OrganizationId { get; set; }

        [StringLength(255)]
        public string StationNumber { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(25)]
        public string ShortName { get; set; }

        public int? CameraId { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int State { get; set; }

        public int? ServiceCarId { get; set; }

        public virtual Camera Camera { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }
    }
}
