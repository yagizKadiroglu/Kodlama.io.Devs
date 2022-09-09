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

namespace Kodlama.io.Devs.Application.Features.Frameworks.Commands.UpdateFramework
{
    public class UpdateFrameworkCommand:IRequest<UpdatedFrameworkDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class UpdateFrameworkCommandHandler : IRequestHandler<UpdateFrameworkCommand, UpdatedFrameworkDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public UpdateFrameworkCommandHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }

            public async Task<UpdatedFrameworkDto> Handle(UpdateFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework framework = _mapper.Map<Framework>(request);
                Framework updatedFramework = await _frameworkRepository.UpdateAsync(framework);
                UpdatedFrameworkDto updatedFrameworkDto = _mapper.Map<UpdatedFrameworkDto>(updatedFramework);

                return updatedFrameworkDto;


            }
        }
    }
}
