    using Business.Abstract;
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
         ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }

        public void Add(Car car)
        {
            if ((car.DailyPrice>0) || (car.CarName.Length>=3))
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Günlük ücret sıfırdan farklı olmalı.");
            }
           
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine(car.Id
               + " Numaralı araba silindi.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public Car GetCarsById(int id)
        {
            return _carDal.Get(p => p.Id == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine(car.Id
               + " Numaralı araba Güncellendi.");
        }
    }
}
