using AutoMapper;
using Kodlama.io.Devs.Application.Features.Frameworks.Dtos.CommandDtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Commands.CreateFramework
{
    public class CreateFrameworkCommand:IRequest<CreatedFrameworkDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class CreateFrameworkCommandHandler : IRequestHandler<CreateFrameworkCommand, CreatedFrameworkDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public CreateFrameworkCommandHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }

            public async Task<CreatedFrameworkDto> Handle(CreateFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework mappedFramework = _mapper.Map<Framework>(request);
                Framework createdFramework = await _frameworkRepository.AddAsync(mappedFramework);
                CreatedFrameworkDto createdFrameworkDto = _mapper.Map<CreatedFrameworkDto>(createdFramework);

                return createdFrameworkDto;
            }
        }
    }
}
