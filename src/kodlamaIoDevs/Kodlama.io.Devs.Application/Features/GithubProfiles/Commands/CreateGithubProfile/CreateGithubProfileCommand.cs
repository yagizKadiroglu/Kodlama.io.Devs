using AutoMapper;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dto;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile
{
    public class CreateGithubProfileCommand:IRequest<CreatedGithubProfileDto>
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public class CreateGithubProfileCommandHandler : IRequestHandler<CreateGithubProfileCommand, CreatedGithubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGithubProfileRepository _githubProfileRepository;

            public CreateGithubProfileCommandHandler(IMapper mapper, IGithubProfileRepository githubProfileRepository)
            {
                _mapper = mapper;
                _githubProfileRepository = githubProfileRepository;
            }

            public async Task<CreatedGithubProfileDto> Handle(CreateGithubProfileCommand request, CancellationToken cancellationToken)
            {
                GithubProfile githubProfile = _mapper.Map<GithubProfile>(request);

                GithubProfile createdGithubProfile = await _githubProfileRepository.AddAsync(githubProfile);

                CreatedGithubProfileDto createGithubProfileDto = _mapper.Map<CreatedGithubProfileDto>(createdGithubProfile);

                return createGithubProfileDto;
            }
        }
    }
}
