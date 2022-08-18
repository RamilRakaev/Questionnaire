using AutoMapper;
using Questionnaire.Blazor.Models;
using Questionnaire.Domain.Entities.Identity;

namespace Questionnaire.Blazor.MapperPofiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
