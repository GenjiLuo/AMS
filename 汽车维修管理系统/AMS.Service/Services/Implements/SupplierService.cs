using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService()
        {
            _supplierRepository=new SupplierRepository();
        }

        public List<SupplierDto> GetAllSupplier()
        {
            return _supplierRepository.GetAllSupplier();
        }

        public SupplierDto GetOneSupplier(Guid supplierId)
        {
            return _supplierRepository.GetOneSupplier(supplierId);
        }

        public ResModel AddSupplier(SupplierDto supplierDto, UserDto operationUser)
        {
            return _supplierRepository.AddSupplier(supplierDto, operationUser);
        }

        public ResModel UpdateSupplier(SupplierDto supplierDto, UserDto operationUser)
        {
            return _supplierRepository.UpdateSupplier(supplierDto, operationUser);
        }

        public ResModel DeleteSupplier(Guid supplierId)
        {
            return _supplierRepository.DeleteSupplier(supplierId);
        }

        public List<SupplierDto> QuerySupplier(string keyWord)
        {
            return _supplierRepository.QuerySupplier(keyWord);
        }
    }
}
