using AutoMapper;
using Questionnaire.Blazor.Models;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Blazor.MapperPofiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AnswerEntity, Answer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
