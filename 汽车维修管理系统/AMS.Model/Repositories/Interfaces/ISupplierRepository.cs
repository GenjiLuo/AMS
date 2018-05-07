using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        List<SupplierDto> GetAllSupplier();
        SupplierDto GetOneSupplier(Guid supplierId);
        ResModel AddSupplier(SupplierDto supplierDto, UserDto operationUser);
        ResModel UpdateSupplier(SupplierDto supplierDto, UserDto operationUser);
        ResModel DeleteSupplier(Guid supplierId);
        List<SupplierDto> QuerySupplier(string keyWord);
    }
}
