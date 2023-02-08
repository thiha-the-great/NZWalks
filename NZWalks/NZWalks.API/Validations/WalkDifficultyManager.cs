using Microsoft.AspNetCore.Mvc.ModelBinding;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;

namespace NZWalks.API.Validations
{
    public static class WalkDifficultyManager
    {
        public static bool ValidateAddWalkDifficultyAsync(AddWalkDifficultyRequest addWalkDifficltyRequest, ModelStateDictionary modelState)
        {
            if (addWalkDifficltyRequest == null)
            {
                modelState.AddModelError(nameof(addWalkDifficltyRequest), "Walk difficulty data is required.");
                return false;
            }

            if (string.IsNullOrEmpty(addWalkDifficltyRequest.Code))
            {
                modelState.AddModelError(nameof(addWalkDifficltyRequest.Code), $"{nameof(addWalkDifficltyRequest.Code)} cannot be null or empty.");
            }

            if (modelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateUpdateWalkDifficultyAsync(UpdateWalkDifficultyRequest updateWalkDifficltyRequest, ModelStateDictionary modelState)
        {
            if (updateWalkDifficltyRequest == null)
            {
                modelState.AddModelError(nameof(updateWalkDifficltyRequest), "Walk difficulty data is required.");
                return false;
            }

            if (string.IsNullOrEmpty(updateWalkDifficltyRequest.Code))
            {
                modelState.AddModelError(nameof(updateWalkDifficltyRequest.Code), $"{nameof(updateWalkDifficltyRequest.Code)} cannot be null or empty.");
            }

            if (modelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }
    }
}
