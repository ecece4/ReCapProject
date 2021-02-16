using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>() { 
            new Brand{BrandId=1,BrandName="Seat"},
            new Brand{BrandId=2,BrandName="Nissan"}
            
            };

        }
        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = brandToDelete = _brands.SingleOrDefault(p => p.BrandId == brand.BrandId);
            _brands.Remove(brandToDelete);

        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAllById(int BrandId)
        {
            return _brands.Where(p => p.BrandId == BrandId).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = brandToUpdate = _brands.SingleOrDefault(p => p.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
            brandToUpdate.BrandId = brand.BrandId;
        }

       
    }
}
