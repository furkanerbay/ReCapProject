using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailsDto>> GetByCarDetails();
        IDataResult<List<CarDetailsDto>> GetByCarDetailsByBrand(int brandId);
        IDataResult<List<CarDetailsDto>> GetByCarDetailsByColor(int colorId);

        IDataResult<List<CarDetailsDto>> GetByCarDetailsByColorAndBrand(int colorId, int brandId);
    }
}
