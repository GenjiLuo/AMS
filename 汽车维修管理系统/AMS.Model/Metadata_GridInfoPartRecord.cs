namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Metadata_GridInfoPartRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? ContentItemRecord_id { get; set; }

        [StringLength(255)]
        public string ItemContentType { get; set; }

        [StringLength(255)]
        public string DisplayName { get; set; }

        public bool? IsDefault { get; set; }

        public string Settings { get; set; }
    }
}
