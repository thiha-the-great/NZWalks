using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;
using NZWalks.API.Validations;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkDifficultiesController : ControllerBase
    {
        private readonly IWalkDifficultyRepository _walkDifficultyRepository;
        private readonly IMapper _mapper;

        public WalkDifficultiesController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            _walkDifficultyRepository = walkDifficultyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkDifficultiesAsync()
        {
            var walkDifficulties = await _walkDifficultyRepository.GetAllAsync();
            var walkDifficultiesDto = _mapper.Map<List<Models.Dto.WalkDifficulty>>(walkDifficulties);

            return Ok(walkDifficultiesDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultyAsync")]
        public async Task<IActionResult> GetWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await _walkDifficultyRepository.GetAsync(id);
            if (walkDifficulty == null) return NotFound();

            var walkDifficultyDto = _mapper.Map<Models.Dto.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficultyDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync(Models.Dto.AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            if (!WalkDifficultyManager.ValidateAddWalkDifficultyAsync(addWalkDifficultyRequest, ModelState)) return BadRequest(ModelState);

            var walkDifficulty = _mapper.Map<Models.Domain.WalkDifficulty>(addWalkDifficultyRequest);

            walkDifficulty = await _walkDifficultyRepository.AddAsync(walkDifficulty);

            var walkDifficultyDto = _mapper.Map<Models.Dto.WalkDifficulty>(walkDifficulty);

            return CreatedAtAction(nameof(GetWalkDifficultyAsync), new { id = walkDifficultyDto.Id }, walkDifficultyDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync([FromRoute] Guid id, [FromBody] Models.Dto.UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            if (!WalkDifficultyManager.ValidateUpdateWalkDifficultyAsync(updateWalkDifficultyRequest, ModelState)) return BadRequest(ModelState);

            var walkDifficulty = _mapper.Map<Models.Domain.WalkDifficulty>(updateWalkDifficultyRequest);

            walkDifficulty = await _walkDifficultyRepository.UpdateAsync(id, walkDifficulty);

            if (walkDifficulty == null) return NotFound();

            var walkDifficultyDto = _mapper.Map<Models.Dto.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficultyDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await _walkDifficultyRepository.DeleteAsync(id);

            if (walkDifficulty == null) return NotFound();

            var walkDifficultyDto = _mapper.Map<Models.Dto.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficultyDto);
        }
    }
}
