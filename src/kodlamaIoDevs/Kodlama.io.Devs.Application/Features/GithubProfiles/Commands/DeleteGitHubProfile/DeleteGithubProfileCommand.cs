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

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGitHubProfile
{
    public class DeleteGithubProfileCommand:IRequest<DeletedGithubProfileDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public class DeleteGithubProfileCommandHandler : IRequestHandler<DeleteGithubProfileCommand, DeletedGithubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGithubProfileRepository _githubProfileRepository;

            public DeleteGithubProfileCommandHandler(IMapper mapper, IGithubProfileRepository githubProfileRepository)
            {
                _mapper = mapper;
                _githubProfileRepository = githubProfileRepository;
            }
            public async Task<DeletedGithubProfileDto> Handle(DeleteGithubProfileCommand request, CancellationToken cancellationToken)
            {


                GithubProfile githubProfile = _mapper.Map<GithubProfile>(request);
                GithubProfile deletedGithubProfile = await _githubProfileRepository.DeleteAsync(githubProfile);
                DeletedGithubProfileDto deletedGithubProfileDto = _mapper.Map<DeletedGithubProfileDto>(deletedGithubProfile);

                return deletedGithubProfileDto;
            }
        }
    }
}
