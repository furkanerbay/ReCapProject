using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailsDto> GetByCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id


                             select new CarDetailsDto
                             {
                                 Id = car.Id,
                                 CarName = car.Description,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == car.Id
                                              select img.ImagePath).FirstOrDefault()
                             };

                return result.ToList();
            }
        }

        public List<CarDetailsDto> GetCarsByBrandId(int brandId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             where car.BrandId == brandId

                             select new CarDetailsDto
                             {
                                 CarName = car.Description,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == car.Id
                                              select img.ImagePath).FirstOrDefault()
                             };

                return result.ToList();
            }
        }

        public List<CarDetailsDto> GetByCarDetailsByColor(int colorId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             where car.ColorId == colorId

                             select new CarDetailsDto
                             {
                                 CarName = car.Description,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == car.Id
                                              select img.ImagePath).FirstOrDefault()
                             };

                return result.ToList();
            }
        }

        public List<CarDetailsDto> GetByCarDetailsByColorAndBrand(int colorId, int brandId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             where car.ColorId == colorId && car.BrandId == brandId

                             select new CarDetailsDto
                             {
                                 CarName = car.Description,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == car.Id
                                              select img.ImagePath).FirstOrDefault()
                             };

                return result.ToList();

            };

        }


        public CarDetailsDto GetByCarDetailsByCarId(int carId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             where car.Id == carId

                             select new CarDetailsDto
                             {
                                 Id = car.Id,
                                 CarName = car.Description,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == car.Id
                                              select img.ImagePath).FirstOrDefault()
                             };

                return result.FirstOrDefault();
            };
        }

        public List<CarDetailsDto> GetByCarDetailsByCarId2(int carId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             where car.Id == carId

                             select new CarDetailsDto
                             {
                                 Id = car.Id,
                                 CarName = car.Description,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == car.Id
                                              select img.ImagePath).FirstOrDefault()
                             };

                return result.ToList();
            }
        }


    }
}

