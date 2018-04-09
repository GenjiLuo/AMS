namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EhrPushUrl")]
    public partial class EhrPushUrl
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int UrlType { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        public virtual EhrSetting EhrSetting { get; set; }
    }
}
