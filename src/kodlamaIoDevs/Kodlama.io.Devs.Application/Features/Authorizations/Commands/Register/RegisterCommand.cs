using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Users.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Commands.Register
{
    public class RegisterCommand:UserForRegisterDto,IRequest<RegisteteredDto>
    {
        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteteredDto>
        {
            private readonly IAuthRepository _authRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;

            public RegisterCommandHandler(IAuthRepository authRepository, IMapper mapper, ITokenHelper tokenHelper)
            {
                _authRepository = authRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
            }

            public async Task<RegisteteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                HashingHelper.CreatePasswordHash(request.Password,out byte[] passwordHash,out byte[] passwordSalt);
                User user = _mapper.Map<User>(request);
                user.PasswordHash= passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Status = true;

                User registedUser = await _authRepository.AddAsync(user);
                AccessToken token = _tokenHelper.CreateToken(user, new List<OperationClaim>());
                RegisteteredDto createdToken = _mapper.Map<RegisteteredDto>(token);

                return createdToken;
            }
        }
    }
}
