using AdControllerApi.Dtos;
using AutoMapper;
using MyAdsApi.Models;

namespace MyAdsApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserLoginDto, User>(); // Mapping from UserLoginDto to User
            CreateMap<RewardClaimRequestDto, RewardClaimRequest>(); // Mapping from RewardClaimRequestDto to RewardClaimRequest
            CreateMap<AdSettingUpdateRequestDto, AdSetting>(); // Mapping from AdSettingUpdateRequestDto to AdSetting
            // Add more mappings as needed
        }
    }
}
