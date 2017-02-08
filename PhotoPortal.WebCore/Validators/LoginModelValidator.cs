using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using PhotoPortal.WebCore.Models;

namespace PhotoPortal.WebCore.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(m => m.Login).NotEmpty().WithMessage("Login name is required");
            RuleFor(m => m.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
