using AutoMapper;
using Questionnaire.Blazor.Models.Questions;
using Questionnaire.Domain.Entities;
using System.Linq;

namespace Questionnaire.Blazor.MapperPofiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Property, QuestionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.QuestionnaireId, opt => opt.MapFrom(src => src.StructureId))
                .ForMember(dest => dest.CustomTypeId, opt => opt.MapFrom(src => src.CustomTypeId))
                .ForMember(dest => dest.CustomType, opt => opt.MapFrom(src => src.CustomType))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.JsonName, opt => opt.MapFrom(src => src.JsonName))
                .ForMember(dest => dest.QuestionType, opt => opt.MapFrom(src => src.PropertyType.ToString()))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options.ToList()));

            CreateMap<QuestionModel, Property>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StructureId, opt => opt.MapFrom(src => src.QuestionnaireId))
                .ForMember(dest => dest.CustomType, opt => opt.MapFrom(src => src.CustomType))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.JsonName, opt => opt.MapFrom(src => src.JsonName))
                .ForMember(dest => dest.PropertyType, opt => opt.MapFrom(src => src.QuestionType))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));
        }
    }
}
