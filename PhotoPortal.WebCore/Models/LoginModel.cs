using FluentValidation.Attributes;

using PhotoPortal.WebCore.Models.Base;
using PhotoPortal.WebCore.Validators;

namespace PhotoPortal.WebCore.Models
{
    [Validator(typeof(LoginModelValidator))]
    public class LoginModel : BaseModel
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
