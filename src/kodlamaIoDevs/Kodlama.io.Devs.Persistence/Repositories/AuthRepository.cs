using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class AuthRepository:EfRepositoryBase<User,BaseDbContext>,IAuthRepository
    {
        public AuthRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
