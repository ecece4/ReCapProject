using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
         

    {
        public List<CustomerDetailDto> GetCustomerDetails()
           
        {
            using (ReCapContext context =new ReCapContext())
            { 
                var result = from m in context.Customers
                             join k in context.Users
                             on m.CustomerId equals k.UserId
                             select new CustomerDetailDto
                             {
                                 UserId = k.UserId,
                                 CompanName = m.CompanyName
                             };
                return result.ToList();

            }
        }
    }
}
