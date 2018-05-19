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
    public class ServiceBookingRepository : IServiceBookingRepository
    {
        public List<ServiceBookingDto> GetAllServiceBooking()
        {
            using (var db=new ModelContext())
            {
                var serviceBookings = db.ServiceBooking.Select(i => new ServiceBookingDto()
                {
                    Id = i.Id,
                    BookingCreateTime = i.BookingCreateTime,
                    ServiceRepairTime = i.ServiceRepairTime,
                    ServiceBookingState = i.ServiceBookingState,
                    BillNo = i.BillNo,
                    CarId = i.CarId,
                    CarPlateNum = i.Car.PlateNum,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    ContactAddress = i.ContactAddress,
                    CompanyName = i.CompanyName,
                    ServiceAdvisorId = i.ServiceAdvisorId,
                    ServiceAdvisorName = i.ServiceAdvisor.Name,
                    RepairTypeId = i.RepairTypeId,
                    RepairTypeName = i.RepairType.Name,
                    CustomerDescription = i.CustomerDescription,
                    RepairDescription = i.RepairDescription,
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsName = j.Parts.PartsDictionary.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        MaxCount = j.Parts.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name
                    }).ToList(),
                    ServiceRepairItem = i.ServiceRepairItem.Select(k => new ServiceRepairItemDto()
                    {
                        Id = k.Id,
                        ServiceBookingId = k.ServiceBookingId,
                        RepairItemId = k.RepairItemId,
                        RepairItemName = k.RepairItem.Name,
                        RepairItemSerNo = k.RepairItem.SerNum,
                        WorkHour = k.WorkHour,
                        Price = k.Price,
                        MainOperatorId = k.MainOperatorId,
                        MainOperatorName = k.MainOperator.Name,
                        ServiceAccountTypeId = k.ServiceAccountTypeId,
                        ServiceAccountTypeName = k.ServiceAccountType.Name,
                        Description = k.Description
                    }).ToList()
                }).ToList();
                return serviceBookings;
            }
        }

        public ResModel AddServiceBooking(ServiceBookingDto serviceBookingDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var billNo = "";
                var lastIndex = 0;
                var dateFormat = "";
                var index = 0;
                var indexStr = "";
                var bookingBill = db.BillNoSetting.FirstOrDefault(i => i.Name == BillTypeName.预约单号.ToString());
                if (bookingBill.DailyReset)
                {
                    var lastBooking = db.ServiceBooking.Where(i => i.CreateTime.Value.Day == DateTime.Now.Day).OrderByDescending(i => i.CreateTime).FirstOrDefault();
                    lastIndex = lastBooking?.BillNoIndex ?? 0;
                }
                else
                {
                    var lastBooking = db.ServiceBooking.OrderByDescending(i => i.CreateTime).FirstOrDefault();
                    lastIndex = lastBooking?.BillNoIndex ?? 0;
                }
                index = lastIndex + 1;
                indexStr = index.ToString();
                switch (bookingBill.SerNoLength)
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
                switch (bookingBill.DateFormat)
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
                billNo = bookingBill.Prefix + dateFormat + indexStr;
                var serviceBooking = new ServiceBooking()
                {
                    Id = Guid.NewGuid(),
                    BillNo=billNo,
                    BillNoIndex = index,
                    BookingCreateTime = DateTime.Now,
                    ServiceBookingState = ServiceBookingState.待接车,
                    ServiceRepairTime = serviceBookingDto.ServiceRepairTime,
                    CarId = serviceBookingDto.CarId,
                    ContactName = serviceBookingDto.ContactName,
                    ContactPhone = serviceBookingDto.ContactPhone,
                    ContactAddress = serviceBookingDto.ContactAddress,
                    CompanyName = serviceBookingDto.CompanyName,
                    ServiceAdvisorId = serviceBookingDto.ServiceAdvisorId,
                    RepairTypeId = serviceBookingDto.RepairTypeId,
                    CustomerDescription = serviceBookingDto.CustomerDescription,
                    RepairDescription = serviceBookingDto.RepairDescription,
                    Remark = serviceBookingDto.Remark,
                    CreateTime = DateTime.Now
                };
                var estimateRepairParts = serviceBookingDto.EstimateRepairParts.Select(i => new EstimateRepairParts()
                {
                    Id = Guid.NewGuid(),
                    PartsId = i.PartsId,
                    ServiceAccountTypeId = i.ServiceAccountTypeId,
                    ServiceBookingId = serviceBooking.Id,
                    Count = i.Count,
                    Price = i.Price
                });
                var serviceRepairItem = serviceBookingDto.ServiceRepairItem.Select(i => new ServiceRepairItem()
                {
                    Id = Guid.NewGuid(),
                    RepairItemId = i.RepairItemId,
                    WorkHour = i.WorkHour,
                    Price = i.Price,
                    ServiceBookingId = serviceBooking.Id,
                    ServiceAccountTypeId = i.ServiceAccountTypeId,
                    Description = i.Description
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.ServiceBooking.Add(serviceBooking);
                        db.SaveChanges();
                        db.EstimateRepairParts.AddRange(estimateRepairParts);
                        db.ServiceRepairItem.AddRange(serviceRepairItem);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "添加添加失败",Success = false};
                    }
                    return new ResModel() { Msg = "添加添加成功", Success = true };
                }
            }
        }

        public ServiceBookingDto GetOneServiceBooking(Guid serviceBookingId)
        {
            using (var db = new ModelContext())
            {
                var serviceBooking = db.ServiceBooking.Where(i => i.Id == serviceBookingId).Select(i => new ServiceBookingDto()
                {
                    Id = i.Id,
                    BookingCreateTime = i.BookingCreateTime,
                    ServiceRepairTime = i.ServiceRepairTime,
                    ServiceBookingState = i.ServiceBookingState,
                    BillNo = i.BillNo,
                    CarId = i.CarId,
                    CarPlateNum = i.Car.PlateNum,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    ContactAddress = i.ContactAddress,
                    CompanyName = i.CompanyName,
                    ServiceAdvisorId = i.ServiceAdvisorId,
                    ServiceAdvisorName = i.ServiceAdvisor.Name,
                    RepairTypeId = i.RepairTypeId,
                    RepairTypeName = i.RepairType.Name,
                    CustomerDescription = i.CustomerDescription,
                    RepairDescription = i.RepairDescription,
                    Remark = i.Remark,
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsName = j.Parts.PartsDictionary.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        MaxCount = j.Parts.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name
                    }).ToList(),
                    ServiceRepairItem = i.ServiceRepairItem.Select(k => new ServiceRepairItemDto()
                    {
                        Id = k.Id,
                        RepairItemId = k.RepairItemId,
                        RepairItemName = k.RepairItem.Name,
                        RepairItemSerNo = k.RepairItem.SerNum,
                        ServiceBookingId = k.ServiceBookingId,
                        WorkHour = k.WorkHour,
                        Price = k.Price,
                        MainOperatorId = k.MainOperatorId,
                        MainOperatorName = k.MainOperator.Name,
                        ServiceAccountTypeId = k.ServiceAccountTypeId,
                        ServiceAccountTypeName = k.ServiceAccountType.Name,
                        Description = k.Description
                    }).ToList()
                }).FirstOrDefault();
                return serviceBooking;
            }
        }

        public ResModel UpdateServiceBooking(ServiceBookingDto serviceBookingDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var serviceBooking = db.ServiceBooking.FirstOrDefault(i => i.Id == serviceBookingDto.Id);
                if (serviceBooking == null)
                {
                    return new ResModel(){Msg = "更新预约单失败，未找到该预约单",Success = false};
                }
               
                var estimateRepairParts = serviceBookingDto.EstimateRepairParts.Select(i => new EstimateRepairParts()
                {
                    Id = Guid.NewGuid(),
                    PartsId = i.PartsId,
                    ServiceBookingId = serviceBooking.Id,
                    Count = i.Count,
                    Price = i.Price,
                    ServiceAccountTypeId = i.ServiceAccountTypeId
                });
                var serviceRepairItem = serviceBookingDto.ServiceRepairItem.Select(i => new ServiceRepairItem()
                {
                    Id = Guid.NewGuid(),
                    RepairItemId = i.RepairItemId,
                    WorkHour = i.WorkHour,
                    Price = i.Price,
                    ServiceBookingId = serviceBooking.Id,
                    ServiceAccountTypeId = i.ServiceAccountTypeId,
                    Description = i.Description
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        serviceBooking.ServiceRepairTime = serviceBookingDto.ServiceRepairTime;
                        serviceBooking.CarId = serviceBookingDto.CarId;
                        serviceBooking.ContactName = serviceBookingDto.ContactName;
                        serviceBooking.ContactPhone = serviceBookingDto.ContactPhone;
                        serviceBooking.ContactAddress = serviceBookingDto.ContactAddress;
                        serviceBooking.CompanyName = serviceBookingDto.CompanyName;
                        serviceBooking.ServiceAdvisorId = serviceBookingDto.ServiceAdvisorId;
                        serviceBooking.RepairTypeId = serviceBookingDto.RepairTypeId;
                        serviceBooking.CustomerDescription = serviceBookingDto.CustomerDescription;
                        serviceBooking.RepairDescription = serviceBookingDto.RepairDescription;
                        serviceBooking.Remark = serviceBookingDto.Remark;

                        db.EstimateRepairParts.RemoveRange(serviceBooking.EstimateRepairParts);
                        db.ServiceRepairItem.RemoveRange(serviceBooking.ServiceRepairItem);
                        db.SaveChanges();
                        db.EstimateRepairParts.AddRange(estimateRepairParts);
                        db.ServiceRepairItem.AddRange(serviceRepairItem);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "更新预约单失败",Success = false};
                    }
                    return new ResModel() { Msg = "更新预约单成功", Success = true };
                }
            }
        }

        public ResModel DeleteServiceBooking(Guid serviceBookingId)
        {
            using (var db = new ModelContext())
            {
                var serviceBooking = db.ServiceBooking.FirstOrDefault(i => i.Id == serviceBookingId);
                if (serviceBooking == null)
                {
                    return new ResModel() { Msg = "删除预约单失败，未找到该预约单", Success = false };
                }
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        db.EstimateRepairParts.RemoveRange(serviceBooking.EstimateRepairParts);
                        db.ServiceRepairItem.RemoveRange(serviceBooking.ServiceRepairItem);
                        db.SaveChanges();
                        db.ServiceBooking.Remove(serviceBooking);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "删除预约单失败", Success = false };
                    }
                    return new ResModel() { Msg = "删除预约单成功", Success = true };
                }
            }
        }

        public List<ServiceBookingDto> QueryServiceBooking(string keyword)
        {
            using (var db = new ModelContext())
            {
                var serviceBookings = db.ServiceBooking.Where(i=>i.ContactName.Contains(keyword)).Select(i => new ServiceBookingDto()
                {
                    Id = i.Id,
                    BookingCreateTime = i.BookingCreateTime,
                    ServiceRepairTime = i.ServiceRepairTime,
                    ServiceBookingState = i.ServiceBookingState,
                    BillNo = i.BillNo,
                    CarId = i.CarId,
                    CarPlateNum = i.Car.PlateNum,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    ContactAddress = i.ContactAddress,
                    CompanyName = i.CompanyName,
                    ServiceAdvisorId = i.ServiceAdvisorId,
                    ServiceAdvisorName = i.ServiceAdvisor.Name,
                    RepairTypeId = i.RepairTypeId,
                    RepairTypeName = i.RepairType.Name,
                    CustomerDescription = i.CustomerDescription,
                    RepairDescription = i.RepairDescription,
                    Remark = i.Remark,
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsName = j.Parts.PartsDictionary.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        MaxCount = j.Parts.Count,
                        Price = j.Price,
                        WarehouseName = j.Parts.Warehouse.Name,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name
                    }).ToList(),
                    ServiceRepairItem = i.ServiceRepairItem.Select(k => new ServiceRepairItemDto()
                    {
                        Id = k.Id,
                        RepairItemId = k.RepairItemId,
                        RepairItemName = k.RepairItem.Name,
                        RepairItemSerNo = k.RepairItem.SerNum,
                        WorkHour = k.WorkHour,
                        Price = k.Price,
                        MainOperatorId = k.MainOperatorId,
                        MainOperatorName = k.MainOperator.Name,
                        ServiceAccountTypeId = k.ServiceAccountTypeId,
                        ServiceAccountTypeName = k.ServiceAccountType.Name
                    }).ToList()
                }).ToList();
                return serviceBookings;
            }
        }

        public ResModel TurnToInvalid(Guid serviceBookingId)
        {
            using (var db=new ModelContext())
            {
                var serviceBooking = db.ServiceBooking.FirstOrDefault(i => i.Id == serviceBookingId);
                if (serviceBooking == null)
                {
                    return new ResModel(){Msg = "作废失败，未找到该预约单",Success = false};
                }
                if (serviceBooking.ServiceBookingState!=ServiceBookingState.待接车)
                {
                    return new ResModel() { Msg = "作废失败，该预约单已作废", Success = false };
                }

                try
                {
                    serviceBooking.ServiceBookingState = ServiceBookingState.已作废;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "作废失败", Success = false };
                }
                return new ResModel() { Msg = "作废成功", Success = true };
            }
        }

        public ResModel TurnToRepair(Guid serviceBookingId)
        {
            using (var db = new ModelContext())
            {
                var serviceBooking = db.ServiceBooking.FirstOrDefault(i => i.Id == serviceBookingId);
                if (serviceBooking == null)
                {
                    return new ResModel() { Msg = "转接车失败，未找到该预约单", Success = false };
                }

                if (serviceBooking.ServiceBookingState != ServiceBookingState.待接车)
                {
                    return new ResModel() { Msg = "转接车失败，该预约单已作废或已接车", Success = false };
                }
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
                var serviceRepair=new ServiceRepair()
                {
                    Id = Guid.NewGuid(),
                    BillNo = billNo,
                    BillNoIndex = index,
                    CarId = serviceBooking.CarId,
                    ServiceBookingId = serviceBooking.Id,
                    ServiceRepairState = ServiceRepairState.在修,
                    ServiceType = ServiceType.维修,
                    RepairTypeId = serviceBooking.RepairTypeId,
                    ServiceDateTime = DateTime.Now,
                    EstimateLeaveTime = DateTime.Now.AddDays(3),
                    ServiceAdvisorId = serviceBooking.ServiceAdvisorId,
                    ContactName = serviceBooking.ContactName,
                    ContactPhone = serviceBooking.ContactPhone,
                    RepairDescription = serviceBooking.RepairDescription,
                    CustomerDescription = serviceBooking.CustomerDescription,
                    CreateTime = DateTime.Now
                };
                var estimateRepairParts = serviceBooking.EstimateRepairParts.Select(i => new EstimateRepairParts()
                {
                    Id = Guid.NewGuid(),
                    PartsId = i.PartsId,
                    ServiceRepairId = serviceRepair.Id,
                    ServiceAccountTypeId = i.ServiceAccountTypeId,
                    Count = i.Count,
                    Price = i.Price
                });
                var serviceRepairItems = serviceBooking.ServiceRepairItem.Select(i => new ServiceRepairItem()
                {
                    Id = Guid.NewGuid(),
                    RepairItemId = i.RepairItemId,
                    ServiceRepairId = serviceRepair.Id,
                    ServiceAccountTypeId = i.ServiceAccountTypeId,
                    WorkHour = i.WorkHour,
                    Price = i.Price,
                    Description = i.Description
                });
                
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.ServiceRepair.Add(serviceRepair);
                        db.SaveChanges();
                        db.EstimateRepairParts.AddRange(estimateRepairParts);
                        db.ServiceRepairItem.AddRange(serviceRepairItems);
                        serviceBooking.ServiceBookingState = ServiceBookingState.已接车;
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "转接车失败", Success = false };
                    }
                    return new ResModel() { Msg = "转接车成功", Success = true, Data = new { ServiceRepairId = serviceRepair.Id } };
                }
            }
        }

        public List<ServiceBookingDto> GetServiceBookingByCarId(Guid carId)
        {
            using (var db = new ModelContext())
            {
                var serviceBookings = db.ServiceBooking.Where(i => i.CarId == carId).Select(i => new ServiceBookingDto()
                {
                    Id = i.Id,
                    BookingCreateTime = i.BookingCreateTime,
                    ServiceRepairTime = i.ServiceRepairTime,
                    ServiceBookingState = i.ServiceBookingState,
                    BillNo = i.BillNo,
                    CarId = i.CarId,
                    CarPlateNum = i.Car.PlateNum,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    ContactAddress = i.ContactAddress,
                    CompanyName = i.CompanyName,
                    ServiceAdvisorId = i.ServiceAdvisorId,
                    ServiceAdvisorName = i.ServiceAdvisor.Name,
                    RepairTypeId = i.RepairTypeId,
                    RepairTypeName = i.RepairType.Name,
                    CustomerDescription = i.CustomerDescription,
                    RepairDescription = i.RepairDescription,
                    Remark = i.Remark,
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsName = j.Parts.PartsDictionary.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        MaxCount = j.Parts.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name
                    }).ToList(),
                    ServiceRepairItem = i.ServiceRepairItem.Select(k => new ServiceRepairItemDto()
                    {
                        Id = k.Id,
                        RepairItemId = k.RepairItemId,
                        RepairItemName = k.RepairItem.Name,
                        RepairItemSerNo = k.RepairItem.SerNum,
                        ServiceBookingId = k.ServiceBookingId,
                        WorkHour = k.WorkHour,
                        Price = k.Price,
                        MainOperatorId = k.MainOperatorId,
                        MainOperatorName = k.MainOperator.Name,
                        ServiceAccountTypeId = k.ServiceAccountTypeId,
                        ServiceAccountTypeName = k.ServiceAccountType.Name,
                        Description = k.Description
                    }).ToList()
                }).ToList();
                return serviceBookings;
            }
        }
        public List<ServiceBookingDto> GetUnBoundServiceBookingByCarId(Guid carId)
        {
            using (var db = new ModelContext())
            {
                var serviceBookings = db.ServiceBooking.Where(i => i.CarId == carId && i.ServiceBookingState == ServiceBookingState.待接车).Select(i => new ServiceBookingDto()
                {
                    Id = i.Id,
                    BookingCreateTime = i.BookingCreateTime,
                    ServiceRepairTime = i.ServiceRepairTime,
                    ServiceBookingState = i.ServiceBookingState,
                    BillNo = i.BillNo,
                    CarId = i.CarId,
                    CarPlateNum = i.Car.PlateNum,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    ContactAddress = i.ContactAddress,
                    CompanyName = i.CompanyName,
                    ServiceAdvisorId = i.ServiceAdvisorId,
                    ServiceAdvisorName = i.ServiceAdvisor.Name,
                    RepairTypeId = i.RepairTypeId,
                    RepairTypeName = i.RepairType.Name,
                    CustomerDescription = i.CustomerDescription,
                    RepairDescription = i.RepairDescription,
                    Remark = i.Remark,
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsName = j.Parts.PartsDictionary.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        MaxCount = j.Parts.Count,
                        Price = j.Price,
                        ServiceAccountTypeId = j.ServiceAccountTypeId,
                        ServiceAccountTypeName = j.ServiceAccountType.Name,
                        WarehouseName = j.Parts.Warehouse.Name
                    }).ToList(),
                    ServiceRepairItem = i.ServiceRepairItem.Select(k => new ServiceRepairItemDto()
                    {
                        Id = k.Id,
                        RepairItemId = k.RepairItemId,
                        RepairItemName = k.RepairItem.Name,
                        RepairItemSerNo = k.RepairItem.SerNum,
                        ServiceBookingId = k.ServiceBookingId,
                        WorkHour = k.WorkHour,
                        Price = k.Price,
                        MainOperatorId = k.MainOperatorId,
                        MainOperatorName = k.MainOperator.Name,
                        ServiceAccountTypeId = k.ServiceAccountTypeId,
                        ServiceAccountTypeName = k.ServiceAccountType.Name,
                        Description = k.Description
                    }).ToList()
                }).ToList();
                return serviceBookings;
            }
        }
    }
}
