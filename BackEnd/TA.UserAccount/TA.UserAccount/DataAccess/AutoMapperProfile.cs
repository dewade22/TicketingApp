using AutoMapper;
using TA.UserAccount.DataAccess.Application;
using TA.UserAccount.Dto;

namespace TA.UserAccount.DataAccess
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<ComUserAccount, UserAccountDto>().ReverseMap();
            this.CreateMap<ComUserInRole, UserInRoleDto>().ReverseMap();
            this.CreateMap<ComRole, RolesDto>().ReverseMap();
            this.CreateMap<ComUserMembership, UserMembershipDto>().ReverseMap();
            this.CreateMap<ComUserRefreshToken, UserRefreshTokenDto>().ReverseMap();
        }
    }
}
