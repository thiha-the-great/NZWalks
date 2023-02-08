using Microsoft.AspNetCore.Mvc.ModelBinding;
using NZWalks.API.Models.Dto;

namespace NZWalks.API.Validations
{
    public static class RegionManager
    {
        public static bool ValidateAddRegionAsync(AddRegionRequest addRegionRequest, ModelStateDictionary  modelState)
        {
            if (addRegionRequest == null)
            {
                modelState.AddModelError(nameof(addRegionRequest), "Region data is required.");
                return false;
            }

            if (string.IsNullOrEmpty(addRegionRequest.Code))
            {
                modelState.AddModelError(nameof(addRegionRequest.Code), $"{nameof(addRegionRequest.Code)} cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(addRegionRequest.Name))
            {
                modelState.AddModelError(nameof(addRegionRequest.Name), $"{nameof(addRegionRequest.Name)} cannot be null or empty.");
            }

            if (addRegionRequest.Area <= 0)
            {
                modelState.AddModelError(nameof(addRegionRequest.Area), $"{nameof(addRegionRequest.Area)} cannot be less than or equal to zero.");
            }

            if (addRegionRequest.Population < 0)
            {
                modelState.AddModelError(nameof(addRegionRequest.Population), $"{nameof(addRegionRequest.Population)} cannot be less than zero.");
            }

            if (modelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateUpdateRegionAsync(UpdateRegionRequest updateRegionRequest, ModelStateDictionary modelState)
        {
            if (updateRegionRequest == null)
            {
                modelState.AddModelError(nameof(updateRegionRequest), "Region data is required.");
                return false;
            }

            if (string.IsNullOrEmpty(updateRegionRequest.Code))
            {
                modelState.AddModelError(nameof(updateRegionRequest.Code), $"{nameof(updateRegionRequest.Code)} cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(updateRegionRequest.Name))
            {
                modelState.AddModelError(nameof(updateRegionRequest.Name), $"{nameof(updateRegionRequest.Name)} cannot be null or empty.");
            }

            if (updateRegionRequest.Area <= 0)
            {
                modelState.AddModelError(nameof(updateRegionRequest.Area), $"{nameof(updateRegionRequest.Area)} cannot be less than or equal to zero.");
            }

            if (updateRegionRequest.Lat <= 0)
            {
                modelState.AddModelError(nameof(updateRegionRequest.Lat), $"{nameof(updateRegionRequest.Lat)} cannot be less than or equal to zero.");
            }

            if (updateRegionRequest.Long <= 0)
            {
                modelState.AddModelError(nameof(updateRegionRequest.Long), $"{nameof(updateRegionRequest.Long)} cannot be less than or equal to zero.");
            }

            if (updateRegionRequest.Population < 0)
            {
                modelState.AddModelError(nameof(updateRegionRequest.Population), $"{nameof(updateRegionRequest.Population)} cannot be less than zero.");
            }

            if (modelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }
    }
}
