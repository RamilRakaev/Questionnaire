using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;

namespace Questionnaire.Infrastructure.Database
{
    public class BaseRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        private readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public ValueTask<Entity?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return _context.Set<Entity>().FindAsync(id, cancellationToken);
        }

        public IQueryable<Entity> GetAllAsync()
        {
            return _context.Set<Entity>().AsNoTracking();
        }

        public IQueryable<Entity> GetAllAsNoTracking()
        {
            return _context.Set<Entity>().AsNoTracking();
        }

        public async Task AddAsync(Entity entity, CancellationToken cancellationToken)
        {
            await _context.Set<Entity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Entity entity, CancellationToken cancellationToken)
        {
            _context.Set<Entity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entity entity, CancellationToken cancellationToken)
        {
            _context.Set<Entity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
