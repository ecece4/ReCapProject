    using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IResult Add(Car car)
        {
            if ((car.DailyPrice>0) || (car.CarName.Length>=3))
            {
                _carDal.Add(car);
                return new SuccessDataResult<Car>(Messages.CarAdded);
            }
            else
            {
                return new ErrorDataResult<Car>(Messages.CarNameOrDailyPriceInvalid);
            }
           
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, Messages.CarDeleted);
        }

        public IDataResult<List<Car> >GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>  ( _carDal.GetCarDetails());
        }

        public IDataResult<Car> GetCarsById(int id)
        {
            return new SuccessDataResult<Car> (_carDal.Get(p => p.Id == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, Messages.CarUpdated);
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(p => p.BrandId == id).ToList());
        }
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(p => p.ColorId == id).ToList());
        }
    }
}
