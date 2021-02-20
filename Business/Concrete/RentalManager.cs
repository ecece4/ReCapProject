using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        
        public RentalManager (IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
            
        }
        public IResult Add(Rental rental)
        {
            using (ReCapContext context=new ReCapContext())
            {
                if  (rental.ReturnDate == null)
                 
                   
                {
                    
                    return new ErrorDataResult<Rental>(Messages.NotDelivered);
                }
                else
                    return new SuccessDataResult<Rental>(Messages.Rented);
            }
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<Rental> GetRentalsById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
