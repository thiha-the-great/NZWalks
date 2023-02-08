using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAync() 
        {
            var walks = await _walkRepository.GetAllAsync();
            var walksDto = _mapper.Map<List<Models.Dto.Walk>>(walks);

            return Ok(walksDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var walk = await _walkRepository.GetAsync(id);
            if (walk == null) return NotFound();

            var walkDto = _mapper.Map<Models.Dto.Walk>(walk);

            return Ok(walkDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync(Models.Dto.AddWalkRequest addWalkRequest)
        {
            var walk = _mapper.Map<Models.Domain.Walk>(addWalkRequest);

            walk = await _walkRepository.AddAsync(walk);

            var walkDto = _mapper.Map<Models.Dto.Walk>(walk);

            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDto.Id }, walkDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] Models.Dto.UpdateWalkRequest updateWalkRequest)
        {

            var walk = _mapper.Map<Models.Domain.Walk>(updateWalkRequest);

            walk = await _walkRepository.UpdateAsync(id, walk);

            if (walk == null) return NotFound();

            var walkDto = _mapper.Map<Models.Dto.Walk>(walk);

            return Ok(walkDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var walk = await _walkRepository.DeleteAsync(id);

            if (walk == null) return NotFound();

            var walkDto = _mapper.Map<Models.Dto.Walk>(walk);

            return Ok(walkDto);
        }

    }
}
