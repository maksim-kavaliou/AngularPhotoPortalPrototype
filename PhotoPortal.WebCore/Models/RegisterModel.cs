using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation.Attributes;

using PhotoPortal.WebCore.Models.Base;
using PhotoPortal.WebCore.Validators;

namespace PhotoPortal.WebCore.Models
{
    [Validator(typeof(RegisterModelValidator))]
    public class RegisterModel : BaseModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
