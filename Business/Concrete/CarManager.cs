using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        //[SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), "Arabalarin hepsi listelendi.");
        }

        public IDataResult<List<CarDetailsDto>> GetByCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetByCarDetails(),"Urun detaylari getirildi.");
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id),"Istenilen ID'ye ait urun getirildi.");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId),"Istenilen markanin arabalari listelendi.");
        }

        public IDataResult<List<CarDetailsDto>> GetByCarDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsByBrandId(brandId),"Istenilen markanin arabalari listelendi. - CarDetails");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId),"Arabalar istenilen renge gore listelendi.");
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailsDto>> GetByCarDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetByCarDetailsByColor(colorId),"Istenilen renge gore urunler getirildi.");
        }

        public IDataResult<List<CarDetailsDto>> GetByCarDetailsByColorAndBrand(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetByCarDetailsByColorAndBrand(colorId,brandId),"Hem renk hemde istenilen markaya gore urunler getirildi.");
        }

        public IDataResult<CarDetailsDto> GetByCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailsDto>(_carDal.GetByCarDetailsByCarId(carId),"Istenilen araba getirildi.");
        }

        public IDataResult<List<CarDetailsDto>> GetByCarDetailsByCarId2(int carId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetByCarDetailsByCarId2(carId),"Istenilen araba getirildi.");
        }
    }
}
