using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Domain.Walk, Models.Dto.Walk>()
                .ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.WalkDifficulty>()
                .ReverseMap();

            CreateMap<Models.Domain.Walk, Models.Dto.AddWalkRequest>()
                .ReverseMap();

            CreateMap<Models.Domain.Walk, Models.Dto.UpdateWalkRequest>()
                .ReverseMap();
        }
    }
}
