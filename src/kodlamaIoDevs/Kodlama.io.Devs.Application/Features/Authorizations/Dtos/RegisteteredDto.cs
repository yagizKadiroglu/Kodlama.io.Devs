using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Users.Dtos
{
    public class RegisteteredDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
