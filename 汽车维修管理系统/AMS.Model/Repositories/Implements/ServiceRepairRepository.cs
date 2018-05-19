using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AMS.Model.dto;
using AMS.Model.Enum;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class ServiceRepairRepository : IServiceRepairRepository
    {
        public ResModel AddServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var billNo = "";
                var lastIndex = 0;
                var dateFormat = "";
                var index = 0;
                var indexStr = "";
                var repairBill = db.BillNoSetting.FirstOrDefault(i => i.Name == BillTypeName.接车单号.ToString());
                if (repairBill.DailyReset)
                {
                    var lastRepair = db.ServiceRepair.Where(i => i.CreateTime.Value.Day == DateTime.Now.Day).OrderByDescending(i => i.CreateTime).FirstOrDefault();
                    lastIndex = lastRepair?.BillNoIndex ?? 0;
                }
                else
                {
                    var lastRepair = db.ServiceRepair.OrderByDescending(i => i.CreateTime).FirstOrDefault();
                    lastIndex = lastRepair?.BillNoIndex ?? 0;
                }
                index = lastIndex + 1;
                indexStr = index.ToString();
                switch (repairBill.SerNoLength)
                {
                    case BillSerNoLength.两位:
                        indexStr = indexStr.PadLeft(2, '0');
                        break;
                    case BillSerNoLength.三位:
                        indexStr = indexStr.PadLeft(3, '0');
                        break;
                    case BillSerNoLength.四位:
                        indexStr = indexStr.PadLeft(4, '0');
                        break;
                    case BillSerNoLength.五位:
                        indexStr = indexStr.PadLeft(5, '0');
                        break;
                    case BillSerNoLength.六位:
                        indexStr = indexStr.PadLeft(6, '0');
                        break;
                }
                switch (repairBill.DateFormat)
                {
                    case BillDateFormat.简洁年月日:
                        dateFormat = DateTime.Now.ToString("yyMMdd");
                        break;
                    case BillDateFormat.完整年月日:
                        dateFormat = DateTime.Now.ToString("yyyyMMdd");
                        break;
                    case BillDateFormat.无:
                        dateFormat = "";
                        break;
                }
                billNo = repairBill.Prefix + dateFormat + indexStr;
                var serviceRepair = new ServiceRepair()
                {
                    Id = Guid.NewGuid(),
                    CarId = serviceRepairDto.CarId,
                    ServiceType = ServiceType.维修,
                    ServiceRepairState = ServiceRepairState.在修,
                    RepairTypeId = serviceRepairDto.RepairTypeId,
                    BillNo = billNo,
                    BillNoIndex = index,
                    ServiceBookingId = serviceRepairDto.ServiceBookingId,
                    ServiceDateTime = DateTime.Now,
                    EstimateLeaveTime = serviceRepairDto.EstimateLeaveTime,
                    ServiceAdvisorId = serviceRepairDto.ServiceAdvisorId,
                    ContactName = serviceRepairDto.ContactName,
                    ContactPhone = serviceRepairDto.ContactPhone,
                    RepairDescription = serviceRepairDto.RepairDescription,
                    CustomerDescription = serviceRepairDto.CustomerDescription,
                    CreateTime = DateTime.Now
                };
                var serviceBooking = db.ServiceBooking.FirstOrDefault(i => i.Id == serviceRepairDto.ServiceBookingId);
                var serviceRepairItem=new List<ServiceRepairItem>();
                var estimateRepairParts=new List<EstimateRepairParts>();
                if (serviceBooking !=null )
                {
                    serviceRepairItem = serviceBooking.ServiceRepairItem.Select(i => new ServiceRepairItem()
                    {
                        Id = Guid.NewGuid(),
                        RepairItemId = i.RepairItemId,
                        ServiceRepairId = serviceRepair.Id,
                        ServiceAccountTypeId = i.ServiceAccountTypeId,
                        WorkHour = i.WorkHour,
                        Price = i.Price,
                        Description = i.Description
                    }).ToList();
                    estimateRepairParts = serviceBooking.EstimateRepairParts.Select(i => new EstimateRepairParts()
                    {
                        Id = Guid.NewGuid(),
                        PartsId = i.PartsId,
                        Price = i.Price,
                        Count = i.Count,
                        ServiceAccountTypeId = i.ServiceAccountTypeId,
                        ServiceRepairId = serviceRepair.Id

                    }).ToList();
                }
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.ServiceRepair.Add(serviceRepair);
                        db.SaveChanges();
                        if (serviceBooking != null)
                        {
                            db.ServiceRepairItem.AddRange(serviceRepairItem);
                            db.EstimateRepairParts.AddRange(estimateRepairParts);
                            serviceBooking.ServiceBookingState = ServiceBookingState.已接车;
                        }
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "添加维修单失败",Success = false};
                    }
                    return new ResModel() { Msg = "添加维修单成功", Success = true, Data = new { ServiceRepairId = serviceRepair.Id } };
                }
            }
        }

        public ResModel AddWashCar(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var billNo = "";
                var lastIndex = 0;
                var dateFormat = "";
                var index = 0;
                var indexStr = "";
                var repairBill = db.BillNoSetting.FirstOrDefault(i => i.Name == BillTypeName.接车单号.ToString());
                if (repairBill.DailyReset)
                {
                    var lastRepair = db.ServiceRepair.Where(i => i.CreateTime.Value.Day == DateTime.Now.Day).OrderByDescending(i => i.CreateTime).FirstOrDefault();
                    lastIndex = lastRepair?.BillNoIndex ?? 0;
                }
                else
                {
                    var lastRepair = db.ServiceRepair.OrderByDescending(i => i.CreateTime).FirstOrDefault();
                    lastIndex = lastRepair?.BillNoIndex ?? 0;
                }
                index = lastIndex + 1;
                indexStr = index.ToString();
                switch (repairBill.SerNoLength)
                {
                    case BillSerNoLength.两位:
                        indexStr = indexStr.PadLeft(2, '0');
                        break;
                    case BillSerNoLength.三位:
                        indexStr = indexStr.PadLeft(3, '0');
                        break;
                    case BillSerNoLength.四位:
                        indexStr = indexStr.PadLeft(4, '0');
                        break;
                    case BillSerNoLength.五位:
                        indexStr = indexStr.PadLeft(5, '0');
                        break;
                    case BillSerNoLength.六位:
                        indexStr = indexStr.PadLeft(6, '0');
                        break;
                }
                switch (repairBill.DateFormat)
                {
                    case BillDateFormat.简洁年月日:
                        dateFormat = DateTime.Now.ToString("yyMMdd");
                        break;
                    case BillDateFormat.完整年月日:
                        dateFormat = DateTime.Now.ToString("yyyyMMdd");
                        break;
                    case BillDateFormat.无:
                        dateFormat = "";
                        break;
                }
                billNo = repairBill.Prefix + dateFormat + indexStr;
                var serviceRepair = new ServiceRepair()
                {
                    Id = Guid.NewGuid(),
                    CarId = serviceRepairDto.CarId,
                    ServiceType = ServiceType.洗车,
                    ServiceWashState = ServiceWashState.登记,
                    BillNo = billNo,
                    BillNoIndex = index,
                    ServiceBookingId = serviceRepairDto.ServiceBookingId,
                    ServiceDateTime = DateTime.Now,
                    EstimateLeaveTime = serviceRepairDto.EstimateLeaveTime,
                    LeaveTime = serviceRepairDto.LeaveTime,
                    ServiceAdvisorId = serviceRepairDto.ServiceAdvisorId,
                    ContactName = serviceRepairDto.ContactName,
                    ContactPhone = serviceRepairDto.ContactPhone,
                    RepairDescription = serviceRepairDto.RepairDescription,
                    CustomerDescription = serviceRepairDto.CustomerDescription,
                    CreateTime = DateTime.Now
                };
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.ServiceRepair.Add(serviceRepair);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "添加洗车单失败",Success = false};
                    }
                    return new ResModel() { Msg = "添加洗车单成功", Success = true, Data = new { ServiceRepairId = serviceRepair.Id } };
                }
            }
        }

        public ResModel DeleteServiceRepair(Guid serviceRepairId)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairId);
                if (serviceRepair == null)
                {
                    return new ResModel() { Msg = "删除维修单失败，未找到该维修单", Success = false };
                }
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        db.ServiceRepairItem.RemoveRange(serviceRepair.ServiceRepairItem);
                        db.RepairParts.RemoveRange(serviceRepair.RepairParts);
                        db.SaveChanges();
                        db.ServiceRepair.Remove(serviceRepair);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "删除维修单失败", Success = false };
                    }
                    return new ResModel() { Msg = "删除维修单成功", Success = true };
                }
            }
        }

        public List<ServiceRepairDto> GetAllServiceRepair()
        {
            using (var db = new ModelContext())
            {
                var serviceRepairs = db.ServiceRepair.Select(i => new ServiceRepairDto()
                {
                    Id = i.Id,
                    CarId = i.CarId,
                    CarPlateNum = i.Car.PlateNum,
                    BillNo = i.BillNo,
                    BookingBillNo = i.ServiceBookingId.HasValue ? i.ServiceBooking.BillNo:"",
                    ServiceBookingId = i.ServiceBookingId,
                    ServiceRepairState = i.ServiceRepairState,
                    ServiceWashState = i.ServiceWashState,
                    ServiceType = i.ServiceType,
                    RepairTypeId = i.RepairTypeId,
                    RepairTypeName = i.RepairType.Name,
                    ServiceDateTime = i.ServiceDateTime,
                    EstimateLeaveTime = i.EstimateLeaveTime,
                    LeaveTime = i.LeaveTime,
                    ServiceAdvisorId = i.ServiceAdvisorId,
                    ServiceAdvisorName = i.ServiceAdvisor.Name,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    RepairDescription = i.RepairDescription,
                    CustomerDescription = i.CustomerDescription,
                    ServiceRepairItem = i.ServiceRepairItem.Select(j => new ServiceRepairItemDto()
                    {
                        Id = j.Id,
                        ServiceRepairId = j.ServiceRepairId,
                        RepairItemId = j.RepairItemId,
                        RepairItemName = j.RepairItem.Name,
                        RepairItemSerNo = j.RepairItem.SerNum,
                        WorkHour = j.WorkHour,
                        Price = j.Price,
                        MainOperatorId = j.MainOperatorId,
                        MainOperatorName = j.MainOperator.Name,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        Description = j.Description
                    }).ToList(),
                    EstimateRepairParts = i.EstimateRepairParts.Select(j=>new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.PartsDictionary.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name

                    }).ToList(),
                    RepairParts = i.RepairParts.Select(j=>new RepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.PartsDictionary.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name
                    }).ToList()
                }).ToList();
                return serviceRepairs;
            }
        }

        public ServiceRepairDto GetOneServiceRepair(Guid serviceRepairId)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.Where(i=>i.Id == serviceRepairId).Select(i => new ServiceRepairDto()
                {
                    Id = i.Id,
                    CarId = i.CarId,
                    Car = new CarDto()
                    {
                        Id = i.Car.Id,
                        CustomerId = i.Car.CustomerId,
                        CustomerName = i.Car.Customer.Name,
                        CustomerPhone = i.Car.Customer.MobilePhone ?? i.Car.Customer.FixPhone,

                        CarOwnerName = i.Car.CarOwnerName,
                        CarOwnerPhone = i.Car.CarOwnerPhone,

                        VIN = i.Car.VIN,
                        PlateNum = i.Car.PlateNum,
                        ModelId = i.Car.ModelId,
                        BrandName = i.Car.Model.Series.Brand.Name,
                        SeriesName = i.Car.Model.Series.Name,
                        ModelName = i.Car.Model.Name,
                        Price = i.Car.Model.Price,
                        FullName = i.Car.Model.FullName,
                        Color = i.Car.Color,
                        EngineModelNo = i.Car.EngineModelNo,
                        EngineNo = i.Car.EngineNo,
                        CarLabel = i.Car.CarLabel,
                        CarImg = i.Car.CarImg,
                        CarRegisterTime = i.Car.CarRegisterTime,
                        MaintainExpireTime = i.Car.MaintainExpireTime,
                        CurrentMileage = i.Car.CurrentMileage,
                        NextMaintainMileage = i.Car.NextMaintainMileage,
                        NextMaintainDate = i.Car.NextMaintainDate,
                        YearlyCheckTime = i.Car.YearlyCheckTime,
                        SecondLevelMaintainTime = i.Car.SecondLevelMaintainTime,
                        LevelCheckTime = i.Car.LevelCheckTime,
                        TailCheckTime = i.Car.TailCheckTime,
                        InsuranceExpireTime = i.Car.InsuranceExpireTime,
                        InsuranceOrg = i.Car.InsuranceOrg,
                        InsuranceNo = i.Car.InsuranceNo,
                        Description = i.Car.Description,

                        FirstServiceTime = i.Car.FirstServiceTime,
                        LastServiceTime = i.Car.LastServiceTime
                    },
                    BillNo = i.BillNo,
                    ServiceBookingId = i.ServiceBookingId,
                    ServiceRepairState = i.ServiceRepairState,
                    ServiceWashState = i.ServiceWashState,
                    ServiceType = i.ServiceType,
                    RepairTypeId = i.RepairTypeId,
                    RepairTypeName = i.RepairType.Name,
                    ServiceDateTime = i.ServiceDateTime,
                    EstimateLeaveTime = i.EstimateLeaveTime,
                    LeaveTime = i.LeaveTime,
                    ServiceAdvisorId = i.ServiceAdvisorId,
                    ServiceAdvisorName = i.ServiceAdvisor.Name,
                    WashCarMainOperatorId = i.WashCarMainOperatorId,
                    WashCarMainOperatorName = i.WashCarMainOperator.Name,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    RepairDescription = i.RepairDescription,
                    CustomerDescription = i.CustomerDescription,
                    Description = i.Description,
                    ServiceRepairItem = i.ServiceRepairItem.Select(j => new ServiceRepairItemDto()
                    {
                        Id = j.Id,
                        ServiceRepairId = j.ServiceRepairId,
                        RepairItemId = j.RepairItemId,
                        RepairItemName = j.RepairItem.Name,
                        RepairItemSerNo = j.RepairItem.SerNum,
                        WorkHour = j.WorkHour,
                        Price = j.Price,
                        MainOperatorId = j.MainOperatorId,
                        MainOperatorName = j.MainOperator.Name,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        Description = j.Description
                    }).ToList(),
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.PartsDictionary.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name

                    }).ToList(),
                    RepairParts = i.RepairParts.Select(j => new RepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.PartsDictionary.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name
                    }).ToList(),
                    ServiceWashItem = i.ServiceWashItems.Select(j=>new ServiceWashItemDto()
                    {
                        Id = j.Id,
                        WashItemId = j.WashItemId,
                        WashItemName = j.WashItem.Name,
                        WashItemPrice = j.WashItem.Price,
                        ServiceRepairId = j.ServiceRepairId
                    }).FirstOrDefault()
                }).FirstOrDefault();
                return serviceRepair;
            }
        }

        public ServiceRepairAccountTicketDto GetOneAccountTicket(Guid serviceRepairAccountTicketId)
        {
            using (var db=new ModelContext())
            {
                var serviceRepairAccountTicket = db.ServiceRepairAccountTicket.Where(i => i.Id == serviceRepairAccountTicketId)
                    .Select(i => new ServiceRepairAccountTicketDto()
                    {
                        Id = i.Id,
                        ServiceRepair = GetOneServiceRepair(i.ServiceRepairId),
                        ManagementMoney = i.ManagementMoney,
                        OtherMoney = i.OtherMoney,
                        TaxMoney = i.TaxMoney,
                        WorkHourDiscount = i.WorkHourDiscount,
                        PartsDiscount = i.PartsDiscount,
                        ManagementDiscount = i.ManagementDiscount,
                        TotalMoney = i.TotalMoney,
                        MoveLittle = i.MoveLittle,
                        ShouldPay = i.ShouldPay,
                        CreditPay = i.CreditPay,
                        RealPay = i.RealPay
                    }).FirstOrDefault();
                return serviceRepairAccountTicket;
            }
        }
        public ServiceRepairAccountTicketDto GetOneAccountTicketByRepairId(Guid serviceRepairId)
        {
            using (var db = new ModelContext())
            {
                var serviceRpair = GetOneServiceRepair(serviceRepairId);
                var serviceRepairAccountTicket = db.ServiceRepairAccountTicket.Where(i => i.ServiceRepairId == serviceRepairId)
                    .Select(i => new ServiceRepairAccountTicketDto()
                    {
                        Id = i.Id,
                        ManagementMoney = i.ManagementMoney,
                        OtherMoney = i.OtherMoney,
                        TaxMoney = i.TaxMoney,
                        WorkHourDiscount = i.WorkHourDiscount,
                        PartsDiscount = i.PartsDiscount,
                        ManagementDiscount = i.ManagementDiscount,
                        TotalMoney = i.TotalMoney,
                        MoveLittle = i.MoveLittle,
                        ShouldPay = i.ShouldPay,
                        CreditPay = i.CreditPay,
                        RealPay = i.RealPay
                    }).FirstOrDefault();
                if (serviceRepairAccountTicket != null)
                {
                    serviceRepairAccountTicket.ServiceRepair = serviceRpair;
                }
                return serviceRepairAccountTicket;
            }
        }

        public ServiceRepairCashTicketDto GetOneCashTicketByRepairId(Guid serviceRepairId)
        {
            using (var db=new ModelContext())
            {
                var serviceRepairCashTicket = db.ServiceRepairCashTicket
                    .Where(i => i.ServiceRepairId == serviceRepairId).Select(i => new ServiceRepairCashTicketDto()
                    {
                        Id = i.Id,
                        ServiceRepairId = i.ServiceRepairId,
                        ShouldPay = i.ShouldPay,
                        WashCarDiscount = i.WashCarDiscount,
                        WashCarCreditPay = i.WashCarCreditPay,
                        RealPay = i.RealPay,
                        BackLittle = i.BackLittle,
                        Description = i.Description,
                        ServiceRepairPayments = i.ServiceRpairPayments.Select(j=>new ServiceRpairPaymentDto()
                        {
                            Id = j.Id,
                            ServiceRepairCashTicketId = j.ServiceRepairCashTicketId,
                            PaymentTypeId = j.PaymentTypeId,
                            Money = j.Money
                        }).ToList()
                    }).FirstOrDefault();
                return serviceRepairCashTicket;
            }
        }

        public List<ServiceRepairDto> QueryServiceRepair(string keyword)
        {
            using (var db = new ModelContext())
            {
                var serviceRepairs= db.ServiceRepair.Where(i => i.ContactName.Contains(keyword)).Select(i => new ServiceRepairDto()
                {
                    Id = i.Id,
                    CarId = i.CarId,
                    BillNo = i.BillNo,
                    ServiceBookingId = i.ServiceBookingId,
                    ServiceRepairState = i.ServiceRepairState,
                    ServiceWashState = i.ServiceWashState,
                    ServiceType = i.ServiceType,
                    ServiceDateTime = i.ServiceDateTime,
                    EstimateLeaveTime = i.EstimateLeaveTime,
                    LeaveTime = i.LeaveTime,
                    ServiceAdvisorId = i.ServiceAdvisorId,
                    ServiceAdvisorName = i.ServiceAdvisor.Name,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    RepairDescription = i.RepairDescription,
                    CustomerDescription = i.CustomerDescription,
                    ServiceRepairItem = i.ServiceRepairItem.Select(j => new ServiceRepairItemDto()
                    {
                        Id = j.Id,
                        ServiceRepairId = j.ServiceRepairId,
                        RepairItemId = j.RepairItemId,
                        RepairItemName = j.RepairItem.Name,
                        WorkHour = j.WorkHour,
                        Price = j.Price,
                        MainOperatorId = j.MainOperatorId,
                        MainOperatorName = j.MainOperator.Name,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        Description = j.Description
                    }).ToList(),
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.PartsDictionary.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name

                    }).ToList(),
                    RepairParts = i.RepairParts.Select(j => new RepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.PartsDictionary.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name
                    }).ToList()
                }).ToList();
                return serviceRepairs;
            }
        }

        public List<ServiceRepairHistoryDto> GetAllRepairHistory()
        {
            using (var db = new ModelContext())
            {
                var serviceRepairHistories = db.ServiceRepair.Select(i => new ServiceRepairHistoryDto()
                {
                    Id = i.Id,
                    CarId = i.CarId,
                    CustomerName = i.Car.Customer.Name,
                    CustomerPhone = i.Car.Customer.MobilePhone ?? i.Car.Customer.FixPhone,
                    CarVIN = i.Car.VIN,
                    CurrentMileage = i.Car.CurrentMileage.HasValue ? i.Car.CurrentMileage.ToString():"",
                    CarPlateNum = i.Car.PlateNum,
                    BillNo = i.BillNo,
                    ServiceRepairState = i.ServiceRepairState,
                    ServiceType = i.ServiceType,
                    ServiceDateTime = i.ServiceDateTime,
                    LeaveTime = i.LeaveTime,
                    ServiceAdvisorId = i.ServiceAdvisorId,
                    ServiceAdvisorName = i.ServiceAdvisor.Name,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    RepairDescription = i.RepairDescription,
                    CustomerDescription = i.CustomerDescription,
                    ServiceRepairItem = i.ServiceRepairItem.Select(j => new ServiceRepairItemDto()
                    {
                        Id = j.Id,
                        ServiceRepairId = j.ServiceRepairId,
                        RepairItemId = j.RepairItemId,
                        RepairItemName = j.RepairItem.Name,
                        WorkHour = j.WorkHour,
                        Price = j.Price,
                        MainOperatorId = j.MainOperatorId,
                        MainOperatorName = j.MainOperator.Name,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        Description = j.Description
                    }).ToList(),
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.PartsDictionary.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name

                    }).ToList(),
                    RepairParts = i.RepairParts.Select(j => new RepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.PartsDictionary.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name
                    }).ToList()
                }).ToList();
                return serviceRepairHistories;
            }
        }

        public List<ServiceRepairHistoryDto> GetHistoryRepairByCarId(Guid carId)
        {
            using (var db = new ModelContext())
            {
                var serviceRepairHistories = db.ServiceRepair.Where(i=>i.CarId == carId).Select(i => new ServiceRepairHistoryDto()
                {
                    Id = i.Id,
                    CarId = i.CarId,
                    CustomerName = i.Car.Customer.Name,
                    CustomerPhone = i.Car.Customer.MobilePhone ?? i.Car.Customer.FixPhone,
                    CarVIN = i.Car.VIN,
                    CurrentMileage = i.Car.CurrentMileage.HasValue ? i.Car.CurrentMileage.ToString() : "",
                    CarPlateNum = i.Car.PlateNum,
                    BillNo = i.BillNo,
                    ServiceRepairState = i.ServiceRepairState,
                    ServiceType = i.ServiceType,
                    ServiceWashState = i.ServiceWashState,
                    ServiceDateTime = i.ServiceDateTime,
                    LeaveTime = i.LeaveTime,
                    ServiceAdvisorId = i.ServiceAdvisorId,
                    ServiceAdvisorName = i.ServiceAdvisor.Name,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    RepairDescription = i.RepairDescription,
                    CustomerDescription = i.CustomerDescription,
                    ServiceRepairItem = i.ServiceRepairItem.Select(j => new ServiceRepairItemDto()
                    {
                        Id = j.Id,
                        ServiceRepairId = j.ServiceRepairId,
                        RepairItemId = j.RepairItemId,
                        RepairItemName = j.RepairItem.Name,
                        WorkHour = j.WorkHour,
                        Price = j.Price,
                        MainOperatorId = j.MainOperatorId,
                        MainOperatorName = j.MainOperator.Name,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        Description = j.Description
                    }).ToList(),
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,

                    }).ToList(),
                    RepairParts = i.RepairParts.Select(j => new RepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                    }).ToList(),
                    ServiceWashItems = i.ServiceWashItems.Select(j => new ServiceWashItemDto()
                    {
                        Id = j.Id,
                        WashItemId = j.WashItemId,
                        WashItemName = j.WashItem.Name,
                        WashItemPrice = j.WashItem.Price,
                        ServiceRepairId = j.ServiceRepairId
                    }).ToList()
                }).ToList();
                return serviceRepairHistories;
            }
        }

        public ResModel TurnToRepair(Guid serviceRepairId, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairId);
                if (serviceRepair == null)
                {
                    return new ResModel(){Msg = "转维修失败，未找到该维修单",Success = false};
                }

                if (serviceRepair.ServiceRepairState != ServiceRepairState.登记)
                {
                    return new ResModel() { Msg = "转维修失败，该维修单已作废或不是登记状态", Success = false };
                }

                try
                {
                    serviceRepair.ServiceRepairState = ServiceRepairState.在修;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "转维修失败", Success = false };
                }
                return new ResModel() { Msg = "转维修成功", Success = true };
            }
        }

        public ResModel TurnToFinish(Guid serviceRepairId, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairId);
                if (serviceRepair == null)
                {
                    return new ResModel() { Msg = "竣工失败，未找到该维修单", Success = false };
                }
                if (serviceRepair.ServiceRepairState != ServiceRepairState.在修)
                {
                    return new ResModel() { Msg = "竣工失败，该维修单状态已竣工或未转在修", Success = false };
                }

                using (var scope=new TransactionScope())
                {
                    try
                    {
                        serviceRepair.ServiceRepairState = ServiceRepairState.竣工;
                        db.SaveChanges();
                        foreach (var repairPart in serviceRepair.RepairParts)
                        {
                            var parts = db.Parts.FirstOrDefault(i => i.Id == repairPart.PartsId);
                            if (parts != null)
                            {
                                parts.Count -= repairPart.Count;
                                if (parts.Count < 0)
                                {
                                    return new ResModel() { Msg = "竣工保存失败，存在选取的配件数量高于库存的情况", Success = false };
                                }
                            }
                        }
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "竣工失败", Success = false };
                    }
                    return new ResModel() { Msg = "竣工成功", Success = true, Data = new { ServiceRepairId = serviceRepair.Id } };
                }
            }
        }

        public ResModel TurnToUnFinish(Guid serviceRepairId, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairId);
                if (serviceRepair == null)
                {
                    return new ResModel() { Msg = "取消竣工失败，未找到该维修单", Success = false };
                }

                if (serviceRepair.ServiceRepairState != ServiceRepairState.竣工)
                {
                    return new ResModel() { Msg = "取消竣工失败，该维修单不是竣工状态", Success = false };
                }

                try
                {
                    serviceRepair.ServiceRepairState = ServiceRepairState.在修;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "取消竣工失败", Success = false };
                }
                return new ResModel() { Msg = "取消竣工成功", Success = true };
            }
        }

        public ResModel TurnToInvalid(Guid serviceRepairId, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairId);
                if (serviceRepair == null)
                {
                    return new ResModel() { Msg = "作废失败，未找到该维修(洗车)单", Success = false };
                }

                if (serviceRepair.ServiceType == ServiceType.洗车)
                {
                    if (serviceRepair.ServiceWashState == ServiceWashState.作废)
                    {
                        return new ResModel() { Msg = "作废失败，该维修(洗车)单状态为作废状态", Success = false };
                    }
                }
                else
                {
                    if (serviceRepair.ServiceRepairState == ServiceRepairState.作废)
                    {
                        return new ResModel() { Msg = "作废失败，该维修(洗车)单状态为作废状态", Success = false };
                    }
                }
                
                try
                {
                    if (serviceRepair.ServiceType == ServiceType.洗车)
                    {
                        serviceRepair.ServiceWashState = ServiceWashState.作废;
                    }
                    else
                    {
                        serviceRepair.ServiceRepairState = ServiceRepairState.作废;
                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "作废失败", Success = false };
                }
                return new ResModel() { Msg = "作废成功", Success = true };
            }
        }

        public ResModel TurnToAccount(Guid serviceRepairId, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairId);
                if (serviceRepair == null)
                {
                    return new ResModel() { Msg = "结算失败，未找到该维修单", Success = false };
                }

                if (serviceRepair.ServiceRepairState != ServiceRepairState.竣工)
                {
                    return new ResModel() { Msg = "结算失败，该维修单不是竣工状态", Success = false };
                }

                try
                {
                    serviceRepair.ServiceRepairState = ServiceRepairState.结算;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "结算失败", Success = false };
                }
                return new ResModel() { Msg = "结算成功", Success = true };
            }
        }

        public ResModel TurnToCash(Guid serviceRepairId, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairId);
                if (serviceRepair == null)
                {
                    return new ResModel() { Msg = "收银失败，未找到该维修单", Success = false };
                }

                if (serviceRepair.ServiceRepairState != ServiceRepairState.结算)
                {
                    return new ResModel() { Msg = "收银失败，该维修单不是竣工状态", Success = false };
                }

                try
                {
                    serviceRepair.ServiceRepairState = ServiceRepairState.收银;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "收银失败", Success = false };
                }
                return new ResModel() { Msg = "收银成功", Success = true };
            }
        }

        public ResModel TurnToLeave(Guid serviceRepairId, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairId);
                if (serviceRepair == null)
                {
                    return new ResModel() { Msg = "出厂失败，未找到该维修单", Success = false };
                }

                if (serviceRepair.ServiceRepairState != ServiceRepairState.收银)
                {
                    return new ResModel() { Msg = "出厂失败，该维修单还未收银", Success = false };
                }

                try
                {
                    serviceRepair.ServiceRepairState = ServiceRepairState.出厂;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "出厂失败", Success = false };
                }
                return new ResModel() { Msg = "出厂成功", Success = true };
            }
        }
        public ResModel SaveAndFinish(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            var res=UpdateServiceRepair(serviceRepairDto, operationUser);
            if (!res.Success)
            {
                return new ResModel(){Msg = "竣工保存失败",Success = false};
            }

            using (var db=new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairDto.Id);
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        serviceRepair.ServiceRepairState = ServiceRepairState.竣工;
                        db.SaveChanges();
                        foreach (var repairPart in serviceRepair.RepairParts)
                        {
                            var parts = db.Parts.FirstOrDefault(i => i.Id == repairPart.PartsId);
                            if (parts != null)
                            {
                                parts.Count -= repairPart.Count;
                                if (parts.Count < 0)
                                {
                                    return new ResModel(){Msg = "竣工保存失败，存在选取的配件数量高于库存的情况",Success = false};
                                }
                            }
                        }
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "竣工保存失败", Success = false };
                    }
                    return new ResModel() { Msg = "竣工保存成功", Success = true, Data = new { ServiceRepairId = serviceRepair.Id } };
                }
            }
        }

        public ResModel SaveAndAccount(ServiceRepairAccountTicketDto ticketDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var serviceRepair =
                    db.ServiceRepair.FirstOrDefault(i => i.Id == ticketDto.ServiceRepairId);
                if (serviceRepair == null)
                {
                    return new ResModel(){Msg = "结算失败，未找到该维修单",Success = false};
                }
                var serviceRepairAccountTicket=new ServiceRepairAccountTicket()
                {
                    Id = Guid.NewGuid(),
                    ServiceRepairId = serviceRepair.Id,
                    ManagementMoney = ticketDto.ManagementMoney,
                    OtherMoney = ticketDto.OtherMoney,
                    TaxMoney = ticketDto.TaxMoney,
                    WorkHourDiscount = ticketDto.WorkHourDiscount,
                    PartsDiscount = ticketDto.PartsDiscount,
                    ManagementDiscount = ticketDto.ManagementDiscount,
                    TotalMoney = ticketDto.TotalMoney,
                    MoveLittle = ticketDto.MoveLittle,
                    ShouldPay = ticketDto.ShouldPay,
                    CreditPay = ticketDto.CreditPay,
                    RealPay = ticketDto.RealPay
                };
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        serviceRepair.ServiceRepairState = ServiceRepairState.结算;
                        db.ServiceRepairAccountTicket.Add(serviceRepairAccountTicket);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "结算失败", Success = false };
                    }
                    return new ResModel() { Msg = "结算成功", Success = true, Data = new { ServiceRepairId = serviceRepair.Id } };
                }
            }
        }
        public ResModel SaveAndCash(ServiceRepairCashTicketDto serviceRepairCashTicketDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var serviceRepairAccountTicket = db.ServiceRepairAccountTicket.FirstOrDefault(i =>
                    i.Id == serviceRepairCashTicketDto.ServiceRepairAccountTicketId);
                if (serviceRepairAccountTicket == null)
                {
                    return new ResModel(){Msg = "收银失败，未找到收银的结算单",Success = false};
                }
                if (serviceRepairAccountTicket.ServiceRepair.ServiceRepairState != ServiceRepairState.结算)
                {
                    return new ResModel() { Msg = "收银失败，该维修单的状态不是结算状态", Success = false };
                }
                var serviceRepairCashTicket=new ServiceRepairCashTicket()
                {
                    Id = Guid.NewGuid(),
                    ServiceRepairAccountTicketId = serviceRepairCashTicketDto.ServiceRepairAccountTicketId,
                    ServiceTicketTypeId = serviceRepairCashTicketDto.ServiceTicketTypeId,
                    TaxBillNo = serviceRepairCashTicketDto.TaxBillNo,
                    ShouldPay = serviceRepairCashTicketDto.ShouldPay,
                    RealPay = serviceRepairCashTicketDto.RealPay,
                    BackLittle = serviceRepairCashTicketDto.BackLittle,
                    
                };
                var serviceRpairPayments = serviceRepairCashTicketDto.ServiceRepairPayments.Select(i =>
                    new ServiceRpairPayment()
                    {
                        Id = Guid.NewGuid(),
                        ServiceRepairCashTicketId = serviceRepairCashTicket.Id,
                        PaymentTypeId = i.PaymentTypeId,
                        Money = i.Money

                    });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.ServiceRepairCashTicket.Add(serviceRepairCashTicket);
                        serviceRepairAccountTicket.ServiceRepair.ServiceRepairState = ServiceRepairState.收银;
                        db.SaveChanges();
                        db.ServiceRpairPayment.AddRange(serviceRpairPayments);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "收银失败", Success = false };
                    }
                    return new ResModel() { Msg = "收银成功", Success = true, Data = new { ServiceRepairId = serviceRepairAccountTicket.ServiceRepair.Id } };
                }
            }
        }

        public ResModel WashCarSaveAndCash(ServiceRepairCashTicketDto serviceRepairCashTicketDto, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairCashTicketDto.ServiceRepair.Id);
                var car = db.Car.FirstOrDefault(i => i.Id == serviceRepairCashTicketDto.ServiceRepair.Car.Id);
                if (serviceRepair == null)
                {
                    return new ResModel() { Msg = "收银失败，未找到该洗车单", Success = false };
                }
                if (serviceRepair.ServiceType!=ServiceType.洗车)
                {
                    return new ResModel() { Msg = "收银失败，该单不是洗车单", Success = false };
                }
                if (serviceRepair.ServiceWashState != ServiceWashState.登记)
                {
                    return new ResModel() { Msg = "收银失败，该洗车单的状态不是登记状态", Success = false };
                }
                var serviceRepairCashTicket = new ServiceRepairCashTicket()
                {
                    Id = Guid.NewGuid(),
                    ServiceRepairId = serviceRepair.Id,
                    ShouldPay = serviceRepairCashTicketDto.ShouldPay,
                    WashCarDiscount = serviceRepairCashTicketDto.WashCarDiscount,
                    WashCarCreditPay = serviceRepairCashTicketDto.WashCarCreditPay,
                    RealPay = serviceRepairCashTicketDto.RealPay,
                    BackLittle = serviceRepairCashTicketDto.BackLittle,
                    Description = serviceRepairCashTicketDto.Description
                };
                var serviceWashItem = new ServiceWashItem()
                {
                    Id = Guid.NewGuid(),
                    WashItemId = serviceRepairCashTicketDto.ServiceRepair.ServiceWashItem.WashItemId,
                    ServiceRepairId = serviceRepair.Id
                };
                var serviceRpairPayments = serviceRepairCashTicketDto.ServiceRepairPayments.Select(i =>
                    new ServiceRpairPayment()
                    {
                        Id = Guid.NewGuid(),
                        ServiceRepairCashTicketId = serviceRepairCashTicket.Id,
                        PaymentTypeId = i.PaymentTypeId,
                        Money = i.Money

                    });
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        //进出厂信息
                        serviceRepair.EstimateLeaveTime = serviceRepairCashTicketDto.ServiceRepair.EstimateLeaveTime;
                        serviceRepair.WashCarMainOperatorId = serviceRepairCashTicketDto.ServiceRepair.WashCarMainOperatorId;
                        serviceRepair.ServiceAdvisorId= serviceRepairCashTicketDto.ServiceRepair.ServiceAdvisorId;
                        serviceRepair.ServiceWashState = ServiceWashState.出厂;

                        //车辆信息
                        car.CurrentMileage = serviceRepairCashTicketDto.ServiceRepair.Car.CurrentMileage;
                        car.NextMaintainMileage = serviceRepairCashTicketDto.ServiceRepair.Car.NextMaintainMileage;
                        car.NextMaintainDate = serviceRepairCashTicketDto.ServiceRepair.Car.NextMaintainDate;
                        car.InsuranceExpireTime = serviceRepairCashTicketDto.ServiceRepair.Car.InsuranceExpireTime;
                        car.YearlyCheckTime = serviceRepairCashTicketDto.ServiceRepair.Car.YearlyCheckTime;
                        db.SaveChanges();

                        db.ServiceRepairCashTicket.Add(serviceRepairCashTicket);
                        //洗车项目信息
                        db.ServiceWashItem.Add(serviceWashItem);
                        db.ServiceRpairPayment.AddRange(serviceRpairPayments);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "收银失败", Success = false };
                    }
                    return new ResModel() { Msg = "收银成功", Success = true, Data = new { ServiceRepairId = serviceRepair.Id } };
                }
            }
        }

        public ResModel UpdateServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairDto.Id);
                if (serviceRepair == null)
                {
                    return new ResModel(){Msg = "更新维修单失败，未找到该维修单",Success = false};
                }
                var car = serviceRepair.Car ?? db.Car.FirstOrDefault(i => i.Id == serviceRepairDto.CarId);
                var serviceRepairItem = serviceRepairDto.ServiceRepairItem.Select(i => new ServiceRepairItem()
                {
                    Id = Guid.NewGuid(),
                    RepairItemId = i.RepairItemId,
                    ServiceRepairId = serviceRepair.Id,
                    WorkHour = i.WorkHour,
                    Price = i.Price,
                    MainOperatorId = i.MainOperatorId,
                    ServiceAccountTypeId = i.ServiceAccountTypeId,
                    Description = i.Description
                });
                var repairParts = serviceRepairDto.RepairParts.Select(i => new RepairParts()
                {
                    Id = Guid.NewGuid(),
                    PartsId = i.PartsId,
                    ServiceRepairId = serviceRepair.Id,
                    Count = i.Count,
                    Price = i.Price,
                    ServiceAccountTypeId = i.ServiceAccountTypeId
                });
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        serviceRepair.EstimateLeaveTime = serviceRepairDto.EstimateLeaveTime;
                        serviceRepair.ServiceAdvisorId = serviceRepairDto.ServiceAdvisorId;
                        serviceRepair.RepairTypeId = serviceRepairDto.RepairTypeId;
                        serviceRepair.ContactName = serviceRepairDto.ContactName;
                        serviceRepair.ContactPhone = serviceRepairDto.ContactPhone;
                        serviceRepair.RepairDescription = serviceRepairDto.RepairDescription;
                        serviceRepair.CustomerDescription = serviceRepairDto.CustomerDescription;
                        serviceRepair.Description = serviceRepairDto.Description;

                        car.CurrentMileage = serviceRepairDto.Car.CurrentMileage;
                        car.NextMaintainMileage = serviceRepairDto.Car.NextMaintainMileage;
                        car.NextMaintainDate = serviceRepairDto.Car.NextMaintainDate;
                        car.EngineModelNo = serviceRepairDto.Car.EngineModelNo;
                        car.EngineNo = serviceRepairDto.Car.EngineNo;
                        car.CarRegisterTime = serviceRepairDto.Car.CarRegisterTime;
                        car.InsuranceOrg = serviceRepairDto.Car.InsuranceOrg;
                        car.InsuranceExpireTime = serviceRepairDto.Car.InsuranceExpireTime;
                        car.YearlyCheckTime = serviceRepairDto.Car.YearlyCheckTime;

                        db.ServiceRepairItem.RemoveRange(serviceRepair.ServiceRepairItem);
                        db.RepairParts.RemoveRange(serviceRepair.RepairParts);
                        db.SaveChanges();
                        db.ServiceRepairItem.AddRange(serviceRepairItem);
                        db.RepairParts.AddRange(repairParts);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "更新维修单失败", Success = false };
                    }
                    return new ResModel() { Msg = "更新维修单成功", Success = true,Data = new{ServiceRepairId=serviceRepair.Id}};
                }
            }
        } 
    }
}
