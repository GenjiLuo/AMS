namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CarAccidentClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceCarId { get; set; }

        public bool HasIdentified { get; set; }

        public decimal? DamageAmount { get; set; }

        public int? AccidentType { get; set; }

        [StringLength(50)]
        public string ChargeCarNo { get; set; }

        [StringLength(50)]
        public string ChargeName { get; set; }

        [StringLength(50)]
        public string ChargeContact { get; set; }

        public decimal? ChargePercent { get; set; }

        [StringLength(50)]
        public string ChargeUnit { get; set; }

        [StringLength(50)]
        public string ChargeCrimeNo { get; set; }

        [StringLength(50)]
        public string ChargeCompany { get; set; }

        public DateTime? ChargeOutInsuranceDate { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }
    }
}
