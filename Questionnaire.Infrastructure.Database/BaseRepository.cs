using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;

namespace Questionnaire.Infrastructure.Database
{
    public class BaseRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        private readonly QuestionnaireContext _context;

        public BaseRepository(QuestionnaireContext context)
        {
            _context = context;
        }

        public async Task<Entity> GetAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<Entity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            return entity ?? throw new NullReferenceException("Entity no found in DB");
        }

        public IQueryable<Entity> GetAllAsync() => _context.Set<Entity>().AsNoTracking();

        public IQueryable<Entity> GetAllAsNoTracking() => _context.Set<Entity>().AsNoTracking();

        public async Task AddAsync(Entity entity, CancellationToken cancellationToken)
        {
            await _context.Set<Entity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<Entity> entities, CancellationToken cancellationToken)
        {
            await _context.Set<Entity>().AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Entity entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(Entity entity, CancellationToken cancellationToken)
        {
            _context.Set<Entity>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveRangeAsync(IEnumerable<Entity> entities, CancellationToken cancellationToken)
        {
            _context.Set<Entity>().RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task Save(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
