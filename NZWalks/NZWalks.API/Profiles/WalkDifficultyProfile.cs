using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.WalkDifficulty>()
                .ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.AddWalkDifficultyRequest>()
                    .ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.UpdateWalkDifficultyRequest>()
                    .ReverseMap();
        }
    }
}
