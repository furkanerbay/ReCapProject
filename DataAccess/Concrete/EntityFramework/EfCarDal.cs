using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailsDto> GetByCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailsDto
                             {
                                 CarName = c.Description,
                                 ColorName = co.Name,
                                 BrandName = b.Name,
                                 DailyPrice = c.DailyPrice
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
                                 DailyPrice = car.DailyPrice
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
                                 DailyPrice = car.DailyPrice
                             };

                return result.ToList();
            }
        }

        public List<CarDetailsDto> GetByCarDetailsByColorAndBrand(int colorId, int brandId)
        {
            using (CarContext context = new CarContext())
            {
                var result= from car in context.Cars
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
                    DailyPrice = car.DailyPrice
                };

                return result.ToList();

            };

        }
    }
}
