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
    public class ServiceRepairRepository : IServiceRepairRepository
    {
        public ResModel AddServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var serviceRepair = new ServiceRepair()
                {
                    Id = Guid.NewGuid(),
                    CarId = serviceRepairDto.CarId,
                    ServiceBookingId = serviceRepairDto.ServiceBookingId,
                    ServiceRepairState = serviceRepairDto.ServiceRepairState,
                    ServiceDateTime = serviceRepairDto.ServiceDateTime,
                    EstimateLeaveTime = serviceRepairDto.EstimateLeaveTime,
                    LeaveTime = serviceRepairDto.LeaveTime,
                    ServiceAdvisorId = serviceRepairDto.ServiceAdvisorId,
                    ContactName = serviceRepairDto.ContactName,
                    ContactPhone = serviceRepairDto.ContactPhone,
                    RepairDescription = serviceRepairDto.RepairDescription,
                    CustomerDescription = serviceRepairDto.CustomerDescription,
                };
                var serviceRepairItem = serviceRepairDto.ServiceRepairItem.Select(i => new ServiceRepairItem()
                {
                    Id = Guid.NewGuid(),
                    RepairItemId = i.RepairItemId,
                    ServiceRepairId = serviceRepair.Id,
                    WordHour = i.WordHour,
                    Price = i.Price,
                    MainOperatorId = i.MainOperatorId
                });
                var repairParts = serviceRepairDto.RepairParts.Select(i => new RepairParts()
                {
                    Id = Guid.NewGuid(),
                    PartsId = i.PartsId,
                    ServiceRepairId = serviceRepair.Id,
                    Count = i.Count,
                    Price = i.Count
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
                    return new ResModel() { Msg = "添加维修单成功", Success = true };
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
                    ServiceBookingId = i.ServiceBookingId,
                    ServiceRepairState = i.ServiceRepairState,
                    ServiceDateTime = DateTime.Now,
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
                        WordHour = j.WordHour,
                        Price = j.Price,
                        MainOperatorId = j.MainOperatorId,
                        MainOperatorName = j.MainOperator.Name
                    }).ToList(),
                    EstimateRepairParts = i.EstimateRepairParts.Select(j=>new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.Name,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        Price = j.Price

                    }).ToList(),
                    RepairParts = i.RepairParts.Select(j=>new RepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price
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
                    ServiceBookingId = i.ServiceBookingId,
                    ServiceRepairState = i.ServiceRepairState,
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
                        RepairItemId = j.RepairItemId,
                        RepairItemName = j.RepairItem.Name,
                        WordHour = j.WordHour,
                        Price = j.Price,
                        MainOperatorId = j.MainOperatorId,
                        MainOperatorName = j.MainOperator.Name
                    }).ToList(),
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.Name,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        Price = j.Price

                    }).ToList(),
                    RepairParts = i.RepairParts.Select(j => new RepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price
                    }).ToList()
                }).FirstOrDefault();
                return serviceRepair;
            }
        }

        public List<ServiceRepairDto> QueryServiceRepair(string keyword)
        {
            using (var db = new ModelContext())
            {
                var serviceRepairs = db.ServiceRepair.Where(i=>i.ContactName.Contains(keyword)).Select(i => new ServiceRepairDto()
                {
                    Id = i.Id,
                    CarId = i.CarId,
                    ServiceBookingId = i.ServiceBookingId,
                    ServiceRepairState = i.ServiceRepairState,
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
                        RepairItemId = j.RepairItemId,
                        RepairItemName = j.RepairItem.Name,
                        WordHour = j.WordHour,
                        Price = j.Price,
                        MainOperatorId = j.MainOperatorId,
                        MainOperatorName = j.MainOperator.Name
                    }).ToList(),
                    EstimateRepairParts = i.EstimateRepairParts.Select(j => new EstimateRepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.Name,
                        ServiceBookingId = j.ServiceBookingId,
                        Count = j.Count,
                        Price = j.Price

                    }).ToList(),
                    RepairParts = i.RepairParts.Select(j => new RepairPartsDto()
                    {
                        Id = j.Id,
                        PartsId = j.PartsId,
                        PartsCode = j.Parts.PartsDictionary.Code,
                        PartsName = j.Parts.Name,
                        ServiceRepairId = j.ServiceRepairId,
                        Count = j.Count,
                        Price = j.Price
                    }).ToList()
                }).ToList();
                return serviceRepairs;
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
                serviceRepair.EstimateLeaveTime = serviceRepairDto.EstimateLeaveTime;
                serviceRepair.ServiceAdvisorId = serviceRepairDto.ServiceAdvisorId;
                serviceRepair.ContactName = serviceRepairDto.ContactName;
                serviceRepair.ContactPhone = serviceRepairDto.ContactPhone;
                serviceRepair.RepairDescription = serviceRepairDto.RepairDescription;
                serviceRepair.CustomerDescription = serviceRepairDto.CustomerDescription;
                var serviceRepairItem = serviceRepairDto.ServiceRepairItem.Select(i => new ServiceRepairItem()
                {
                    Id = Guid.NewGuid(),
                    RepairItemId = i.RepairItemId,
                    ServiceRepairId = serviceRepair.Id,
                    WordHour = i.WordHour,
                    Price = i.Price,
                    MainOperatorId = i.MainOperatorId
                });
                var repairParts = serviceRepairDto.RepairParts.Select(i => new RepairParts()
                {
                    Id = Guid.NewGuid(),
                    PartsId = i.PartsId,
                    ServiceRepairId = serviceRepair.Id,
                    Count = i.Count,
                    Price = i.Count
                });
                using (var scope = new TransactionScope())
                {
                    try
                    {
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
                    return new ResModel() { Msg = "更新维修单成功", Success = true };
                }
            }
        }
    }
}
