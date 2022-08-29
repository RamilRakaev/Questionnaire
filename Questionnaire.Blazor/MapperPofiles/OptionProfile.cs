using AutoMapper;
using Questionnaire.Blazor.Models.Questions;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Blazor.MapperPofiles
{
    public class OptionProfile : Profile
    {
        public OptionProfile()
        {
            CreateMap<Option, OptionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.PropertyId))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.JsonName, opt => opt.MapFrom(src => src.JsonName));

            CreateMap<OptionModel, Option>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PropertyId, opt => opt.MapFrom(src => src.QuestionId))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.JsonName, opt => opt.MapFrom(src => src.JsonName));
        }
    }
}
