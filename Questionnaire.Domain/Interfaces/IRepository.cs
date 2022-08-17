using Questionnaire.Domain.Entities;

namespace Questionnaire.Domain.Interfaces
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        public ValueTask<Entity> GetAsync(int id, CancellationToken cancellationToken);
        
        public IQueryable<Entity> GetAllAsNoTracking();
        public IQueryable<Entity> GetAllAsync();

        public Task AddAsync(Entity entity, CancellationToken cancellationToken);

        public Task UpdateAsync(Entity entity, CancellationToken cancellationToken);

        public Task DeleteAsync(Entity entity, CancellationToken cancellationToken);
    }
}
