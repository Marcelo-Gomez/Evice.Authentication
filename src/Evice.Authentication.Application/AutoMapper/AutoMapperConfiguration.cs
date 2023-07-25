using AutoMapper;
using Evice.Authentication.Application.Commands.Requests.User;
using Evice.Authentication.Application.Commands.Responses.User;
using Evice.Authentication.Domain.AggregatesModel.UserAggregate;

namespace Evice.Authentication.Application.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<AddUserRequest, User>()
                .ForMember(dest => dest.EncryptedPassword, opt => opt.MapFrom(src => src.Password));

            CreateMap<User, AddUserResponse>();
        }
    }
}