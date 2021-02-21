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
            RentalDetailDto rentalDetailDto;
            rentalDetailDto= _rentalDal.GetRentalDetailsByCarId(rental.CarId);
                if  (rentalDetailDto==null)
                {
                    _rentalDal.Add(rental);
                    return new SuccessDataResult<Rental>(Messages.Rented);

                    
                }
                else if(rentalDetailDto.ReturnDate.Year>2000 && rentalDetailDto.Id>0 )
                {
                    _rentalDal.Add(rental);
                    return new SuccessDataResult<Rental>(Messages.Rented);
                }

                else
                    return new ErrorDataResult<Rental>(Messages.NotDelivered);

            
        }

    

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
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
            RentalDetailDto rentalDetailDto = _rentalDal.GetRentalDetailsByCarId(rental.CarId);
            rental.CarId = rentalDetailDto.CarId;
            rental.CustomerId = rentalDetailDto.CustomerId;
            rental.RentDate = rentalDetailDto.RentDate;
            rental.ReturnDate = DateTime.Now;
            rental.Id = rentalDetailDto.Id;

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdatedSuccess);
        }

        public IDataResult<RentalDetailDto> GetRentalDetailsByCarId(int id)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetailsByCarId(id));

        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
