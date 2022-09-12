using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.UserLogin
{
    public class LoginCommandValidation:AbstractValidator<LoginCommand>
    {
        public LoginCommandValidation()
        {
            RuleFor(u=>u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
