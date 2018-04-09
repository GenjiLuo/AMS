namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Framework_DataMigrationRecord
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string DataMigrationClass { get; set; }

        public int? Version { get; set; }
    }
}
