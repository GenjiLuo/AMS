namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Metadata_OptionSetPartRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string TermTypeName { get; set; }

        [StringLength(1024)]
        public string Name { get; set; }

        public bool? IsInternal { get; set; }
    }
}
