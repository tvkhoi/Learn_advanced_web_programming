using AutoMapper;

namespace Chat.Models
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UserDomainModel, UserBLLModel>().ReverseMap();
			CreateMap<UserBLLModel, UserViewModel>().ReverseMap();
		}
	}
}
