using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetByRentalDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Userss
                             on customer.UserId equals user.Id
                             select new RentalDetailsDto
                             {
                                 BrandName = brand.Name,
                                 CustomerName = user.FirstName + user.LastName
                             };
                return result.ToList();
            }
        }
    }
}
