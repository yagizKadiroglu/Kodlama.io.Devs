using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Frameworks.Commands.CreateFramework;
using Kodlama.io.Devs.Application.Features.Frameworks.Dtos.CommandDtos;
using Kodlama.io.Devs.Application.Features.Frameworks.Models;
using Kodlama.io.Devs.Application.Features.Frameworks.Queries.GetListFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworksController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateFrameworkCommand createFrameworkCommand)
        {
            CreatedFrameworkDto result = await Mediator.Send(createFrameworkCommand);
            return Created("", result);
        }


        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListFrameworkQuery getListFrameworkQuery = new() { PageRequest = pageRequest };
            FrameworksListModel result = await Mediator.Send(getListFrameworkQuery);
            return Ok(result);
        }
    }
}
