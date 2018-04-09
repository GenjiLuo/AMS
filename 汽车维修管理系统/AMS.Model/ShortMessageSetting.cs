namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShortMessageSetting
    {
        public int Id { get; set; }

        public bool CustomerBirthdayAutoSend { get; set; }

        public bool LevelChangedAutoSend { get; set; }

        public bool MaintenanceLevel2AutoSend { get; set; }

        public bool InsuranceExpireAutoSend { get; set; }

        public bool MaintenanceAutoSend { get; set; }

        public bool ExhaustCheckAutoSend { get; set; }

        public bool YearlyCheckAutoSend { get; set; }

        public int? MaintenanceLevel2AutoSendDays { get; set; }

        public int? InsuranceExpireAutoSendNotifyDays { get; set; }

        public int? MaintenanceAutoSendDays { get; set; }

        public int? ExhaustCheckAutoSendDays { get; set; }

        public int? YearlyCheckAutoSendDays { get; set; }

        public DateTime? LastAutoSendDate { get; set; }

        public int? SendTimeAfter { get; set; }

        public int? RatingAutoSendDays { get; set; }

        public int? OrganizationId { get; set; }

        [Required]
        [StringLength(255)]
        public string MessageInscribe { get; set; }

        public bool IsUnified { get; set; }

        public bool MaintenanceMileageAutoSend { get; set; }

        public int? MaintenanceAutoSendMileage { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
