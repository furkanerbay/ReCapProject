using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailsDto> GetByCarDetails();
        List<CarDetailsDto> GetCarsByBrandId(int brandId);
        List<CarDetailsDto> GetByCarDetailsByColor(int colorId);
        List<CarDetailsDto> GetByCarDetailsByColorAndBrand(int colorId, int brandId);
        CarDetailsDto GetByCarDetailsByCarId(int carId);
    }
}
