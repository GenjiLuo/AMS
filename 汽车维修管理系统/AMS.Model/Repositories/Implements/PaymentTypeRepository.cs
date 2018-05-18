using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        public List<PaymentTypeDto> GetAllPaymentType()
        {
            using (var db=new ModelContext())
            {
                var paymentTypes = db.PaymentType.Select(i => new PaymentTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    IconUrl = i.IconUrl,
                    SelectedIconUrl = i.SelectedIconUrl,
                    OperationType = i.OperationType,
                    Description = i.Description
                }).ToList();
                return paymentTypes;
            }
        }

        public ResModel AddPaymentType(PaymentTypeDto paymentTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var paymentType = new PaymentType()
                {
                    Id = Guid.NewGuid(),
                    Name = paymentTypeDto.Name,
                    IconUrl = "../../Content/img/payment/default-pay.png",
                    SelectedIconUrl = "../../Content/img/payment/default-selected-pay.png",
                    Description = paymentTypeDto.Description
                };
                try
                {
                    db.PaymentType.Add(paymentType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加付款方式失败",Success = false};
                }
                return new ResModel() { Msg = "添加付款方式成功", Success = true };
            }
        }

        public PaymentTypeDto GetOnePaymentType(Guid paymentTypeId)
        {
            using (var db = new ModelContext())
            {
                var paymentType = db.PaymentType.Where(i=>i.Id == paymentTypeId).Select(i => new PaymentTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    IconUrl = i.IconUrl,
                    SelectedIconUrl = i.SelectedIconUrl,
                    OperationType = i.OperationType,
                    Description = i.Description
                }).FirstOrDefault();
                return paymentType;
            }
        }

        public ResModel UpdatePaymentType(PaymentTypeDto paymentTypeDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var paymentType = db.PaymentType.FirstOrDefault(i => i.Id == paymentTypeDto.Id);
                if (paymentType == null)
                {
                    return new ResModel(){Msg = "更新付款方式失败，未找到该付款方式",Success = false};
                }

                try
                {
                    paymentType.Name = paymentTypeDto.Name;
                    paymentType.Description = paymentTypeDto.Description;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "更新付款方式失败",Success = false};
                }
                return new ResModel() { Msg = "更新付款方式成功", Success = true };
            }
        }

        public ResModel DeletePaymentType(Guid paymentTypeId)
        {
            using (var db = new ModelContext())
            {
                var paymentType = db.PaymentType.FirstOrDefault(i => i.Id == paymentTypeId);
                if (paymentType == null)
                {
                    return new ResModel() { Msg = "删除付款方式失败，未找到该付款方式", Success = false };
                }

                try
                {
                    db.PaymentType.Remove(paymentType);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除付款方式失败", Success = false };
                }
                return new ResModel() { Msg = "删除付款方式成功", Success = true };
            }
        }

        public List<PaymentTypeDto> QueryPaymentType(string keyword)
        {
            using (var db = new ModelContext())
            {
                var paymentTypes = db.PaymentType.Where(i=>i.Name.Contains(keyword)).Select(i => new PaymentTypeDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    IconUrl = i.IconUrl,
                    SelectedIconUrl = i.SelectedIconUrl,
                    OperationType = i.OperationType,
                    Description = i.Description
                }).ToList();
                return paymentTypes;
            }
        }
    }
}
