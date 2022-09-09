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

namespace Kodlama.io.Devs.Application.Features.Frameworks.Commands.DeleteFramework
{
    public class DeleteFrameworkCommand:IRequest<DeletedFrameworkDto>
    {
        public int Id { get; set; }

        public class DeleteFrameworkCommandHandler : IRequestHandler<DeleteFrameworkCommand, DeletedFrameworkDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public DeleteFrameworkCommandHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }

            public async Task<DeletedFrameworkDto> Handle(DeleteFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework mappedFramework = _mapper.Map<Framework>(request);
                Framework deleteFramework = await _frameworkRepository.DeleteAsync(mappedFramework);
                DeletedFrameworkDto deleteProgrammingLanguageDto = _mapper.Map<DeletedFrameworkDto>(deleteFramework);

                return deleteProgrammingLanguageDto;
            }
        }
    }
}
