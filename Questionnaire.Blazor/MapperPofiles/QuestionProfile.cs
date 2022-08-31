using AutoMapper;
using Questionnaire.Blazor.Models.Questions;
using Questionnaire.Blazor.Models.Questions.Tags;
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
                .ForMember(dest => dest.CustomTypes, opt => opt.MapFrom(src => src.CustomTypes))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.JsonName, opt => opt.MapFrom(src => src.JsonName))
                .ForMember(dest => dest.QuestionType, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options.ToList()))
                .ForMember(dest => dest.HtmlTags, opt => opt.MapFrom(src => TagsCreator.CreateTags(src)));

            CreateMap<QuestionModel, Property>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StructureId, opt => opt.MapFrom(src => src.QuestionnaireId))
                .ForMember(dest => dest.CustomTypes, opt => opt.MapFrom(src => src.CustomTypes))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.JsonName, opt => opt.MapFrom(src => src.JsonName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.QuestionType))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));
        }
    }
}
