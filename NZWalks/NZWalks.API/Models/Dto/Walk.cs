using System.Text.Json.Serialization;

namespace NZWalks.API.Models.Dto
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }

        [JsonIgnore]
        public Guid RegionId { get; set; }
        [JsonIgnore]
        public Guid WalkDifficultyId { get; set; }

        //Navigation Properties
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
