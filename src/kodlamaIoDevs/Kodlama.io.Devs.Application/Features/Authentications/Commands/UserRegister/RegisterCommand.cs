using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.UserRegister
{
    public class RegisterCommand:UserForRegisterDto,IRequest<RegisteteredDto>
    {
        public class UserRegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteteredDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _userBusinessRules;

            public UserRegisterCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<RegisteteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.EmailCheck(request.Email);

                HashingHelper.CreatePasswordHash(request.Password,out byte[] passwordHash,out byte[] passwordSalt);
                User user = _mapper.Map<User>(request);
                user.PasswordHash= passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Status = true;

                User registedUser = await _userRepository.AddAsync(user);
                AccessToken token = _tokenHelper.CreateToken(user, new List<OperationClaim>());
                RegisteteredDto createdToken = _mapper.Map<RegisteteredDto>(token);

                return createdToken;
            }
        }
    }
}
