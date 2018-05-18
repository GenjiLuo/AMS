using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.Repositories.Interfaces;

namespace AMS.Model.Repositories.Implements
{
    public class ServiceRepairHistoryRepository : IServiceRepairHistoryRepository
    {
        public List<ServiceRepairHistoryDto> GetAllHistory()
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
    }
}
