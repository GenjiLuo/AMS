using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AMS.Model.dto;
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
                    BookingTime = i.BookingTime,
                    CarId = i.CarId,
                    CarPlateNum = i.Car.PlateNum,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    ContactAddress = i.ContactAddress,
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
                        PartsName = j.Parts.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        Price = j.Price
                    }).ToList(),
                    ServiceRepairItem = i.ServiceRepairItem.Select(k => new ServiceRepairItemDto()
                    {
                        Id = k.Id,
                        RepairItemId = k.RepairItemId,
                        RepairItemName = k.RepairItem.Name,
                        WordHour = k.WordHour,
                        Price = k.Price,
                        MainOperatorId = k.MainOperatorId,
                        MainOperatorName = k.MainOperator.Name
                    }).ToList()
                }).ToList();
                return serviceBookings;
            }
        }

        public ResModel AddServiceBooking(ServiceBookingDto serviceBookingDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var serviceBooking = new ServiceBooking()
                {
                    Id = Guid.NewGuid(),
                    BookingTime = DateTime.Now,
                    CarId = serviceBookingDto.CarId,
                    ContactName = serviceBookingDto.ContactName,
                    ContactPhone = serviceBookingDto.ContactPhone,
                    ContactAddress = serviceBookingDto.ContactAddress,
                    ServiceAdvisorId = serviceBookingDto.ServiceAdvisorId,
                    RepairTypeId = serviceBookingDto.RepairTypeId,
                    CustomerDescription = serviceBookingDto.CustomerDescription,
                    RepairDescription = serviceBookingDto.RepairDescription,
                };
                var estimateRepairParts = serviceBookingDto.EstimateRepairParts.Select(i => new EstimateRepairParts()
                {
                    Id = Guid.NewGuid(),
                    PartsId = i.PartsId,
                    ServiceBookingId = serviceBooking.Id,
                    Count = i.Count,
                    Price = i.Price
                });
                var serviceRepairItem = serviceBookingDto.ServiceRepairItem.Select(i => new ServiceRepairItem()
                {
                    Id = Guid.NewGuid(),
                    RepairItemId = i.RepairItemId,
                    WordHour = i.WordHour,
                    Price = i.Price,
                    MainOperatorId = i.MainOperatorId,
                    ServiceBookingId = serviceBooking.Id
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
                    BookingTime = i.BookingTime,
                    CarId = i.CarId,
                    CarPlateNum = i.Car.PlateNum,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    ContactAddress = i.ContactAddress,
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
                        PartsName = j.Parts.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        Price = j.Price
                    }).ToList(),
                    ServiceRepairItem = i.ServiceRepairItem.Select(k => new ServiceRepairItemDto()
                    {
                        Id = k.Id,
                        RepairItemId = k.RepairItemId,
                        RepairItemName = k.RepairItem.Name,
                        WordHour = k.WordHour,
                        Price = k.Price,
                        MainOperatorId = k.MainOperatorId,
                        MainOperatorName = k.MainOperator.Name
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
                serviceBooking.BookingTime = serviceBookingDto.BookingTime;
                serviceBooking.CarId = serviceBookingDto.CarId;
                serviceBooking.ContactName = serviceBookingDto.ContactName;
                serviceBooking.ContactPhone = serviceBookingDto.ContactPhone;
                serviceBooking.ContactAddress = serviceBookingDto.ContactAddress;
                serviceBooking.ServiceAdvisorId = serviceBookingDto.ServiceAdvisorId;
                serviceBooking.RepairTypeId = serviceBookingDto.RepairTypeId;
                serviceBooking.CustomerDescription = serviceBookingDto.CustomerDescription;
                serviceBooking.RepairDescription = serviceBookingDto.RepairDescription;
                var estimateRepairParts = serviceBookingDto.EstimateRepairParts.Select(i => new EstimateRepairParts()
                {
                    Id = Guid.NewGuid(),
                    PartsId = i.PartsId,
                    ServiceBookingId = serviceBooking.Id,
                    Count = i.Count,
                    Price = i.Price
                });
                var serviceRepairItem = serviceBookingDto.ServiceRepairItem.Select(i => new ServiceRepairItem()
                {
                    Id = Guid.NewGuid(),
                    RepairItemId = i.RepairItemId,
                    WordHour = i.WordHour,
                    Price = i.Price,
                    MainOperatorId = i.MainOperatorId,
                    ServiceBookingId = serviceBooking.Id
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
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
                    BookingTime = i.BookingTime,
                    CarId = i.CarId,
                    CarPlateNum = i.Car.PlateNum,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    ContactAddress = i.ContactAddress,
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
                        PartsName = j.Parts.Name,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        Price = j.Price
                    }).ToList(),
                    ServiceRepairItem = i.ServiceRepairItem.Select(k => new ServiceRepairItemDto()
                    {
                        Id = k.Id,
                        RepairItemId = k.RepairItemId,
                        RepairItemName = k.RepairItem.Name,
                        WordHour = k.WordHour,
                        Price = k.Price,
                        MainOperatorId = k.MainOperatorId,
                        MainOperatorName = k.MainOperator.Name
                    }).ToList()
                }).ToList();
                return serviceBookings;
            }
        }
    }
}
