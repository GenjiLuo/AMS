namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Metadata_ShellDescriptorRecord
    {
        public int Id { get; set; }

        public int? SerialNumber { get; set; }
    }
}
