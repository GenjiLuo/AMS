namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Metadata_ShellStateRecord
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Unused { get; set; }
    }
}
