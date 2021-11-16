using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental,RentACarContext>,IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetailsDto()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rt in context.Rentals
                    join cr in context.Cars
                        on rt.CarId equals cr.CarId
                    join br in context.Brands
                        on cr.BrandId equals br.BrandId
                    join usr in context.Users
                        on rt.CustomerId equals usr.Id
                    select new RentalDetailsDto
                    {
                        Id = rt.Id,
                        BrandName = br.BrandName,
                        FirstName = usr.FirstName,
                        LastName = usr.LastName,
                        RentDate = rt.RentDate,
                        ReturnDate = rt.ReturnDate

                    };
                return result.ToList();
            }
            
        }
    }
}