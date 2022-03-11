using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //CarByBrandsTest(carManager);
            //CarByColoursTest(carManager);

            //CarAddTest(carManager);

            //CarDetailsTest(carManager);

            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User {FirstName="Furkan",LastName="Erbay",Email="furkanerbay41@gmail.com",Password="furkan123" });

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer {UserId=1,CompanyName="Samsam Tech" });

            DateTime date1 = new DateTime(2022,01,01);
            DateTime date2 = new DateTime(2022,02,02);
            DateTime date3 = new DateTime(2022,03,03);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental {CarId=2,CustomerId=1,RentDate=date3});

        }

        private static void CarDetailsTest(CarManager carManager)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("CarDetailDTO");

            foreach (var c in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(c.CarName + " - " + c.ColorName + " - " + c.BrandName + " - " + c.DailyPrice);
            }
        }

        private static void CarAddTest(CarManager carManager)
        {
            carManager.Add(new Car() { BrandId = 1, ColorId = 3, DailyPrice = 65, ModelYear = 1985, Description = "Turuncu Tofas" });
        }

        private static void CarByColoursTest(CarManager carManager)
        {
            Console.WriteLine("Renklere Göre");

            foreach (var c in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(c.Description + " " + c.ColorId + "\n");
            }
        }

        private static void CarByBrandsTest(CarManager carManager)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Markaya Göre");
            foreach (var c in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(c.Description + " " + c.BrandId + "\n");
            }

            Console.WriteLine("----------------------------------------");
        }
    }
}
