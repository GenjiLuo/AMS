using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class WarehouseRepository : IWarehouseRepository
    {
        public List<WarehouseDto> GetAllWarehouse()
        {
            using (var db=new ModelContext())
            {
                var warehouses = db.Warehouse.Select(i => new WarehouseDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsDefault = i.IsDefault,
                    Description = i.Description,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    Address = i.Address
                }).ToList();
                return warehouses;
            }
        }

        public ResModel AddWarehouse(WarehouseDto warehouseDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var warehouse=new Warehouse()
                {
                    Id = Guid.NewGuid(),
                    Name = warehouseDto.Name,
                    Description = warehouseDto.Description,
                    IsDefault = warehouseDto.IsDefault,
                    ContactName = warehouseDto.ContactName,
                    ContactPhone = warehouseDto.ContactPhone,
                    Address = warehouseDto.Address
                };
                if (warehouse.IsDefault)
                {
                    var previousDefaultWarehouse=db.Warehouse.FirstOrDefault(i => i.IsDefault);
                    if (previousDefaultWarehouse != null)
                    {
                        previousDefaultWarehouse.IsDefault = false;
                    }
                }

                try
                {
                    db.Warehouse.Add(warehouse);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加库房失败",Success = false};
                }
                return new ResModel() { Msg = "添加库房成功", Success = true };
            }
        }

        public WarehouseDto GetOneWarehouse(Guid warehouseId)
        {
            using (var db = new ModelContext())
            {
                var warehouse = db.Warehouse.Where(i=>i.Id == warehouseId).Select(i => new WarehouseDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsDefault = i.IsDefault,
                    Description = i.Description,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone,
                    Address = i.Address
                }).FirstOrDefault();
                return warehouse;
            }
        }

        public ResModel UpdateWarehouse(WarehouseDto warehouseDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var warehouse = db.Warehouse.FirstOrDefault(i => i.Id == warehouseDto.Id);
                if (warehouse == null)
                {
                    return new ResModel(){Msg = "更新库房失败，未找到该库房",Success = false};
                }

                try
                {
                    warehouse.Name = warehouseDto.Name;
                    warehouse.Description = warehouseDto.Description;
                    warehouse.IsDefault = warehouseDto.IsDefault;
                    warehouse.ContactName = warehouseDto.ContactName;
                    warehouse.ContactPhone = warehouseDto.ContactPhone;
                    warehouse.Address = warehouseDto.Address;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "更新库房失败", Success = false };
                }
                return new ResModel() { Msg = "更新库房成功", Success = true };
            }
        }

        public ResModel DeleteWarehouse(Guid warehouseId)
        {
            using (var db = new ModelContext())
            {
                var warehouse = db.Warehouse.FirstOrDefault(i => i.Id == warehouseId);
                if (warehouse == null)
                {
                    return new ResModel() { Msg = "更新库房失败，未找到该库房", Success = false };
                }

                try
                {
                    db.Warehouse.Remove(warehouse);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "更新库房失败", Success = false };
                }
                return new ResModel() { Msg = "更新库房成功", Success = true };
            }
        }

        public List<WarehouseDto> QueryWarehouse(string keyword)
        {
            using (var db = new ModelContext())
            {
                var warehouses = db.Warehouse.Where(
                    i =>i.Name.Contains(keyword) || i.ContactName.Contains(keyword) || i.ContactPhone.Contains(keyword))
                    .Select(i => new WarehouseDto
                    {
                        Id = i.Id,
                        Name = i.Name,
                        IsDefault = i.IsDefault,
                        Description = i.Description,
                        ContactName = i.ContactName,
                        ContactPhone = i.ContactPhone,
                        Address = i.Address
                    }).ToList();
                return warehouses;
            }
        }
    }
}

