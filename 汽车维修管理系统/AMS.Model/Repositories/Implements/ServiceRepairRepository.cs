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
                    BillNo = billNo,
                    BillNoIndex = index,
                    ServiceBookingId = serviceRepairDto.ServiceBookingId,
                    ServiceDateTime = serviceRepairDto.ServiceDateTime,
                    EstimateLeaveTime = serviceRepairDto.EstimateLeaveTime,
                    LeaveTime = serviceRepairDto.LeaveTime,
                    ServiceAdvisorId = serviceRepairDto.ServiceAdvisorId,
                    ContactName = serviceRepairDto.ContactName,
                    ContactPhone = serviceRepairDto.ContactPhone,
                    RepairDescription = serviceRepairDto.RepairDescription,
                    CustomerDescription = serviceRepairDto.CustomerDescription,
                    CreateTime = DateTime.Now
                };
                var serviceRepairItem = serviceRepairDto.ServiceRepairItem.Select(i => new ServiceRepairItem()
                {
                    Id = Guid.NewGuid(),
                    RepairItemId = i.RepairItemId,
                    ServiceRepairId = serviceRepair.Id,
                    ServiceAccountTypeId = i.ServiceAccountTypeId,
                    WorkHour = i.WorkHour,
                    Price = i.Price,
                    MainOperatorId = i.MainOperatorId,
                    Description = i.Description
                });
                var repairParts = serviceRepairDto.RepairParts.Select(i => new RepairParts()
                {
                    Id = Guid.NewGuid(),
                    PartsId = i.PartsId,
                    ServiceRepairId = serviceRepair.Id,
                    ServiceAccountTypeId = i.ServiceAccountTypeId,
                    Count = i.Count,
                    Price = i.Price
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.ServiceRepair.Add(serviceRepair);
                        db.SaveChanges();
                        db.ServiceRepairItem.AddRange(serviceRepairItem);
                        db.RepairParts.AddRange(repairParts);
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
                        PartsName = j.Parts.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,

                    }).ToList(),
                    RepairParts = i.RepairParts.Select(j=>new RepairPartsDto()
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
                        PartsName = j.Parts.PartsDictionary.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name
                    }).ToList()
                }).FirstOrDefault();
                return serviceRepair;
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
                    }).ToList()
                }).ToList();
                return serviceRepairHistories;
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
                try
                {
                    serviceRepair.ServiceRepairState = ServiceRepairState.竣工;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "竣工失败", Success = false };
                }
                return new ResModel() { Msg = "竣工成功", Success = true, Data = new { ServiceRepairId = serviceRepair.Id } };
            }
        }

        public ResModel TurnToInvalid(Guid serviceRepairId, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairId);
                if (serviceRepair == null)
                {
                    return new ResModel() { Msg = "作废失败，未找到该维修单", Success = false };
                }
                if (serviceRepair.ServiceRepairState == ServiceRepairState.作废)
                {
                    return new ResModel() { Msg = "作废失败，该维修单状态为作废状态", Success = false };
                }
                try
                {
                    serviceRepair.ServiceRepairState = ServiceRepairState.作废;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "作废失败", Success = false };
                }
                return new ResModel() { Msg = "作废成功", Success = true };
            }
        }

        public ResModel Finish(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            var res=UpdateServiceRepair(serviceRepairDto, operationUser);
            if (!res.Success)
            {
                return new ResModel(){Msg = "竣工失败",Success = false};
            }

            using (var db=new ModelContext())
            {
                var serviceRepair = db.ServiceRepair.FirstOrDefault(i => i.Id == serviceRepairDto.Id);
                try
                {
                    serviceRepair.ServiceRepairState = ServiceRepairState.竣工;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "竣工失败", Success = false };
                }
                return new ResModel() { Msg = "竣工成功", Success = true, Data = new { ServiceRepairId = serviceRepair.Id } };
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
