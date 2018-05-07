using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class PartsDictionaryDto : BaseDto
    {
        public PartsDictionaryDto()
        {
            PartsDictionarySuitedCarModelDtos=new List<PartsDictionarySuitedCarModelDto>();
        }
        public string Code { get; set; }
        public Guid PartsTypeId { get; set; }
        public string PartsTypeName { get; set; }

        public string MeasurementUnit { get; set; }

        public List<PartsDictionarySuitedCarModelDto> PartsDictionarySuitedCarModelDtos { get; set; }

        public string SuitedCarModelsStr
        {
            get
            {
                var str = "";
                foreach (var item in PartsDictionarySuitedCarModelDtos)
                {
                    var tempStr = "";
                    if (item.ModelId.HasValue)
                    {
                        tempStr = item.CarBrandName + " "+item.CarSeriesName+" "+item.CarModelName;
                    }
                    else if(item.SeriesId.HasValue)
                    {
                        tempStr = item.CarBrandName +" "+ item.CarSeriesName;
                    }
                    else
                    {
                        tempStr = item.CarBrandName;
                    }

                    str += tempStr+", ";
                }
                return str;
            }
        }

        public decimal SupplierPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal TradePrice { get; set; }
        public decimal AdjustPrice { get; set; }
        public decimal ClaimPrice { get; set; }

        public string BrandName { get; set; }
        public string Specifications { get; set; }
        public string ProducedAddress { get; set; }
        public string Label { get; set; }
    }
}
