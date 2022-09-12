﻿using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public  class GithubProfileRepository:EfRepositoryBase<GithubProfile,BaseDbContext>,IGithubProfileRepository
    {
        public GithubProfileRepository(BaseDbContext context):base(context)
        {
                
        }
    }
}
