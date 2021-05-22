using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty();
           // RuleFor(c => c.UserId).Equal(customer.UserId).WithMessage("Kullanıcı olmadığı için müşteri olamaz");
        }
    }
}
