namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Framework_ContentItemVersionRecord
    {
        public int Id { get; set; }

        public int? Number { get; set; }

        public bool? Published { get; set; }

        public bool? Latest { get; set; }

        public string Data { get; set; }

        public int ContentItemRecord_id { get; set; }
    }
}
