using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id

                             join m in context.Customers
                             on r.CustomerId equals m.Id
                             join u in context.Users
                             on m.Id equals u.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new RentalDetailDto
                             {
                                 Id=r.Id,
                                 CarId=c.Id,
                                CustomerId=m.Id,
                                 CarName = c.CarName,
                              
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CompanyName = m.CompanyName,
                                 Brand = b.BrandName,
                                 Color = co.ColorName

                             };


                return result.ToList();
            }
        }

        public RentalDetailDto GetRentalDetailsByCarId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from r in context.Rentals
                              join c in context.Cars
                              on r.CarId equals c.Id

                              join m in context.Customers
                              on r.CustomerId equals m.Id
                              join u in context.Users
                              on m.Id equals u.Id
                              join b in context.Brands
                              on c.BrandId equals b.BrandId
                              join co in context.Colors
                              on c.ColorId equals co.ColorId
                              where r.CarId == id
                              orderby r.Id ascending
                              select new RentalDetailDto
                              {
                                  Id = r.Id,
                                  CarId=c.Id,
                                  CustomerId = m.Id,
                                  CarName = c.CarName,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  RentDate = r.RentDate,
                                  ReturnDate = r.ReturnDate,
                                  CompanyName = m.CompanyName,
                                  Brand = b.BrandName,
                                  Color = co.ColorName

                              }). LastOrDefault();


                return result;
            }
        }
    }
}

