using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;
using NZWalks.API.Validations;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await _regionRepository.GetAllAsync();
            var regionsDto = _mapper.Map<List<Models.Dto.Region>>(regions);

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _regionRepository.GetAsync(id);
            if (region == null) return NotFound();

            var regionDto = _mapper.Map<Models.Dto.Region>(region);

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.Dto.AddRegionRequest addRegionRequest)
        {
            if (!RegionManager.ValidateAddRegionAsync(addRegionRequest, ModelState)) return BadRequest(ModelState);

            var region = _mapper.Map<Models.Domain.Region>(addRegionRequest);

            region = await _regionRepository.AddAsync(region);

            var regionDto = _mapper.Map<Models.Dto.Region>(region);

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id, [FromBody]Models.Dto.UpdateRegionRequest updateRegionRequest)
        {
            if (!RegionManager.ValidateUpdateRegionAsync(updateRegionRequest, ModelState)) return BadRequest(ModelState);

            var region = _mapper.Map<Models.Domain.Region>(updateRegionRequest);

            region = await _regionRepository.UpdateAsync(id, region);

            if (region == null) return NotFound();

            var regionDto = _mapper.Map<Models.Dto.Region>(region);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);

            if (region == null) return NotFound();

            var regionDto = _mapper.Map<Models.Dto.Region>(region);

            return Ok(regionDto);
        }
    }
}
