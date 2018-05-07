using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class SupplierRepository : ISupplierRepository
    {
        public List<SupplierDto> GetAllSupplier()
        {
            using (var db=new ModelContext())
            {
                var suppiers = db.Supplier.Select(i => new SupplierDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Code = i.Code,
                    ContactName = i.ContactName,
                    MobilePhone = i.MobilePhone,
                    FixPhone = i.FixPhone,
                    Fax = i.Fax,
                    MajorOrigin = i.MajorOrigin,
                    BankName = i.BankName,
                    BankAccount = i.BankAccount,
                    Address = i.Address,
                    Gender = i.Gender,
                    Birthday = i.Birthday,
                    Wechat = i.Wechat,
                    QQ = i.QQ,
                    Description = i.Description
                }).ToList();
                return suppiers;
            }
        }

        public SupplierDto GetOneSupplier(Guid supplierId)
        {
            using (var db = new ModelContext())
            {
                var suppier = db.Supplier.Where(i=>i.Id == supplierId).Select(i => new SupplierDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Code = i.Code,
                    ContactName = i.ContactName,
                    MobilePhone = i.MobilePhone,
                    FixPhone = i.FixPhone,
                    Fax = i.Fax,
                    MajorOrigin = i.MajorOrigin,
                    BankName = i.BankName,
                    BankAccount = i.BankAccount,
                    Address = i.Address,
                    Gender = i.Gender,
                    Birthday = i.Birthday,
                    Wechat = i.Wechat,
                    QQ = i.QQ,
                    Description = i.Description
                }).FirstOrDefault();
                return suppier;
            }
        }

        public ResModel AddSupplier(SupplierDto supplierDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var supplier = new Supplier()
                {
                    Id = Guid.NewGuid(),
                    Name = supplierDto.Name,
                    Code = supplierDto.Code,
                    ContactName = supplierDto.ContactName,
                    MobilePhone = supplierDto.MobilePhone,
                    FixPhone = supplierDto.FixPhone,
                    Fax = supplierDto.Fax,
                    MajorOrigin = supplierDto.MajorOrigin,
                    BankName = supplierDto.BankName,
                    BankAccount = supplierDto.BankAccount,
                    Address = supplierDto.Address,
                    Gender = supplierDto.Gender,
                    Birthday = supplierDto.Birthday,
                    Wechat = supplierDto.Wechat,
                    QQ = supplierDto.QQ,
                    Description = supplierDto.Description
                };
                try
                {
                    db.Supplier.Add(supplier);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加失败",Success = false};
                }
                return new ResModel() { Msg = "添加成功", Success = true };
            }
        }

        public ResModel UpdateSupplier(SupplierDto supplierDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var supplier = db.Supplier.FirstOrDefault(i => i.Id == supplierDto.Id);
                if (supplier == null)
                {
                    return new ResModel(){Msg = "更新失败，未找到该供应商",Success = false};
                }

                try
                {
                    supplier.Name = supplierDto.Name;
                    supplier.Code = supplierDto.Code;
                    supplier.ContactName = supplierDto.ContactName;
                    supplier.MobilePhone = supplierDto.MobilePhone;
                    supplier.FixPhone = supplierDto.FixPhone;
                    supplier.Fax = supplierDto.Fax;
                    supplier.MajorOrigin = supplierDto.MajorOrigin;
                    supplier.BankName = supplierDto.BankName;
                    supplier.BankAccount = supplierDto.BankAccount;
                    supplier.Address = supplierDto.Address;
                    supplier.Gender = supplierDto.Gender;
                    supplier.Birthday = supplierDto.Birthday;
                    supplier.Wechat = supplierDto.Wechat;
                    supplier.QQ = supplierDto.QQ;
                    supplier.Description = supplierDto.Description;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "更新失败", Success = false };
                }
                return new ResModel() { Msg = "更新成功", Success = true };
            }
        }

        public ResModel DeleteSupplier(Guid supplierId)
        {
            using (var db = new ModelContext())
            {
                var supplier = db.Supplier.FirstOrDefault(i => i.Id == supplierId);
                if (supplier == null)
                {
                    return new ResModel() { Msg = "删除失败，未找到该供应商", Success = false };
                }

                try
                {
                    db.Supplier.Remove(supplier);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除失败", Success = false };
                }
                return new ResModel() { Msg = "删除成功", Success = true };
            }
        }

        public List<SupplierDto> QuerySupplier(string keyWord)
        {
            using (var db = new ModelContext())
            {
                var suppiers = db.Supplier.Where(i=>i.Name.Contains(keyWord)).Select(i => new SupplierDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Code = i.Code,
                    ContactName = i.ContactName,
                    MobilePhone = i.MobilePhone,
                    FixPhone = i.FixPhone,
                    Fax = i.Fax,
                    MajorOrigin = i.MajorOrigin,
                    BankName = i.BankName,
                    BankAccount = i.BankAccount,
                    Address = i.Address,
                    Gender = i.Gender,
                    Birthday = i.Birthday,
                    Wechat = i.Wechat,
                    QQ = i.QQ,
                    Description = i.Description
                }).ToList();
                return suppiers;
            }
        }
    }
}
