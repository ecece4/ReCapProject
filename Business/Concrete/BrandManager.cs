using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
               return new SuccessDataResult<Car>(Messages.BrandAdded);
               
            }
            else
            {
                return new ErrorDataResult<Car>(Messages.BrandNameInvalid);
            }
        }

        public IResult Delete(Brand brand)
        {

            _brandDal.Update(brand);
            return new SuccessDataResult<Brand>(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }



        public IDataResult<Brand> GetBrandByBrandId(int id)
        {
            return new SuccessDataResult<Brand> (_brandDal.Get(p => p.BrandId == id));
        }

        public IResult Update(Brand brand)
        {

            _brandDal.Update(brand);
            return new SuccessDataResult<Brand>(Messages.BrandUpdated);
        }


    }
}
