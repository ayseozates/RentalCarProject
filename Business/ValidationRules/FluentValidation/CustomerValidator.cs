using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Entities.Concrete.Customer>
    {


        public CustomerValidator()
        {
            RuleFor(b => b.CompanyName).MinimumLength(2);
            RuleFor(b => b.CompanyName).NotEmpty();
        }


    }
}
