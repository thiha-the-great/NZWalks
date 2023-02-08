using Microsoft.AspNetCore.Mvc.ModelBinding;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;

namespace NZWalks.API.Validations
{
    public static class WalkManager
    {
        public static bool ValidateAddWalkAsync(AddWalkRequest addWalkRequest, IRegionRepository regionRepository, IWalkDifficultyRepository walkDifficultyRepository, ModelStateDictionary modelState)
        {
            if (addWalkRequest == null)
            {
                modelState.AddModelError(nameof(addWalkRequest), "Walk data is required.");
                return false;
            }

            if (string.IsNullOrEmpty(addWalkRequest.Name))
            {
                modelState.AddModelError(nameof(addWalkRequest.Name), $"{nameof(addWalkRequest.Name)} cannot be null or empty.");
            }

            if (addWalkRequest.Length <= 0)
            {
                modelState.AddModelError(nameof(addWalkRequest.Length), $"{nameof(addWalkRequest.Length)} cannot be less than or equal to zero.");
            }

            var region = regionRepository.GetAsync(addWalkRequest.RegionId).GetAwaiter().GetResult();
            if (region == null)
            {
                modelState.AddModelError(nameof(addWalkRequest.RegionId), $"{nameof(addWalkRequest.RegionId)} is invalid.");
            }

            var walkDifficulty = walkDifficultyRepository.GetAsync(addWalkRequest.WalkDifficultyId).GetAwaiter().GetResult();
            if (walkDifficulty == null)
            {
                modelState.AddModelError(nameof(addWalkRequest.WalkDifficultyId), $"{nameof(addWalkRequest.WalkDifficultyId)} is invalid.");
            }

            if (modelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateUpdateWalkAsync(UpdateWalkRequest updateWalkRequest, IRegionRepository regionRepository, IWalkDifficultyRepository walkDifficultyRepository, ModelStateDictionary modelState)
        {
            if (updateWalkRequest == null)
            {
                modelState.AddModelError(nameof(updateWalkRequest), "Walk data is required.");
                return false;
            }

            if (string.IsNullOrEmpty(updateWalkRequest.Name))
            {
                modelState.AddModelError(nameof(updateWalkRequest.Name), $"{nameof(updateWalkRequest.Name)} cannot be null or empty.");
            }

            if (updateWalkRequest.Length <= 0)
            {
                modelState.AddModelError(nameof(updateWalkRequest.Length), $"{nameof(updateWalkRequest.Length)} cannot be less than or equal to zero.");
            }

            var region = regionRepository.GetAsync(updateWalkRequest.RegionId).GetAwaiter().GetResult();
            if (region == null)
            {
                modelState.AddModelError(nameof(updateWalkRequest.RegionId), $"{nameof(updateWalkRequest.RegionId)} is invalid.");
            }

            var walkDifficulty = walkDifficultyRepository.GetAsync(updateWalkRequest.WalkDifficultyId).GetAwaiter().GetResult();
            if (walkDifficulty == null)
            {
                modelState.AddModelError(nameof(updateWalkRequest.WalkDifficultyId), $"{nameof(updateWalkRequest.WalkDifficultyId)} is invalid.");
            }

            if (modelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }
    }
}
