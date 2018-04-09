namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Metadata_OptionItemPartRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? OptionSetId { get; set; }

        [StringLength(1024)]
        public string Name { get; set; }

        public int? Weight { get; set; }

        public bool? Selectable { get; set; }
    }
}
