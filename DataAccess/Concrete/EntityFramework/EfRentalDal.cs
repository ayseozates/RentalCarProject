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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new RentalDetailDto
                             {   RentalId=r.Id,
                                 CompanyName=cu.CompanyName,
                                 CarName=c.CarName,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 DailyPrice=c.DailyPrice,
                                 RentDate=r.RentalDate,
                                 ReturnDate=r.ReturnDate



                             
                                 

                             };
                return result.ToList();

            }
        }
    }
}
