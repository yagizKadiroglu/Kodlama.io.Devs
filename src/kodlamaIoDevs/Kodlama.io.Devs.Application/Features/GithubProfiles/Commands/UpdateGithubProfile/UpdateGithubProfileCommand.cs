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

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
    public class UpdateGithubProfileCommand:IRequest<UpdatedGithubProfileDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubUrl { get; set; }


        public class UpdateGithubProfileCommandHandler : IRequestHandler<UpdateGithubProfileCommand, UpdatedGithubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGithubProfileRepository _githubProfileRepository;

            public UpdateGithubProfileCommandHandler(IMapper mapper, IGithubProfileRepository githubProfileRepository)
            {
                _mapper = mapper;
                _githubProfileRepository = githubProfileRepository;
            }

            public async Task<UpdatedGithubProfileDto> Handle(UpdateGithubProfileCommand request, CancellationToken cancellationToken)
            {
                GithubProfile githubProfile = _mapper.Map<GithubProfile>(request);
                GithubProfile updatedGithubProfile = await _githubProfileRepository.UpdateAsync(githubProfile);
                UpdatedGithubProfileDto updatedGithubProfileDto = _mapper.Map<UpdatedGithubProfileDto>(updatedGithubProfile);

                return updatedGithubProfileDto;
            }
        }
    }
}
