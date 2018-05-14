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
    }
}
