using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface ISupplierService
    {
        List<SupplierDto> GetAllSupplier();
        SupplierDto GetOneSupplier(Guid supplierId);
        ResModel AddSupplier(SupplierDto supplierDto, UserDto operationUser);
        ResModel UpdateSupplier(SupplierDto supplierDto, UserDto operationUser);
        ResModel DeleteSupplier(Guid supplierId);
        List<SupplierDto> QuerySupplier(string keyWord);
    }
}
