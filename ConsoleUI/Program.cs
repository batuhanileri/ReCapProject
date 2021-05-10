using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            //UserTest();
            //CustomerTest();
            //RentalTest();
        }
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var addedRental = rentalManager.Add(new Rental
            {
                RentalId=7,
                CarId=5,
                CustomerId =2,            
                RentDate = DateTime.Now.AddDays(12)
            });
            if (addedRental.Success == true)
            {
                Console.WriteLine(addedRental.Message);
            }
            else
            {
                Console.WriteLine(addedRental.Message);
            }
        }
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //var customerDeleted= customerManager.Delete(new Customer()
            //{
            //    CustomerId = 3,
            //});
            //if(customerDeleted.Success)
            //{
            //    Console.WriteLine(customerDeleted.Message);
            //}
            var customerAdd = customerManager.Add(new Customer()
            {
                CustomerId = 3,
                UserId = 2,
                CompanyName = "A"
            });
            if(customerAdd.Success)
            {
                Console.WriteLine(customerAdd.Message);
            }
            foreach (var customers in customerManager.GetAll().Data)
            {
                Console.WriteLine(customers.CustomerId);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User()
            {
                UserId = 2,
                FirstName = "Ah",
                LastName = "Lale",
                Email = "a@gmail.com",
                Password = "1234"
            });
            foreach (var users in userManager.GetAll().Data)
            {
                Console.WriteLine(users.FirstName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color()
            //{
            //    ColorId = 1,
            //    ColorName = "Siyah"
            //});
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}
            Console.WriteLine(colorManager.GetById(1));
           
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var DeletedBrand= brandManager.Delete(new Brand()
            {
                BrandId = 3,
                BrandName="Lambo" 
            });
            if (DeletedBrand.Success == true)
            {
                Console.WriteLine(DeletedBrand.Message);
            }
           
        }

        private static void CarTest()
        {
            CarManager car = new CarManager(new EfCarDal());

            //car.Update(new Car()
            //{
            //    CarId = 5,
            //    CarName = "kia",
            //    BrandId = 4,
            //    ColorId = 5,
            //    DailyPrice = 330,
            //    Description = "BENZİN",
            //    ModelYear = "1940"
            //});

            foreach (var cars in car.GetCarDetailDtos().Data)
            {
                Console.WriteLine(cars.CarName+" "+cars.BrandName+" "+cars.ColorName+" "+cars.DailyPrice);
            }
        }
    }
} 
