using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.UserLogin
{
    public class LoginCommand:UserForLoginDto,IRequest<LoginDto>
    {
        public class UserLoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            ITokenHelper _tokenHelper;
            AuthBusinessRules _userBusinessRules;


            public UserLoginCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _userBusinessRules = userBusinessRules;
            }

            public  async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {

                await _userBusinessRules.NoEmailCheck(request.Email);
                User? user = await _userRepository.GetAsync(
                    u => u.Email.ToLower() == request.Email.ToLower(),
                    include: m=>m.Include(uc=>uc.UserOperationClaims).ThenInclude(x=>x.OperationClaim));

                await _userBusinessRules.PasswordCheck(request.Password, user.PasswordHash, user.PasswordSalt);

                List<OperationClaim> claims = user.UserOperationClaims.Select(o=>o.OperationClaim).ToList();

                AccessToken accessToken = _tokenHelper.CreateToken(user, claims);
                LoginDto userLoginDto = _mapper.Map<LoginDto>(accessToken);


                return userLoginDto;
            }
        }
    }
}
