using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fluentvalidation.WebApiDemo.Models.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.LastName).NotEmpty();
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("Please specify a first name");
            RuleFor(customer => customer.Street).Length(5, 250);
            RuleFor(customer => customer.Birthdate)
                .InclusiveBetween(new DateTime(1900, 1, 1), DateTime.Today.AddYears(-18));                                    
        }
    }
}