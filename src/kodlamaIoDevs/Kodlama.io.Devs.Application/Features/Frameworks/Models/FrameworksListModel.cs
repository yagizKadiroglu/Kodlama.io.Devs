using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Frameworks.Dtos.QueryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Models
{
    public class FrameworksListModel:BasePageableModel
    {
        public List<FrameworkListDto> Items { get; set; }
    }
}
