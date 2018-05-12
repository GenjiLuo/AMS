using System.Data.Entity.ModelConfiguration.Conventions;
using AMS.Model.dto;
using AMS.Model.poco;

namespace AMS.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=AmsSqlConn")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<QuickMenu> QuickMenu { get; set; }
        public virtual DbSet<OperationLog> OperationLog { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<RepairType> RepairType { get; set; }
        public virtual DbSet<RepairItemType> RepairItemType { get; set; }
        public virtual DbSet<RepairItem> RepairItem { get; set; }
        public virtual DbSet<CarBrand> CarBrand { get; set; }
        public virtual DbSet<CarSeries> CarSeries { get; set; }
        public virtual DbSet<CarModel> CarModel { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<PartsType> PartsType { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<PartsDictionary> PartsDictionary { get; set; }
        public virtual DbSet<PartsDictionarySuitedCarModel> PartsDictionarySuitedCarModel { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<Parts> Parts { get; set; }
        public virtual DbSet<PartsBuy> PartsBuy { get; set; }
        public virtual DbSet<EstimateRepairParts> EstimateRepairParts { get; set; }
        public virtual DbSet<RepairParts> RepairParts { get; set; }
        public virtual DbSet<ServiceRepairItem> ServiceRepairItem { get; set; }
        public virtual DbSet<ServiceBooking> ServiceBooking { get; set; }
        public virtual DbSet<ServiceRepair> ServiceRepair { get; set; }
        public virtual DbSet<ServiceAccountType> ServiceAccountType { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<ServiceTicketType> ServiceTicketType { get; set; }
        public virtual DbSet<ParameterControll> ParameterControll { get; set; }
        public virtual DbSet<BillNoSetting> BillNoSetting { get; set; }
    }
}