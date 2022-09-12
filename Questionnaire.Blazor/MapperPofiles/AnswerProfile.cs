using AutoMapper;
using Questionnaire.Blazor.Models;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Blazor.MapperPofiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.QuestionnaireId, opt => opt.MapFrom(src => src.StructureId))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));

            CreateMap<AnswerModel, Answer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.StructureId, opt => opt.MapFrom(src => src.QuestionnaireId))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));
        }
    }
}
