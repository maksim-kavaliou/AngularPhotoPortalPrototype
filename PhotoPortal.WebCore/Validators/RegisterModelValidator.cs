using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using PhotoPortal.WebCore.Models;

namespace PhotoPortal.WebCore.Validators
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(m => m.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(m => m.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(m => m.PasswordConfirm).NotEmpty().WithMessage("Password confirm is required");
            RuleFor(m => m.PasswordConfirm).Equal(m => m.Password).WithMessage("Password and password confirm should be equal");
        }
    }
}
