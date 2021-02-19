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
            CarManager carManager = new CarManager(new EfCarDal()) ;
            Console.WriteLine("Aracın Adı:  Aracın Markası:  Aracın Rengi:  Aracın Fiyatı: ");
            Console.WriteLine("--------------------------------------------------------------");
            foreach (var car in carManager.GetCarDetails())
            {
               
                Console.WriteLine(car.CarName +"/ "+ car.BrandName+ "/ "+ car.ColorName+"/ "+ car.DailyPrice ) ;

            }

            
        



            //foreach (var cars in carManager.GetAll())
            //{
            //    Console.WriteLine(cars.Id);
            //}
        
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());

            
            //foreach (var brands in brandManager.GetAll())
            //{
            //    Console.WriteLine(brands.BrandName);
 
            //}
           

            
           
           


        }
    }
}
