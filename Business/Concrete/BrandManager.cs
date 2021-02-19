using Business.Abstract;
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

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Yeni marka eklendi.");
            }
            else
            {
                Console.WriteLine("Marka adı iki harften fazla olmalı. ");
            }
        }

        public void Delete(Brand brand)
        {

            _brandDal.Update(brand);
            Console.WriteLine(brand.BrandId
               + " Numaralı marka silindi.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }



        public Brand GetBrandByBrandId(int id)
        {
            return _brandDal.Get(p => p.BrandId == id);
        }

        public void Update(Brand brand)
        {

            _brandDal.Update(brand);
            Console.WriteLine(brand.BrandId
               + " Numaralı marka güncellendi.");
        }
    }
}
