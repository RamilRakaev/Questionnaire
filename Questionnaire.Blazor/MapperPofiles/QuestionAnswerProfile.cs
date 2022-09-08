using AutoMapper;
using Questionnaire.Blazor.Models;
using Questionnaire.Infrastructure.Models;

namespace Questionnaire.Blazor.MapperPofiles
{
    public class QuestionAnswerProfile : Profile
    {
        public QuestionAnswerProfile()
        {
            CreateMap<QuestionAnswerModel, PropertyAnswer>()
                .ForMember(dest => dest.Property, opt => opt.MapFrom(src => src.Question))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer))
                .ForMember(dest => dest.PropertyAnswers, opt => opt.MapFrom(src => src.QuestionAnswers));
        }
    }
}
