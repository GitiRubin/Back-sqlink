using AutoMapper;
using Common;
using Repositories.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDTO, Person>().ReverseMap();
        }
    }
}
