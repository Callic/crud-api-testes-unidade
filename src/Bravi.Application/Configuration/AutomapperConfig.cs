using AutoMapper;
using Bravi.Application.DTOs;
using Bravi.Application.Responses;
using Bravi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Application.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            //CreateMap(typeof(GenericResponse<>), typeof(GenericResponse<>));
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<ContatoDTO, Contato>().ReverseMap();
            //CreateMap<Contato, ContatoDTO>()
            //    .ForMember(dest => dest.PessoaId, opt => opt.MapFrom(src => src.Pessoa.Id));
                
        }
    }
}
