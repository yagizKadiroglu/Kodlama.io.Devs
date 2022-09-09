using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Frameworks.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Queries.GetListFramework
{
    public class GetListFrameworkQuery:IRequest<FrameworksListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListFrameworkHandler : IRequestHandler<GetListFrameworkQuery, FrameworksListModel>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;

            public GetListFrameworkHandler(IFrameworkRepository frameworkRepository, IMapper mapper)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
            }

            public async Task<FrameworksListModel> Handle(GetListFrameworkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Framework> frameworks = await _frameworkRepository.GetListAsync(include:
                                                                                          f=>f.Include(c=>c.ProgrammingLanguage),
                                                                                          index: request.PageRequest.Page,
                                                                                          size: request.PageRequest.PageSize);
                FrameworksListModel mappedFrameworksListModel = _mapper.Map<FrameworksListModel>(frameworks);
                return mappedFrameworksListModel;
            }
        }
    }
}
