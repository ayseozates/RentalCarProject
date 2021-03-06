﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {


        public RentalValidator()
        {
            RuleFor(b => b.RentalDate).NotEmpty();
            RuleFor(b => b.ReturnDate).NotEmpty();
        }


    }
}
