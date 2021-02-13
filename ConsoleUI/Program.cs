using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal()) ;
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());

            Console.WriteLine("ARABA LİSTESİ: ");
            foreach (var car in carManager.GetAll())
            {

                Console.WriteLine("Araba Numarası: " + car.Id +" Marka Numarası: " + car.BrandId+ " Günlük Ücret: " 
                    + car.DailyPrice +  " Araba Açıklaması: "+ car.Description + " Model Yılı: "+ car.ModelYear  ); 

            }

            Console.WriteLine("MARKA LİSTESİ: ");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka numarası: " + brand.BrandId + " için araba markası " + brand.BrandName);

            }
            Console.WriteLine(" ");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk numarası: "+ color.ColorId+" için renk "+ color.ColorName);
            }

        }
    }
}
