using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Domain.Region, Models.Dto.Region>()
                .ReverseMap();

            CreateMap<Models.Domain.Region, Models.Dto.AddRegionRequest>()
                .ReverseMap();

            CreateMap<Models.Domain.Region, Models.Dto.UpdateRegionRequest>()
                .ReverseMap();
        }
    }
}
