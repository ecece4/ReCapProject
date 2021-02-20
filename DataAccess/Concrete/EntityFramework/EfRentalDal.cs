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
    public class EfRentalDal :EfEntityRepositoryBase<Rental,ReCapContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from c in context.Cars
                             

                             join r in context.Rentals
                             on c.Id equals r.Id

                             join m in context.Customers
                             on r.CustomerId equals m.CustomerId


                             join u in context.Users
                             on m.CustomerId equals u.UserId

                             select new RentalDetailDto
                             {
                                 CarName = c.CarName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                                 
                             };

       
            return result.ToList();
        }
    }  
    }
}
