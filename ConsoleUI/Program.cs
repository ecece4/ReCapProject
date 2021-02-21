using Business.Concrete;
using DataAccess.Abstract;
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

            // CarTest();
            // BrandTest();


            //RentalTest();


            int carId, customerId;
            int toReturnCarId, toReturnCustomerId;

            //RentalAddTest(out carId, out customerId, out rentalManager);


            RentalUpdateTest(out toReturnCarId, out toReturnCustomerId);

        }

        private static void RentalUpdateTest(out int toReturnCarId, out int toReturnCustomerId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental();
            toReturnCarId = int.Parse(Console.ReadLine());
            toReturnCustomerId = int.Parse(Console.ReadLine());
            rental1.CarId = toReturnCarId;
            rental1.CustomerId = toReturnCustomerId;
            Console.WriteLine(rentalManager.Update(rental1).Message);
        }

        private static void RentalAddTest(out int carId, out int customerId, out RentalManager rentalManager)
        {   
            rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            carId = int.Parse(Console.ReadLine());
            customerId = int.Parse(Console.ReadLine());
            rental.CarId = carId;
            rental.CustomerId = customerId;
            rental.RentDate = DateTime.Now;



            Console.WriteLine(rentalManager.Add(rental).Message);
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
           var result = rentalManager.GetRentalDetails();
            Console.WriteLine("Aracın Adı:  Marka:   Renk:  Kiralayının Adı ve Soyadı: "
                +"Şirket Adı:    Kiralanma Tarihi:   İade Edilme Tarihi: ");
            Console.WriteLine("--------------------------------------------------------------");
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {

                    Console.WriteLine(rental.CarName +" "+rental.Brand+" / " +rental.Color  +" / " 
                        + rental.FirstName + " " + rental.LastName + "/ " + rental.CompanyName+ "/"
                        + rental.RentDate + " / " + rental.ReturnDate);

                }
        }
            else
            {
                Console.WriteLine(result.Message);
            }
}

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brands in brandManager.GetAll().Data)
            {
                Console.WriteLine(brands.BrandName);

            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            Console.WriteLine("Aracın Adı:  Aracın Markası:  Aracın Rengi:  Aracın Fiyatı: ");
            Console.WriteLine("--------------------------------------------------------------");
            if (result.Success == true)
            {
            foreach (var car in result.Data)
            {

                Console.WriteLine(car.CarName + "/ " + car.BrandName + "/ " + car.ColorName + "/ " + car.DailyPrice);

            }
            }
            else
                {
                Console.WriteLine(result.Message);
                }
            
            
        }
    }
}
