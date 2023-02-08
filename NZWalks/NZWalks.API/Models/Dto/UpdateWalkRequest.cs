﻿using System.Text.Json.Serialization;

namespace NZWalks.API.Models.Dto
{
    public class UpdateWalkRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
    }
}
