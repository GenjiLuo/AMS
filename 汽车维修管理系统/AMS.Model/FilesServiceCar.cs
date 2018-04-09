namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FilesServiceCar")]
    public partial class FilesServiceCar
    {
        public int Id { get; set; }

        public int ServiceCarId { get; set; }

        [Required]
        [StringLength(255)]
        public string FlowStatus { get; set; }

        public int FileResourceId { get; set; }

        public bool IsSysPublic { get; set; }

        public int OrganizationId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual FileResource FileResource { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }
    }
}
