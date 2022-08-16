using AutoMapper;
using Questionnaire.Blazor.Models.Questions.Tags;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Blazor.MapperPofiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {

        }

        private HtmlTag[] ConvertToHtmlTags(QuestionType questionType)
        {
            return null;
        }
    }
}
