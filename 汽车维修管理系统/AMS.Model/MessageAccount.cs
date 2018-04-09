namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MessageAccount")]
    public partial class MessageAccount
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string APIKEY { get; set; }

        public bool? AutoSendBirthdayMsg { get; set; }
    }
}
