﻿using Business.Concrete;
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
            CarTest();
           // BrandTest();






           
            //Console.WriteLine(brandManager.GetBrandByBrandId(5)); 







          

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
