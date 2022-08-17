﻿using Microsoft.EntityFrameworkCore;
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

        public async ValueTask<Entity> GetAsync(int id, CancellationToken cancellationToken) {

            var entity = await _context.Set<Entity>().FindAsync(id, cancellationToken);
            return entity ?? throw new NullReferenceException("Entity not found in DB");
        }

        public IQueryable<Entity> GetAllAsync() => _context.Set<Entity>().AsNoTracking();

        public IQueryable<Entity> GetAllAsNoTracking() => _context.Set<Entity>().AsNoTracking();

        public async Task AddAsync(Entity entity, CancellationToken cancellationToken)
        {
            await _context.Set<Entity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Entity entity, CancellationToken cancellationToken)
        {
            _context.Set<Entity>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Entity entity, CancellationToken cancellationToken)
        {
            _context.Set<Entity>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
