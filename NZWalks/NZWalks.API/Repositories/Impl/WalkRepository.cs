using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories.Impl
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            _nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _nZWalksDbContext.Walks
                .Include(i => i.Region)
                .Include(i => i.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await _nZWalksDbContext.Walks
                .Include(i => i.Region)
                .Include(i => i.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = new Guid();

            await _nZWalksDbContext.AddAsync(walk);
            await _nZWalksDbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null) return null;

            existingWalk.Length = walk.Length;
            existingWalk.Name = walk.Name;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _nZWalksDbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk = await _nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null) return null;

            _nZWalksDbContext.Walks.Remove(walk);
            await _nZWalksDbContext.SaveChangesAsync();

            return walk;
        }
    }
}
