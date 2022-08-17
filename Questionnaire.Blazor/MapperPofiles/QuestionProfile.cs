using AutoMapper;
using Questionnaire.Blazor.Models.Questions;
using Questionnaire.Blazor.Models.Questions.Tags;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Blazor.MapperPofiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionBase, PropertyEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.HtmlTags ));

            CreateMap<PropertyEntity, QuestionBase >()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.HtmlTags, opt => opt.MapFrom(src => src.Type ));
        }

        private HtmlTag[] ConvertToHtmlTags(QuestionType questionType, string displayName)
        {
            var cssClasses = questionType switch
            {
                QuestionType.Boolean => "form-check",
                QuestionType.Enumeration => "custom-select",
                _ => "form-control"
            };
            return new HtmlTag[]
            {
                new()
                {
                    TagName = TagName.Label,
                    Value = displayName,
                },
                new()
                {
                    TagName = TagName.Input,
                    Attrubutes = new()
                    {
                        { "type", questionType },
                        { "class", cssClasses },
                    },
                },
            }; ;
        }
    }
}
