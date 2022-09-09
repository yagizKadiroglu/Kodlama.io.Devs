using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Frameworks.Commands.CreateFramework;
using Kodlama.io.Devs.Application.Features.Frameworks.Commands.DeleteFramework;
using Kodlama.io.Devs.Application.Features.Frameworks.Commands.UpdateFramework;
using Kodlama.io.Devs.Application.Features.Frameworks.Dtos.CommandDtos;
using Kodlama.io.Devs.Application.Features.Frameworks.Dtos.QueryDtos;
using Kodlama.io.Devs.Application.Features.Frameworks.Models;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Framework, CreatedFrameworkDto>().ReverseMap();
            CreateMap<Framework, CreateFrameworkCommand>().ReverseMap();

            CreateMap<Framework, UpdatedFrameworkDto>().ReverseMap();
            CreateMap<Framework, UpdateFrameworkCommand>().ReverseMap();

            CreateMap<Framework, DeletedFrameworkDto>().ReverseMap();
            CreateMap<Framework, DeleteFrameworkCommand>().ReverseMap();

            CreateMap<Framework, FrameworkListDto>().ForMember(f=>f.ProgrammingLanguageName,opt=>opt.MapFrom(f=>f.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<Framework>, FrameworksListModel>().ReverseMap();
        }
    }
}
