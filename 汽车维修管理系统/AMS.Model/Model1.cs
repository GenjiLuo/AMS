namespace AMS.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<AdvertisementBanner> AdvertisementBanners { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarAccidentClaim> CarAccidentClaims { get; set; }
        public virtual DbSet<CarFaultsMessage> CarFaultsMessages { get; set; }
        public virtual DbSet<CarFaultyCarMessageHandleHistory> CarFaultyCarMessageHandleHistories { get; set; }
        public virtual DbSet<CarInsurance> CarInsurances { get; set; }
        public virtual DbSet<CarLabel> CarLabels { get; set; }
        public virtual DbSet<CarLabelRelation> CarLabelRelations { get; set; }
        public virtual DbSet<CarPrefix> CarPrefixes { get; set; }
        public virtual DbSet<CarSprayPart> CarSprayParts { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<CashRequestRequestparameter> CashRequestRequestparameters { get; set; }
        public virtual DbSet<CashRequestReturnparameter> CashRequestReturnparameters { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<ConsumerExpensesRecord> ConsumerExpensesRecords { get; set; }
        public virtual DbSet<ConsumerRebatesRecord> ConsumerRebatesRecords { get; set; }
        public virtual DbSet<Corporation> Corporations { get; set; }
        public virtual DbSet<CtBrand> CtBrands { get; set; }
        public virtual DbSet<CtSery> CtSeries { get; set; }
        public virtual DbSet<CtType> CtTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCashRequest> CustomerCashRequests { get; set; }
        public virtual DbSet<CustomerDistributionActivity> CustomerDistributionActivities { get; set; }
        public virtual DbSet<CustomerDistributionActivityChange> CustomerDistributionActivityChanges { get; set; }
        public virtual DbSet<CustomerDistributionActivityChangeDetail> CustomerDistributionActivityChangeDetails { get; set; }
        public virtual DbSet<CustomerDistributionActivityDetail> CustomerDistributionActivityDetails { get; set; }
        public virtual DbSet<CustomerDistributionFinance> CustomerDistributionFinances { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfoes { get; set; }
        public virtual DbSet<CustomerLevel> CustomerLevels { get; set; }
        public virtual DbSet<CustomerMessage> CustomerMessages { get; set; }
        public virtual DbSet<CustomerPackage> CustomerPackages { get; set; }
        public virtual DbSet<CustomerPackageConsume> CustomerPackageConsumes { get; set; }
        public virtual DbSet<CustomerPackageDetail> CustomerPackageDetails { get; set; }
        public virtual DbSet<CustomerPackageManageDetailRecord> CustomerPackageManageDetailRecords { get; set; }
        public virtual DbSet<CustomerPackageManageRecord> CustomerPackageManageRecords { get; set; }
        public virtual DbSet<CustomerPackageOrder> CustomerPackageOrders { get; set; }
        public virtual DbSet<CustomerPackageOrderDetail> CustomerPackageOrderDetails { get; set; }
        public virtual DbSet<CustomerPackageUseOrg> CustomerPackageUseOrgs { get; set; }
        public virtual DbSet<CustomerPrePayment> CustomerPrePayments { get; set; }
        public virtual DbSet<CustomerPrePaymentDetail> CustomerPrePaymentDetails { get; set; }
        public virtual DbSet<CustomerRebatesIncome> CustomerRebatesIncomes { get; set; }
        public virtual DbSet<DailyFinanceDetail> DailyFinanceDetails { get; set; }
        public virtual DbSet<DailyFinanceItem> DailyFinanceItems { get; set; }
        public virtual DbSet<EhrPushUrl> EhrPushUrls { get; set; }
        public virtual DbSet<EhrSetting> EhrSettings { get; set; }
        public virtual DbSet<EmployeeLabel> EmployeeLabels { get; set; }
        public virtual DbSet<FakePartsInventoryRequest> FakePartsInventoryRequests { get; set; }
        public virtual DbSet<FakePartsInventoryRequestDetail> FakePartsInventoryRequestDetails { get; set; }
        public virtual DbSet<FileBrowser> FileBrowsers { get; set; }
        public virtual DbSet<FileResource> FileResources { get; set; }
        public virtual DbSet<FilesAdvertisement> FilesAdvertisements { get; set; }
        public virtual DbSet<FilesBanner> FilesBanners { get; set; }
        public virtual DbSet<FilesCar> FilesCars { get; set; }
        public virtual DbSet<FilesMainMenu> FilesMainMenus { get; set; }
        public virtual DbSet<FilesPackage> FilesPackages { get; set; }
        public virtual DbSet<FilesServiceCar> FilesServiceCars { get; set; }
        public virtual DbSet<FinanceAmountDetail> FinanceAmountDetails { get; set; }
        public virtual DbSet<FinanceBusinessRecord> FinanceBusinessRecords { get; set; }
        public virtual DbSet<Framework_ContentItemRecord> Framework_ContentItemRecord { get; set; }
        public virtual DbSet<Framework_ContentItemVersionRecord> Framework_ContentItemVersionRecord { get; set; }
        public virtual DbSet<Framework_ContentTypeRecord> Framework_ContentTypeRecord { get; set; }
        public virtual DbSet<Framework_CultureRecord> Framework_CultureRecord { get; set; }
        public virtual DbSet<Framework_DataMigrationRecord> Framework_DataMigrationRecord { get; set; }
        public virtual DbSet<HealthPushInfo> HealthPushInfoes { get; set; }
        public virtual DbSet<HealthPushMsgRequest> HealthPushMsgRequests { get; set; }
        public virtual DbSet<HomeContent> HomeContents { get; set; }
        public virtual DbSet<HomeQuickLink> HomeQuickLinks { get; set; }
        public virtual DbSet<HomeUserConfig> HomeUserConfigs { get; set; }
        public virtual DbSet<ManagerSetting> ManagerSettings { get; set; }
        public virtual DbSet<MemberCard> MemberCards { get; set; }
        public virtual DbSet<MemberCardCharge> MemberCardCharges { get; set; }
        public virtual DbSet<MemberCardChargeOrder> MemberCardChargeOrders { get; set; }
        public virtual DbSet<MemberCardConsume> MemberCardConsumes { get; set; }
        public virtual DbSet<MemberCardScore> MemberCardScores { get; set; }
        public virtual DbSet<MemberChargeStrategy> MemberChargeStrategies { get; set; }
        public virtual DbSet<MemberType> MemberTypes { get; set; }
        public virtual DbSet<MenuTemplate> MenuTemplates { get; set; }
        public virtual DbSet<MenuTemplateDetail> MenuTemplateDetails { get; set; }
        public virtual DbSet<MessageAccount> MessageAccounts { get; set; }
        public virtual DbSet<MessageStack> MessageStacks { get; set; }
        public virtual DbSet<Metadata_ContentFieldDefinitionRecord> Metadata_ContentFieldDefinitionRecord { get; set; }
        public virtual DbSet<Metadata_ContentPartDefinitionRecord> Metadata_ContentPartDefinitionRecord { get; set; }
        public virtual DbSet<Metadata_ContentPartFieldDefinitionRecord> Metadata_ContentPartFieldDefinitionRecord { get; set; }
        public virtual DbSet<Metadata_ContentTypeDefinitionRecord> Metadata_ContentTypeDefinitionRecord { get; set; }
        public virtual DbSet<Metadata_ContentTypePartDefinitionRecord> Metadata_ContentTypePartDefinitionRecord { get; set; }
        public virtual DbSet<Metadata_GridInfoPartRecord> Metadata_GridInfoPartRecord { get; set; }
        public virtual DbSet<Metadata_ManyToManyRelationshipRecord> Metadata_ManyToManyRelationshipRecord { get; set; }
        public virtual DbSet<Metadata_OneToManyRelationshipRecord> Metadata_OneToManyRelationshipRecord { get; set; }
        public virtual DbSet<Metadata_OptionItemPartRecord> Metadata_OptionItemPartRecord { get; set; }
        public virtual DbSet<Metadata_OptionSetPartRecord> Metadata_OptionSetPartRecord { get; set; }
        public virtual DbSet<Metadata_RelationshipRecord> Metadata_RelationshipRecord { get; set; }
        public virtual DbSet<Metadata_ShellDescriptorRecord> Metadata_ShellDescriptorRecord { get; set; }
        public virtual DbSet<Metadata_ShellFeatureRecord> Metadata_ShellFeatureRecord { get; set; }
        public virtual DbSet<Metadata_ShellFeatureStateRecord> Metadata_ShellFeatureStateRecord { get; set; }
        public virtual DbSet<Metadata_ShellParameterRecord> Metadata_ShellParameterRecord { get; set; }
        public virtual DbSet<Metadata_ShellStateRecord> Metadata_ShellStateRecord { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrgModuleItem> OrgModuleItems { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageDetail> PackageDetails { get; set; }
        public virtual DbSet<PackageUseOrg> PackageUseOrgs { get; set; }
        public virtual DbSet<PartsDictionary> PartsDictionaries { get; set; }
        public virtual DbSet<PartsDictionaryCarType> PartsDictionaryCarTypes { get; set; }
        public virtual DbSet<PartsInventory> PartsInventories { get; set; }
        public virtual DbSet<PartsInventoryChange> PartsInventoryChanges { get; set; }
        public virtual DbSet<PartsInventoryChangeRefSN> PartsInventoryChangeRefSNs { get; set; }
        public virtual DbSet<PartsInventoryHistory> PartsInventoryHistories { get; set; }
        public virtual DbSet<PartsInventoryImport> PartsInventoryImports { get; set; }
        public virtual DbSet<PartsInventoryRefSN> PartsInventoryRefSNs { get; set; }
        public virtual DbSet<PartsInventoryRequest> PartsInventoryRequests { get; set; }
        public virtual DbSet<PartsInventoryRequestDetail> PartsInventoryRequestDetails { get; set; }
        public virtual DbSet<PartsInventoryWarning> PartsInventoryWarnings { get; set; }
        public virtual DbSet<PartsPaymentHistory> PartsPaymentHistories { get; set; }
        public virtual DbSet<PartsPriceChange> PartsPriceChanges { get; set; }
        public virtual DbSet<PartsPriceChangeDetail> PartsPriceChangeDetails { get; set; }
        public virtual DbSet<PartsTag> PartsTags { get; set; }
        public virtual DbSet<PartsType> PartsTypes { get; set; }
        public virtual DbSet<PartsUniqueSN> PartsUniqueSNs { get; set; }
        public virtual DbSet<PayMentErroCode> PayMentErroCodes { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<PeriodInventoryHistory> PeriodInventoryHistories { get; set; }
        public virtual DbSet<PeriodWarehouseBilling> PeriodWarehouseBillings { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PrePaymentDetailOrder> PrePaymentDetailOrders { get; set; }
        public virtual DbSet<PrePaymentDetail> PrePaymentDetails { get; set; }
        public virtual DbSet<RepairItemCode> RepairItemCodes { get; set; }
        public virtual DbSet<RepairItemType> RepairItemTypes { get; set; }
        public virtual DbSet<RepairType> RepairTypes { get; set; }
        public virtual DbSet<RepairWorkProcess> RepairWorkProcesses { get; set; }
        public virtual DbSet<ReportBusinessObjective> ReportBusinessObjectives { get; set; }
        public virtual DbSet<ReportTrdx> ReportTrdxes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolesPermission> RolesPermissions { get; set; }
        public virtual DbSet<ServiceAccount> ServiceAccounts { get; set; }
        public virtual DbSet<ServiceAccountSham> ServiceAccountShams { get; set; }
        public virtual DbSet<ServiceAccountType> ServiceAccountTypes { get; set; }
        public virtual DbSet<ServiceBooking> ServiceBookings { get; set; }
        public virtual DbSet<ServiceBookingRepairItem> ServiceBookingRepairItems { get; set; }
        public virtual DbSet<ServiceCar> ServiceCars { get; set; }
        public virtual DbSet<ServiceCarPlannedFinishTimeChangeHistory> ServiceCarPlannedFinishTimeChangeHistories { get; set; }
        public virtual DbSet<ServiceCarRepairItem> ServiceCarRepairItems { get; set; }
        public virtual DbSet<ServiceCarRepairItemSham> ServiceCarRepairItemShams { get; set; }
        public virtual DbSet<ServiceCarSham> ServiceCarShams { get; set; }
        public virtual DbSet<ServiceCarViewHistory> ServiceCarViewHistories { get; set; }
        public virtual DbSet<ServiceCarWorkProcess> ServiceCarWorkProcesses { get; set; }
        public virtual DbSet<ServiceCarWorkProcessChange> ServiceCarWorkProcessChanges { get; set; }
        public virtual DbSet<ServiceCashSham> ServiceCashShams { get; set; }
        public virtual DbSet<ServiceCredit> ServiceCredits { get; set; }
        public virtual DbSet<ServiceCreditSham> ServiceCreditShams { get; set; }
        public virtual DbSet<ServiceCustomerSource> ServiceCustomerSources { get; set; }
        public virtual DbSet<ServiceEvaluate> ServiceEvaluates { get; set; }
        public virtual DbSet<ServiceEvaluateHistory> ServiceEvaluateHistories { get; set; }
        public virtual DbSet<ServiceOldPartsHandle> ServiceOldPartsHandles { get; set; }
        public virtual DbSet<ServiceOtherCharge> ServiceOtherCharges { get; set; }
        public virtual DbSet<ServiceOtherChargeSham> ServiceOtherChargeShams { get; set; }
        public virtual DbSet<ServiceOtherChargeType> ServiceOtherChargeTypes { get; set; }
        public virtual DbSet<ServicePayCash> ServicePayCashes { get; set; }
        public virtual DbSet<ServicePaymentType> ServicePaymentTypes { get; set; }
        public virtual DbSet<ServiceReturnEvaluate> ServiceReturnEvaluates { get; set; }
        public virtual DbSet<ServiceReturnVisit> ServiceReturnVisits { get; set; }
        public virtual DbSet<ServiceReturnVisitHistory> ServiceReturnVisitHistories { get; set; }
        public virtual DbSet<ServiceReturnVisitType> ServiceReturnVisitTypes { get; set; }
        public virtual DbSet<ServiceTicketType> ServiceTicketTypes { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShortMessageSend> ShortMessageSends { get; set; }
        public virtual DbSet<ShortMessageSetting> ShortMessageSettings { get; set; }
        public virtual DbSet<ShortMessageTemplate> ShortMessageTemplates { get; set; }
        public virtual DbSet<SMSAutoSend> SMSAutoSends { get; set; }
        public virtual DbSet<SMSVCodeSession> SMSVCodeSessions { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierLevel> SupplierLevels { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemActivityLog> SystemActivityLogs { get; set; }
        public virtual DbSet<SystemBillNo> SystemBillNoes { get; set; }
        public virtual DbSet<SystemBillNoKey> SystemBillNoKeys { get; set; }
        public virtual DbSet<SystemDataLog> SystemDataLogs { get; set; }
        public virtual DbSet<SystemPermission> SystemPermissions { get; set; }
        public virtual DbSet<SystemPersistState> SystemPersistStates { get; set; }
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAppClient> UserAppClients { get; set; }
        public virtual DbSet<UserDefinedMainMenu> UserDefinedMainMenus { get; set; }
        public virtual DbSet<UserEmployeeLabel> UserEmployeeLabels { get; set; }
        public virtual DbSet<UserOrgPermission> UserOrgPermissions { get; set; }
        public virtual DbSet<UserPreference> UserPreferences { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserWarehous> UserWarehouses { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseZone> WarehouseZones { get; set; }
        public virtual DbSet<WeChatMember> WeChatMembers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisement>()
                .HasMany(e => e.FilesAdvertisements)
                .WithRequired(e => e.Advertisement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdvertisementBanner>()
                .HasMany(e => e.FilesBanners)
                .WithRequired(e => e.AdvertisementBanner)
                .HasForeignKey(e => e.BannerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Camera>()
                .Property(e => e.DeviceId)
                .IsUnicode(false);

            modelBuilder.Entity<Camera>()
                .Property(e => e.DeviceBrand)
                .IsUnicode(false);

            modelBuilder.Entity<Camera>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.ExpenseAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Car>()
                .Property(e => e.NeedPayAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.CarFaultsMessages)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.CarInsurances)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.CarLabelRelations)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.FilesCars)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.FinanceBusinessRecords)
                .WithOptional(e => e.Car)
                .HasForeignKey(e => e.HandleCarId);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.PartsInventoryRequests)
                .WithOptional(e => e.Car)
                .HasForeignKey(e => e.RelatedCarId);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.ServiceCars)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.ServiceCarShams)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarAccidentClaim>()
                .Property(e => e.DamageAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CarAccidentClaim>()
                .Property(e => e.ChargePercent)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CarFaultsMessage>()
                .HasMany(e => e.CarFaultyCarMessageHandleHistories)
                .WithRequired(e => e.CarFaultsMessage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarInsurance>()
                .Property(e => e.Commercial)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CarInsurance>()
                .Property(e => e.Compulsory)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CarInsurance>()
                .Property(e => e.Tax)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CarInsurance>()
                .Property(e => e.TotalInsuranceCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CarInsurance>()
                .Property(e => e.AccountAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CarInsurance>()
                .Property(e => e.FreeAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CarLabel>()
                .HasMany(e => e.CarLabelRelations)
                .WithRequired(e => e.CarLabel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarSprayPart>()
                .HasMany(e => e.RepairItemCodes)
                .WithOptional(e => e.CarSprayPart)
                .HasForeignKey(e => e.SprayPartId);

            modelBuilder.Entity<CarType>()
                .Property(e => e.EstimatePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CashRequestRequestparameter>()
                .HasMany(e => e.CashRequestReturnparameters)
                .WithRequired(e => e.CashRequestRequestparameter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConsumerExpensesRecord>()
                .Property(e => e.ConsumerAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ConsumerRebatesRecord>()
                .Property(e => e.ConsumerAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ConsumerRebatesRecord>()
                .Property(e => e.RebatesRate)
                .HasPrecision(19, 2);

            modelBuilder.Entity<ConsumerRebatesRecord>()
                .Property(e => e.RebatesAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CtBrand>()
                .HasMany(e => e.CarTypes)
                .WithRequired(e => e.CtBrand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CtBrand>()
                .HasMany(e => e.PartsDictionaryCarTypes)
                .WithRequired(e => e.CtBrand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CtSery>()
                .HasMany(e => e.CarTypes)
                .WithRequired(e => e.CtSery)
                .HasForeignKey(e => e.CtSeriesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CtSery>()
                .HasMany(e => e.PartsDictionaryCarTypes)
                .WithRequired(e => e.CtSery)
                .HasForeignKey(e => e.CtSeriesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CtType>()
                .HasMany(e => e.CarTypes)
                .WithRequired(e => e.CtType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CtType>()
                .HasMany(e => e.PartsDictionaryCarTypes)
                .WithRequired(e => e.CtType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PirPayMent)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ConsumerExpensesRecords)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.ConsumerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ConsumerRebatesRecords)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.ConsumerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ConsumerRebatesRecords1)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.ReferenceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerCashRequests)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.RequestCustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasOptional(e => e.CustomerInfo)
                .WithRequired(e => e.Customer);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerMessages)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerPrePayments)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerRebatesIncomes)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.FinanceBusinessRecords)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.HandleCustomerId);

            modelBuilder.Entity<Customer>()
                .HasOptional(e => e.MemberCard)
                .WithRequired(e => e.Customer);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerPackages)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerPackageManageRecords)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.PartsInventoryRequests)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.RelatedCustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.PrePaymentDetailOrders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.PrePaymentDetails)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ServiceEvaluates)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CommentatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ServiceEvaluateHistories)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CommentatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.SMSAutoSends)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasOptional(e => e.WeChatMember)
                .WithRequired(e => e.Customer);

            modelBuilder.Entity<CustomerCashRequest>()
                .Property(e => e.CashMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerCashRequest>()
                .HasMany(e => e.CashRequestRequestparameters)
                .WithRequired(e => e.CustomerCashRequest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerDistributionActivity>()
                .HasMany(e => e.ConsumerExpensesRecords)
                .WithRequired(e => e.CustomerDistributionActivity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerDistributionActivity>()
                .HasMany(e => e.ConsumerRebatesRecords)
                .WithRequired(e => e.CustomerDistributionActivity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerDistributionActivity>()
                .HasMany(e => e.CustomerDistributionActivityChanges)
                .WithRequired(e => e.CustomerDistributionActivity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerDistributionActivity>()
                .HasMany(e => e.CustomerDistributionActivityDetails)
                .WithRequired(e => e.CustomerDistributionActivity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerDistributionActivityChange>()
                .HasMany(e => e.CustomerDistributionActivityChangeDetails)
                .WithRequired(e => e.CustomerDistributionActivityChange)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerDistributionActivityChangeDetail>()
                .Property(e => e.Level2RB)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityChangeDetail>()
                .Property(e => e.Level2CB)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityChangeDetail>()
                .Property(e => e.Level3RB)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityChangeDetail>()
                .Property(e => e.Level3CB)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityChangeDetail>()
                .Property(e => e.PackageLevel2Cb)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityChangeDetail>()
                .Property(e => e.PackageLevel3Cb)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityDetail>()
                .Property(e => e.Level2RB)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityDetail>()
                .Property(e => e.Level2CB)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityDetail>()
                .Property(e => e.Level3RB)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityDetail>()
                .Property(e => e.Level3CB)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityDetail>()
                .Property(e => e.PackageLevel2Cb)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionActivityDetail>()
                .Property(e => e.PackageLevel3Cb)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerDistributionFinance>()
                .Property(e => e.Amount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerLevel>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.CustomerLevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerLevel>()
                .HasMany(e => e.CustomerDistributionActivityChangeDetails)
                .WithRequired(e => e.CustomerLevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerLevel>()
                .HasMany(e => e.CustomerDistributionActivityDetails)
                .WithRequired(e => e.CustomerLevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerPackage>()
                .Property(e => e.Count)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackage>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackage>()
                .Property(e => e.ShouldPayMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackage>()
                .Property(e => e.ActualPayMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackage>()
                .HasMany(e => e.CustomerPackageUseOrgs)
                .WithRequired(e => e.CustomerPackage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerPackage>()
                .HasMany(e => e.CustomerPackageConsumes)
                .WithRequired(e => e.CustomerPackage)
                .HasForeignKey(e => e.MemberPackageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerPackage>()
                .HasMany(e => e.CustomerPackageDetails)
                .WithRequired(e => e.CustomerPackage)
                .HasForeignKey(e => e.MemberPackageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerPackage>()
                .HasMany(e => e.CustomerPackageManageRecords)
                .WithRequired(e => e.CustomerPackage)
                .HasForeignKey(e => e.MemberPackageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerPackageConsume>()
                .Property(e => e.UseCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageConsume>()
                .Property(e => e.RemainCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageConsume>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageConsume>()
                .Property(e => e.SettlePrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageConsume>()
                .Property(e => e.RoyaltyPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageConsume>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageDetail>()
                .Property(e => e.Count)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageDetail>()
                .Property(e => e.UseCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageDetail>()
                .Property(e => e.RemainCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageDetail>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageDetail>()
                .Property(e => e.SettlePrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageDetail>()
                .Property(e => e.RoyaltyPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageDetail>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageDetail>()
                .HasMany(e => e.CustomerPackageConsumes)
                .WithRequired(e => e.CustomerPackageDetail)
                .HasForeignKey(e => e.MemberPackageDetailId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerPackageManageDetailRecord>()
                .Property(e => e.Count)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageManageDetailRecord>()
                .Property(e => e.UseCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageManageDetailRecord>()
                .Property(e => e.RemainCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageManageDetailRecord>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageManageDetailRecord>()
                .Property(e => e.SettlePrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageManageDetailRecord>()
                .Property(e => e.RoyaltyPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageManageDetailRecord>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageManageRecord>()
                .Property(e => e.Count)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageManageRecord>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageManageRecord>()
                .Property(e => e.ShouldPayMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageManageRecord>()
                .Property(e => e.ActualPayMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageManageRecord>()
                .HasMany(e => e.CustomerPackageManageDetailRecords)
                .WithRequired(e => e.CustomerPackageManageRecord)
                .HasForeignKey(e => e.MemberPackageManageRecordId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerPackageOrder>()
                .Property(e => e.Count)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageOrder>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageOrder>()
                .Property(e => e.ShouldPayMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageOrder>()
                .Property(e => e.ActualPayMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageOrder>()
                .HasMany(e => e.CustomerPackageOrderDetails)
                .WithRequired(e => e.CustomerPackageOrder)
                .HasForeignKey(e => e.MemberPackageOrderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerPackageOrderDetail>()
                .Property(e => e.Count)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageOrderDetail>()
                .Property(e => e.UseCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageOrderDetail>()
                .Property(e => e.RemainCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageOrderDetail>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPackageOrderDetail>()
                .Property(e => e.SettlePrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageOrderDetail>()
                .Property(e => e.RoyaltyPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPackageOrderDetail>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerPrePayment>()
                .Property(e => e.TotalCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPrePayment>()
                .Property(e => e.UsedCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPrePayment>()
                .Property(e => e.UsableCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerPrePayment>()
                .HasMany(e => e.CustomerPrePaymentDetails)
                .WithRequired(e => e.CustomerPrePayment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerPrePaymentDetail>()
                .Property(e => e.Amount)
                .HasPrecision(19, 2);

            modelBuilder.Entity<CustomerRebatesIncome>()
                .Property(e => e.TotalRebatesAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerRebatesIncome>()
                .Property(e => e.RaisedIncomeAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerRebatesIncome>()
                .Property(e => e.CashingAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<CustomerRebatesIncome>()
                .HasMany(e => e.ConsumerExpensesRecords)
                .WithRequired(e => e.CustomerRebatesIncome)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerRebatesIncome>()
                .HasMany(e => e.ConsumerRebatesRecords)
                .WithRequired(e => e.CustomerRebatesIncome)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerRebatesIncome>()
                .HasMany(e => e.CustomerCashRequests)
                .WithRequired(e => e.CustomerRebatesIncome)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DailyFinanceDetail>()
                .Property(e => e.Amount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<DailyFinanceItem>()
                .HasMany(e => e.DailyFinanceDetails)
                .WithRequired(e => e.DailyFinanceItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EhrSetting>()
                .HasMany(e => e.EhrPushUrls)
                .WithRequired(e => e.EhrSetting)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeLabel>()
                .HasMany(e => e.UserEmployeeLabels)
                .WithRequired(e => e.EmployeeLabel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FakePartsInventoryRequest>()
                .Property(e => e.Count)
                .HasPrecision(19, 5);

            modelBuilder.Entity<FakePartsInventoryRequest>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<FakePartsInventoryRequest>()
                .HasMany(e => e.FakePartsInventoryRequestDetails)
                .WithRequired(e => e.FakePartsInventoryRequest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FakePartsInventoryRequestDetail>()
                .Property(e => e.Count)
                .HasPrecision(19, 5);

            modelBuilder.Entity<FakePartsInventoryRequestDetail>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<FakePartsInventoryRequestDetail>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<FileResource>()
                .Property(e => e.Etag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.CustomerDistributionActivities)
                .WithOptional(e => e.FileResource)
                .HasForeignKey(e => e.LogoId);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.CustomerDistributionActivities1)
                .WithOptional(e => e.FileResource1)
                .HasForeignKey(e => e.RegisterPicId);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.CustomerDistributionActivityChanges)
                .WithOptional(e => e.FileResource)
                .HasForeignKey(e => e.LogoId);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.CustomerDistributionActivityChanges1)
                .WithOptional(e => e.FileResource1)
                .HasForeignKey(e => e.RegisterPicId);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.FileBrowsers)
                .WithRequired(e => e.FileResource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.FilesAdvertisements)
                .WithRequired(e => e.FileResource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.FilesBanners)
                .WithRequired(e => e.FileResource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.FilesCars)
                .WithRequired(e => e.FileResource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.FilesMainMenus)
                .WithRequired(e => e.FileResource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.FilesPackages)
                .WithRequired(e => e.FileResource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FileResource>()
                .HasMany(e => e.FilesServiceCars)
                .WithRequired(e => e.FileResource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FilesServiceCar>()
                .Property(e => e.FlowStatus)
                .IsUnicode(false);

            modelBuilder.Entity<FinanceAmountDetail>()
                .Property(e => e.Money)
                .HasPrecision(19, 5);

            modelBuilder.Entity<FinanceBusinessRecord>()
                .Property(e => e.CustomerPayMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<FinanceBusinessRecord>()
                .Property(e => e.ShouldPayMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<FinanceBusinessRecord>()
                .Property(e => e.ChangeMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<HealthPushInfo>()
                .HasMany(e => e.HealthPushMsgRequests)
                .WithRequired(e => e.HealthPushInfo)
                .HasForeignKey(e => e.HealthPushId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HomeUserConfig>()
                .HasMany(e => e.HomeQuickLinks)
                .WithRequired(e => e.HomeUserConfig)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberCard>()
                .Property(e => e.CurrentMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberCard>()
                .Property(e => e.CurrentEmoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberCard>()
                .Property(e => e.NeedConfirmedMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberCard>()
                .Property(e => e.NeedConfirmedEMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberCard>()
                .HasMany(e => e.MemberCardScores)
                .WithRequired(e => e.MemberCard)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberCardCharge>()
                .Property(e => e.Money)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberCardCharge>()
                .Property(e => e.Emoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberCardChargeOrder>()
                .Property(e => e.Money)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberCardChargeOrder>()
                .Property(e => e.EMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberCardChargeOrder>()
                .Property(e => e.CurrentBalance)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberCardConsume>()
                .HasMany(e => e.CustomerPackages)
                .WithOptional(e => e.MemberCardConsume)
                .HasForeignKey(e => e.MemberConsumeId);

            modelBuilder.Entity<MemberCardConsume>()
                .HasMany(e => e.ServiceCars)
                .WithOptional(e => e.MemberCardConsume)
                .HasForeignKey(e => e.MemberConsumeId);

            modelBuilder.Entity<MemberCardScore>()
                .HasMany(e => e.FinanceBusinessRecords)
                .WithOptional(e => e.MemberCardScore)
                .HasForeignKey(e => e.MemberScoreId);

            modelBuilder.Entity<MemberCardScore>()
                .HasMany(e => e.MemberCardCharges)
                .WithOptional(e => e.MemberCardScore)
                .HasForeignKey(e => e.MemberScoreId);

            modelBuilder.Entity<MemberCardScore>()
                .HasMany(e => e.MemberCardConsumes)
                .WithOptional(e => e.MemberCardScore)
                .HasForeignKey(e => e.MemberScoreId);

            modelBuilder.Entity<MemberChargeStrategy>()
                .Property(e => e.RechargeAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberChargeStrategy>()
                .Property(e => e.GiftAmount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MemberChargeStrategy>()
                .HasMany(e => e.MemberCardCharges)
                .WithOptional(e => e.MemberChargeStrategy)
                .HasForeignKey(e => e.StrategyId);

            modelBuilder.Entity<MemberChargeStrategy>()
                .HasMany(e => e.MemberCardChargeOrders)
                .WithOptional(e => e.MemberChargeStrategy)
                .HasForeignKey(e => e.StrategyId);

            modelBuilder.Entity<MemberType>()
                .Property(e => e.NeedMoney)
                .HasPrecision(19, 5);

            modelBuilder.Entity<MenuTemplate>()
                .HasMany(e => e.MenuTemplateDetails)
                .WithRequired(e => e.MenuTemplate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .Property(e => e.BonusPercentage)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.AdvertisementBanners)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CarFaultsMessages)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CarInsurances)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Corporations)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CustomerMessages)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CustomerPackages)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CustomerPackages1)
                .WithOptional(e => e.Organization1)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CustomerPackageConsumes)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CustomerPackageManageRecords)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CustomerPackageManageRecords1)
                .WithOptional(e => e.Organization1)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CustomerPackageOrders)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CustomerPackageOrders1)
                .WithOptional(e => e.Organization1)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CustomerPackageUseOrgs)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.CustomerPrePayments)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasOptional(e => e.EhrSetting)
                .WithRequired(e => e.Organization);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.FinanceBusinessRecords)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.HandleOrganizationId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.MemberCardScores)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Organization1)
                .WithOptional(e => e.Organization2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.OrgModuleItems)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.PackageUseOrgs)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.ServiceCarShams)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Shops)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.SMSAutoSends)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.SystemActivityLogs)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.SystemBillNoKeys)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.SystemDataLogs)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.SystemSettings)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.UserOrgPermissions)
                .WithRequired(e => e.Organization)
                .HasForeignKey(e => e.OrgId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
                .Property(e => e.ActualPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Package>()
                .Property(e => e.DiscountPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Package>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Package>()
                .Property(e => e.Highlights)
                .IsUnicode(false);

            modelBuilder.Entity<Package>()
                .Property(e => e.SecondHighlights)
                .IsUnicode(false);

            modelBuilder.Entity<Package>()
                .Property(e => e.Describe)
                .IsUnicode(false);

            modelBuilder.Entity<Package>()
                .Property(e => e.Cardinality)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.CustomerPackages)
                .WithRequired(e => e.Package)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.CustomerPackageManageRecords)
                .WithRequired(e => e.Package)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.CustomerPackageOrders)
                .WithRequired(e => e.Package)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.FilesPackages)
                .WithRequired(e => e.Package)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.PackageDetails)
                .WithRequired(e => e.Package)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.PackageUseOrgs)
                .WithRequired(e => e.Package)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PackageDetail>()
                .Property(e => e.Count)
                .HasPrecision(19, 5);

            modelBuilder.Entity<PackageDetail>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<PackageDetail>()
                .Property(e => e.SettlePrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PackageDetail>()
                .Property(e => e.RoyaltyPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PackageDetail>()
                .Property(e => e.StandardPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PartsDictionary>()
                .Property(e => e.Pricerange)
                .HasPrecision(19, 5);

            modelBuilder.Entity<PartsDictionary>()
                .Property(e => e.ClaimPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<PartsDictionary>()
                .HasMany(e => e.FakePartsInventoryRequestDetails)
                .WithRequired(e => e.PartsDictionary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartsDictionary>()
                .HasMany(e => e.PartsUniqueSNs)
                .WithRequired(e => e.PartsDictionary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartsDictionary>()
                .HasMany(e => e.PartsDictionaryCarTypes)
                .WithRequired(e => e.PartsDictionary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartsDictionary>()
                .HasMany(e => e.PartsInventoryRequestDetails)
                .WithRequired(e => e.PartsDictionary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartsDictionary>()
                .HasMany(e => e.PartsInventoryWarnings)
                .WithRequired(e => e.PartsDictionary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartsDictionary>()
                .HasMany(e => e.WarehouseZones)
                .WithOptional(e => e.PartsDictionary)
                .HasForeignKey(e => e.DefaultPartsDictionaryId);

            modelBuilder.Entity<PartsInventory>()
                .HasMany(e => e.PartsInventoryRefSNs)
                .WithRequired(e => e.PartsInventory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartsInventoryChange>()
                .HasMany(e => e.PartsInventoryChangeRefSNs)
                .WithRequired(e => e.PartsInventoryChange)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartsInventoryRequest>()
                .Property(e => e.TotalTaxation)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PartsInventoryRequest>()
                .Property(e => e.TotalPreTaxAmount)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PartsInventoryRequest>()
                .HasMany(e => e.PartsInventories)
                .WithOptional(e => e.PartsInventoryRequest)
                .HasForeignKey(e => e.RelatedMallRequestId);

            modelBuilder.Entity<PartsInventoryRequest>()
                .HasMany(e => e.PartsInventoryRequestDetails)
                .WithRequired(e => e.PartsInventoryRequest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartsInventoryRequestDetail>()
                .HasMany(e => e.PartsInventoryChangeRefSNs)
                .WithRequired(e => e.PartsInventoryRequestDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartsInventoryWarning>()
                .Property(e => e.MinCount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PartsInventoryWarning>()
                .Property(e => e.MaxCount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PartsTag>()
                .HasMany(e => e.PartsDictionaries)
                .WithOptional(e => e.PartsTag)
                .HasForeignKey(e => e.PartsTagId1);

            modelBuilder.Entity<PartsTag>()
                .HasMany(e => e.PartsDictionaries1)
                .WithOptional(e => e.PartsTag1)
                .HasForeignKey(e => e.PartsTagId2);

            modelBuilder.Entity<PartsType>()
                .Property(e => e.SalesMarkupRatio)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PartsType>()
                .HasMany(e => e.PartsType1)
                .WithOptional(e => e.PartsType2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<PartsUniqueSN>()
                .HasMany(e => e.PartsInventoryRefSNs)
                .WithRequired(e => e.PartsUniqueSN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.MenuTemplateDetails)
                .WithRequired(e => e.Permission)
                .HasForeignKey(e => e.PermissionsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.OrgModuleItems)
                .WithOptional(e => e.Permission)
                .HasForeignKey(e => e.PermissionsId);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.RolesPermissions)
                .WithOptional(e => e.Permission)
                .HasForeignKey(e => e.Permission_id);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.SystemPermissions)
                .WithRequired(e => e.Permission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrePaymentDetailOrder>()
                .Property(e => e.Money)
                .HasPrecision(19, 5);

            modelBuilder.Entity<PrePaymentDetail>()
                .Property(e => e.Money)
                .HasPrecision(19, 5);

            modelBuilder.Entity<RepairItemCode>()
                .Property(e => e.RefUnitPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<RepairItemCode>()
                .Property(e => e.PicCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<RepairItemCode>()
                .HasMany(e => e.ServiceCarRepairItems)
                .WithRequired(e => e.RepairItemCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RepairItemCode>()
                .HasMany(e => e.ServiceCarRepairItemShams)
                .WithRequired(e => e.RepairItemCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RepairType>()
                .HasMany(e => e.ServiceCars)
                .WithRequired(e => e.RepairType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RepairType>()
                .HasMany(e => e.ServiceCarShams)
                .WithRequired(e => e.RepairType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RepairWorkProcess>()
                .HasMany(e => e.ServiceCarWorkProcesses)
                .WithRequired(e => e.RepairWorkProcess)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RolesPermissions)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.Role_id);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.Role_id);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.PayPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.LaborHoursPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.MaterialsPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.ManagePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.OtherPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.Taxes)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.DiscountPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.LaborHoursPrivileges)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.MaterialsPrivileges)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.ManagePrivileges)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.NotPayPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.AccidentNotPayPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.PackagePrivileges)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.ActualPayPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.SumPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.ActualMaterialsPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.ActualManagePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.FakeMaterialsPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccount>()
                .Property(e => e.FakeManagePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.PayPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.LaborHoursPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.MaterialsPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.ManagePrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.OtherPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.Taxes)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.DiscountPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.LaborHoursPrivileges)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.MaterialsPrivileges)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.NotPayPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.AccidentNotPayPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.ActualPayPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountSham>()
                .Property(e => e.SumPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceAccountType>()
                .HasMany(e => e.PartsInventoryRequestDetails)
                .WithOptional(e => e.ServiceAccountType)
                .HasForeignKey(e => e.PaymentTypeId);

            modelBuilder.Entity<ServiceAccountType>()
                .HasMany(e => e.ServiceCarRepairItems)
                .WithRequired(e => e.ServiceAccountType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceAccountType>()
                .HasMany(e => e.ServiceCarRepairItemShams)
                .WithRequired(e => e.ServiceAccountType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceAccountType>()
                .HasMany(e => e.ServiceOtherCharges)
                .WithRequired(e => e.ServiceAccountType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceAccountType>()
                .HasMany(e => e.ServiceOtherChargeShams)
                .WithRequired(e => e.ServiceAccountType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceBooking>()
                .Property(e => e.SumLaborHoursCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceBooking>()
                .Property(e => e.SumMaterialCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceBooking>()
                .Property(e => e.SumManageCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceBooking>()
                .Property(e => e.TotalCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceBookingRepairItem>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceBookingRepairItem>()
                .Property(e => e.SumPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceBookingRepairItem>()
                .Property(e => e.PicCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .Property(e => e.EstimateMaterialCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .Property(e => e.CarCheckPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .Property(e => e.LaborHoursCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .Property(e => e.ActualMaterialCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .Property(e => e.OtherCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .Property(e => e.ManagementCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .Property(e => e.TotalCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .Property(e => e.SupplierPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .Property(e => e.FakeMaterialsCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .Property(e => e.FakeManagementCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCar>()
                .HasOptional(e => e.CarAccidentClaim)
                .WithRequired(e => e.ServiceCar);

            modelBuilder.Entity<ServiceCar>()
                .HasMany(e => e.FilesServiceCars)
                .WithRequired(e => e.ServiceCar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCar>()
                .HasOptional(e => e.HealthPushInfo)
                .WithRequired(e => e.ServiceCar);

            modelBuilder.Entity<ServiceCar>()
                .HasMany(e => e.ServiceCarRepairItems)
                .WithRequired(e => e.ServiceCar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCar>()
                .HasMany(e => e.ServiceCarViewHistories)
                .WithRequired(e => e.ServiceCar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCar>()
                .HasMany(e => e.ServiceCarWorkProcesses)
                .WithRequired(e => e.ServiceCar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCar>()
                .HasOptional(e => e.ServiceEvaluate)
                .WithRequired(e => e.ServiceCar);

            modelBuilder.Entity<ServiceCar>()
                .HasMany(e => e.ServiceEvaluateHistories)
                .WithRequired(e => e.ServiceCar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCar>()
                .HasMany(e => e.ServiceOtherCharges)
                .WithRequired(e => e.ServiceCar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCar>()
                .HasOptional(e => e.ServiceReturnVisit)
                .WithRequired(e => e.ServiceCar);

            modelBuilder.Entity<ServiceCar>()
                .HasMany(e => e.ServiceReturnVisitHistories)
                .WithRequired(e => e.ServiceCar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCarRepairItem>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarRepairItem>()
                .Property(e => e.LaborHoursPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarRepairItem>()
                .Property(e => e.CheckLaborHoursPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarRepairItem>()
                .Property(e => e.PicCount)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarRepairItem>()
                .HasMany(e => e.ServiceCarWorkProcesses)
                .WithRequired(e => e.ServiceCarRepairItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCarRepairItemSham>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarRepairItemSham>()
                .Property(e => e.LaborHoursPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarRepairItemSham>()
                .Property(e => e.CheckLaborHoursPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarSham>()
                .Property(e => e.EstimateMaterialCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarSham>()
                .Property(e => e.CarCheckPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarSham>()
                .Property(e => e.LaborHoursCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarSham>()
                .Property(e => e.ActualMaterialCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarSham>()
                .Property(e => e.OtherCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarSham>()
                .Property(e => e.ManagementCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarSham>()
                .Property(e => e.TotalCost)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarSham>()
                .Property(e => e.SupplierPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCarSham>()
                .HasMany(e => e.ServiceAccountShams)
                .WithRequired(e => e.ServiceCarSham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCarSham>()
                .HasMany(e => e.ServiceCarRepairItemShams)
                .WithRequired(e => e.ServiceCarSham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCarSham>()
                .HasMany(e => e.ServiceOtherChargeShams)
                .WithRequired(e => e.ServiceCarSham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCarWorkProcess>()
                .HasMany(e => e.ServiceCarWorkProcessChanges)
                .WithRequired(e => e.ServiceCarWorkProcess)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceCashSham>()
                .Property(e => e.CashPay)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCashSham>()
                .Property(e => e.BankCardPay)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCashSham>()
                .Property(e => e.CheckPay)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCashSham>()
                .Property(e => e.CreditCardPay)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCashSham>()
                .Property(e => e.NotPay)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCredit>()
                .Property(e => e.CreditPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCredit>()
                .Property(e => e.LaborHoursPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCreditSham>()
                .Property(e => e.CreditPrice)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceCustomerSource>()
                .HasMany(e => e.ServiceCars)
                .WithOptional(e => e.ServiceCustomerSource)
                .HasForeignKey(e => e.CustomerOriginId);

            modelBuilder.Entity<ServiceCustomerSource>()
                .HasMany(e => e.ServiceCarShams)
                .WithOptional(e => e.ServiceCustomerSource)
                .HasForeignKey(e => e.CustomerOriginId);

            modelBuilder.Entity<ServiceOldPartsHandle>()
                .HasMany(e => e.ServiceCars)
                .WithOptional(e => e.ServiceOldPartsHandle)
                .HasForeignKey(e => e.OldPartsProcessingId);

            modelBuilder.Entity<ServiceOldPartsHandle>()
                .HasMany(e => e.ServiceCarShams)
                .WithOptional(e => e.ServiceOldPartsHandle)
                .HasForeignKey(e => e.OldPartsProcessingId);

            modelBuilder.Entity<ServiceOtherCharge>()
                .Property(e => e.Price)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceOtherChargeSham>()
                .Property(e => e.Price)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceOtherChargeType>()
                .HasMany(e => e.ServiceOtherCharges)
                .WithRequired(e => e.ServiceOtherChargeType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceOtherChargeType>()
                .HasMany(e => e.ServiceOtherChargeShams)
                .WithRequired(e => e.ServiceOtherChargeType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServicePayCash>()
                .Property(e => e.DiscountCash)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServicePayCash>()
                .Property(e => e.PayCash)
                .HasPrecision(19, 5);

            modelBuilder.Entity<ServiceReturnVisit>()
                .Property(e => e.ReturnEvaluateName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTicketType>()
                .Property(e => e.Rate)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.PartsUniqueSNs)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.PeriodWarehouseBillings)
                .WithOptional(e => e.Shop)
                .HasForeignKey(e => e.ShopId);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.PeriodWarehouseBillings1)
                .WithOptional(e => e.Shop1)
                .HasForeignKey(e => e.SourceShopId);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.PeriodWarehouseBillings2)
                .WithOptional(e => e.Shop2)
                .HasForeignKey(e => e.TargetShopId);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.ReportBusinessObjectives)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SMSAutoSend>()
                .Property(e => e.LatestMessageMileage)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Station>()
                .Property(e => e.StationNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<SystemBillNo>()
                .HasMany(e => e.SystemBillNoKeys)
                .WithRequired(e => e.SystemBillNo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Cars)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Cars1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CarFaultyCarMessageHandleHistories)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CarFaultyCarMessageHandleHistories1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CarPrefixes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CustomerCashRequests)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ConfirmBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CustomerPackages)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FakePartsInventoryRequests)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FakePartsInventoryRequests1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FakePartsInventoryRequests2)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.RelatedUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FakePartsInventoryRequests3)
                .WithOptional(e => e.User3)
                .HasForeignKey(e => e.RequestUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FakePartsInventoryRequestDetails)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FakePartsInventoryRequestDetails1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HomeUserConfigs)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MemberCardScores)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.OperatorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsInventoryChanges)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.OperatorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsInventoryChangeRefSNs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsInventoryChangeRefSNs1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsInventoryRefSNs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsInventoryRefSNs1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsInventoryRequests)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ConfirmUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsInventoryRequests1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.RelatedUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsInventoryRequests2)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.RequestUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsInventoryRequests3)
                .WithOptional(e => e.User3)
                .HasForeignKey(e => e.DocMakerUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsPriceChanges)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ConfirmUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsPriceChanges1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.RequestUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsUniqueSNs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PartsUniqueSNs1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceAccounts)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceAccounts1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceBookings)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceBookings1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceBookings2)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.RepairAdviserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceBookingRepairItems)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceBookingRepairItems1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCars)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ConfirmUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCars1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCars2)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCars3)
                .WithRequired(e => e.User3)
                .HasForeignKey(e => e.RepairAdviserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCarPlannedFinishTimeChangeHistories)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCarPlannedFinishTimeChangeHistories1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCarRepairItems)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCarRepairItems1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCarRepairItems2)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.RepairManId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCarRepairItemShams)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.RepairManId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCarShams)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ConfirmUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCarShams1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.RepairAdviserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCarViewHistories)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.OperatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCarWorkProcesses)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.RepairManId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCredits)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServiceCredits1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServicePayCashes)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ServicePayCashes1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifyBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SystemActivityLogs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SystemActivityLogs1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SystemDataLogs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SystemDataLogs1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SystemPersistStates)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserAppClients)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserEmployeeLabels)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserOrgPermissions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.UserPreference)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserWarehouses)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Warehouses)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ManagerId);

            modelBuilder.Entity<UserAppClient>()
                .Property(e => e.ClientType)
                .IsUnicode(false);

            modelBuilder.Entity<UserAppClient>()
                .Property(e => e.ClientId)
                .IsUnicode(false);

            modelBuilder.Entity<UserDefinedMainMenu>()
                .HasMany(e => e.FilesMainMenus)
                .WithRequired(e => e.UserDefinedMainMenu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.PartsInventoryChanges)
                .WithOptional(e => e.Warehouse)
                .HasForeignKey(e => e.SourceWarehouseId);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.PartsInventoryChanges1)
                .WithOptional(e => e.Warehouse1)
                .HasForeignKey(e => e.TargetWarehouseId);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.PartsInventoryRequestDetails)
                .WithOptional(e => e.Warehouse)
                .HasForeignKey(e => e.SourceWarehouseId);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.PartsInventoryRequestDetails1)
                .WithOptional(e => e.Warehouse1)
                .HasForeignKey(e => e.TargetWarehouseId);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.PartsInventoryWarnings)
                .WithRequired(e => e.Warehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.UserWarehouses)
                .WithRequired(e => e.Warehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WarehouseZone>()
                .HasMany(e => e.PartsInventories)
                .WithOptional(e => e.WarehouseZone)
                .HasForeignKey(e => e.WarehouseAreaId);

            modelBuilder.Entity<WarehouseZone>()
                .HasMany(e => e.PartsInventoryRequestDetails)
                .WithOptional(e => e.WarehouseZone)
                .HasForeignKey(e => e.SourceWarehouseAreaId);

            modelBuilder.Entity<WarehouseZone>()
                .HasMany(e => e.PartsInventoryRequestDetails1)
                .WithOptional(e => e.WarehouseZone1)
                .HasForeignKey(e => e.TargetWarehouseAreaId);
        }
    }
}
