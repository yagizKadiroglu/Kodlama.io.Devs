using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Framework:Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string  Name { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }

        public Framework()
        {
        }

        public Framework(int id,int programmingLanguageId, string name):this()
        {
            Id= id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }
    }
}
