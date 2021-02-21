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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.UserId
                             select new CustomerDetailDto {FirstName=u.FirstName,LastName=u.LastName,CompanyName=c.CompanyName,CustomerId=c.CustomerId,Email=u.Email,Password=u.Password };
                           return result.ToList(); 

            }
        }
    }
}
