using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        //List<Color> _color;
        //List<Brand> _brand;
        public InMemoryCarDal()
        {
            _cars = new List<Car>() { 
            new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=280, ModelYear="2008", Description="Rahat" },
            new Car{Id=2, BrandId=1, ColorId=1, DailyPrice=140, ModelYear="2005", Description="Ekonomik" },
            new Car{Id=3, BrandId=2, ColorId=3, DailyPrice=250, ModelYear="2010", Description="Aile ile uzun yola uygun  " }
   
            };
           
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

    
        public void Delete(Car car)
        {
            Car carToDelete = carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int Id)
        {

            return _cars.Where(p => p.Id == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            
        }

        
    }
}
