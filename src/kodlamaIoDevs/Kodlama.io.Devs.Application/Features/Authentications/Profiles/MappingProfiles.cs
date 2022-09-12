using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.UserRegister;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<AccessToken, RegisteteredDto>().ReverseMap();
            CreateMap<User, RegisterCommand>().ReverseMap();

            CreateMap<AccessToken, LoginDto>().ReverseMap();
        }
    }
}
