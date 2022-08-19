using AutoMapper;
using Questionnaire.Blazor.Models.Questions;
using Questionnaire.Blazor.Models.Questions.Tags;
using Questionnaire.Domain.Entities;
using System;

namespace Questionnaire.Blazor.MapperPofiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionModel, PropertyEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.JsonName, opt => opt.MapFrom(src => src.JsonName))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => ConvertToQuestionType(src.QuestionType)));

            CreateMap<PropertyEntity, QuestionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.JsonName, opt => opt.MapFrom(src => src.JsonName))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ForMember(dest => dest.QuestionType, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.HtmlTags, opt => opt.MapFrom(src => TagsCreator.CreateTags(src)));
        }

        private QuestionType ConvertToQuestionType(string questionType)
        {
            Enum.TryParse<QuestionType>(questionType, out var result);
            return result;
        }
    }
}
