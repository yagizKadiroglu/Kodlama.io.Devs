using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.UserRegister
{
    public class RegisterCommandValidation:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidation()
        {
            RuleFor(u => u.UserForRegisterDto.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(u => u.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(u => u.UserForRegisterDto.Password).NotEmpty();



        }
    }
}
