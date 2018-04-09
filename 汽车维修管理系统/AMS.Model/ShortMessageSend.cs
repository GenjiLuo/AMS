namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShortMessageSend")]
    public partial class ShortMessageSend
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Mobile { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        public int? SMSNumber { get; set; }

        public int? Status { get; set; }

        public DateTime? SendDate { get; set; }

        public int? OperatorId { get; set; }

        [StringLength(255)]
        public string ErrorMessage { get; set; }

        public int? TemplateCategory { get; set; }

        public int? OrganizationId { get; set; }

        public int? SMSAutoSendId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual SMSAutoSend SMSAutoSend { get; set; }
    }
}
