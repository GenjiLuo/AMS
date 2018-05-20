using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.Repositories.Interfaces;

namespace AMS.Model.Repositories.Implements
{
    public class PartsRepository : IPartsRepository
    {
        public List<PartsDto> GetAllParts()
        {
            using (var db=new ModelContext())
            {
                var parts = db.Parts.Select(i => new PartsDto()
                {
                    Id = i.Id,
                    PartsDictionaryId = i.PartsDictionaryId,
                    PartsCode = i.PartsDictionary.Code,
                    BrandName = i.PartsDictionary.BrandName,
                    PartsDictionaryName = i.PartsDictionary.Name,
                    Price = i.Price,
                    Count = i.Count, 
                    WarehouseId = i.WarehouseId,
                    WarehouseName = i.Warehouse.Name
                }).ToList();
                return parts;
            }
        }

        public List<PartsAlertDto> GetAllPartAlerts()
        {
            using (var db=new ModelContext())
            {
                var partsAlerts = db.PartsDictionary.Where(i=>i.HighestAlertCount.HasValue && i.LowestAlertCount.HasValue).Join(db.Parts, i => i.Code, j => j.PartsDictionary.Code,
                    (i, j) => new PartsAlertDto()
                    {
                        PartsCode = i.Code,
                        PartsName = i.Name,
                        WarehouseName = j.Warehouse.Name,
                        CurrentCount = j.Count,
                        LowestAlertCount = i.LowestAlertCount,
                        HighestAlertCount = i.HighestAlertCount
                    }).ToList();
                return partsAlerts;
            }
        }

        public List<PartsAlertDto> GetOverHighestPartAlerts()
        {
            using (var db = new ModelContext())
            {
                var partsAlerts = db.PartsDictionary.Where(i => i.HighestAlertCount.HasValue && i.LowestAlertCount.HasValue).Join(db.Parts, i => i.Code, j => j.PartsDictionary.Code,
                    (i, j) => new PartsAlertDto()
                    {
                        PartsCode = i.Code,
                        PartsName = i.Name,
                        WarehouseName = j.Warehouse.Name,
                        CurrentCount = j.Count,
                        LowestAlertCount = i.LowestAlertCount,
                        HighestAlertCount = i.HighestAlertCount
                    }).Where(i=>i.CurrentCount>i.HighestAlertCount).ToList();
                return partsAlerts;
            }
        }

        public List<PartsAlertDto> GetLowerLowestPartAlerts()
        {
            using (var db = new ModelContext())
            {
                var partsAlerts = db.PartsDictionary.Where(i => i.HighestAlertCount.HasValue && i.LowestAlertCount.HasValue).Join(db.Parts, i => i.Code, j => j.PartsDictionary.Code,
                    (i, j) => new PartsAlertDto()
                    {
                        PartsCode = i.Code,
                        PartsName = i.Name,
                        WarehouseName = j.Warehouse.Name,
                        CurrentCount = j.Count,
                        LowestAlertCount = i.LowestAlertCount,
                        HighestAlertCount = i.HighestAlertCount
                    }).Where(i=>i.CurrentCount<i.LowestAlertCount).ToList();
                return partsAlerts;
            }
        }
    }
}
