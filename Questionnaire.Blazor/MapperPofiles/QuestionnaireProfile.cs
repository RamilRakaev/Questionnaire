using AutoMapper;
using Questionnaire.Blazor.Models;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Blazor.MapperPofiles
{
    public class QuestionnaireProfile : Profile
    {
        public QuestionnaireProfile()
        {
            CreateMap<Structure, QuestionnaireModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Properties));

            CreateMap<QuestionnaireModel, Structure>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ForMember(dest => dest.Properties, opt => opt.MapFrom(src => src.Questions));
        }
    }
}
