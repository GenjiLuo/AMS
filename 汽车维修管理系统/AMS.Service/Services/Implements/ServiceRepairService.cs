using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class ServiceRepairService : IServiceRepairService
    {
        private readonly IServiceRepairRepository _serviceRepairRepository;

        public ServiceRepairService()
        {
            _serviceRepairRepository=new ServiceRepairRepository();
        }

        public List<ServiceRepairDto> GetAllServiceRepair()
        {
            return _serviceRepairRepository.GetAllServiceRepair();
        }

        public ResModel AddServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            return _serviceRepairRepository.AddServiceRepair(serviceRepairDto, operationUser);
        }

        public ResModel AddWashCar(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            return _serviceRepairRepository.AddWashCar(serviceRepairDto,operationUser);
        }

        public ServiceRepairDto GetOneServiceRepair(Guid serviceRepairId)
        {
            return _serviceRepairRepository.GetOneServiceRepair(serviceRepairId);
        }

        public ServiceRepairAccountTicketDto GetOneAccountTicket(Guid serviceRepairAccountTicketId)
        {
            return _serviceRepairRepository.GetOneAccountTicket(serviceRepairAccountTicketId);
        }

        public ServiceRepairAccountTicketDto GetOneAccountTicketByRepairId(Guid serviceRepairId)
        {
            return _serviceRepairRepository.GetOneAccountTicketByRepairId(serviceRepairId);
        }

        public ServiceRepairCashTicketDto GetOneCashTicketByRepairId(Guid serviceRepairId)
        {
            return _serviceRepairRepository.GetOneCashTicketByRepairId(serviceRepairId);
        }

        public ResModel UpdateServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            return _serviceRepairRepository.UpdateServiceRepair(serviceRepairDto, operationUser);
        }

        public ResModel DeleteServiceRepair(Guid serviceRepairId)
        {
            return _serviceRepairRepository.DeleteServiceRepair(serviceRepairId);
        }

        public List<ServiceRepairDto> QueryServiceRepair(string keyword)
        {
            return _serviceRepairRepository.QueryServiceRepair(keyword);
        }

        public List<ServiceRepairHistoryDto> GetAllRepairHistory()
        {
            return _serviceRepairRepository.GetAllRepairHistory();
        }

        public List<ServiceRepairHistoryDto> GetHistoryRepairByCarId(Guid carId)
        {
            return _serviceRepairRepository.GetHistoryRepairByCarId(carId);
        }

        public ResModel TurnToRepair(Guid serviceRepairId, UserDto operationUser)
        {
            return _serviceRepairRepository.TurnToRepair(serviceRepairId,operationUser);
        }

        public ResModel TurnToFinish(Guid serviceRepairId, UserDto operationUser)
        {
            return _serviceRepairRepository.TurnToFinish(serviceRepairId,operationUser);
        }

        public ResModel TurnToUnFinish(Guid serviceRepairId, UserDto operationUser)
        {
            return _serviceRepairRepository.TurnToUnFinish(serviceRepairId, operationUser);
        }

        public ResModel TurnToInvalid(Guid serviceRepairId, UserDto operationUser)
        {
            return _serviceRepairRepository.TurnToInvalid(serviceRepairId, operationUser);
        }

        public ResModel TurnToAccount(Guid serviceRepairId, UserDto operationUser)
        {
            return _serviceRepairRepository.TurnToAccount(serviceRepairId, operationUser);
        }

        public ResModel TurnToCash(Guid serviceRepairId, UserDto operationUser)
        {
            return _serviceRepairRepository.TurnToCash(serviceRepairId, operationUser);
        }

        public ResModel TurnToLeave(Guid serviceRepairId, UserDto operationUser)
        {
            return _serviceRepairRepository.TurnToLeave(serviceRepairId, operationUser);
        }

        public ResModel SaveAndFinish(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            return _serviceRepairRepository.SaveAndFinish(serviceRepairDto, operationUser);
        }

        public ResModel SaveAndAccount(ServiceRepairAccountTicketDto serviceRepairAccountTicketDto, UserDto operationUser)
        {
            return _serviceRepairRepository.SaveAndAccount(serviceRepairAccountTicketDto, operationUser);
        }

        public ResModel SaveAndCash(ServiceRepairCashTicketDto serviceRepairCashTicketDto, UserDto operationUser)
        {
            return _serviceRepairRepository.SaveAndCash(serviceRepairCashTicketDto, operationUser);
        }

        public ResModel WashCarSaveAndCash(ServiceRepairCashTicketDto serviceRepairCashTicketDto, UserDto operationUser)
        {
            return _serviceRepairRepository.WashCarSaveAndCash(serviceRepairCashTicketDto,operationUser);
        }
    }
}
