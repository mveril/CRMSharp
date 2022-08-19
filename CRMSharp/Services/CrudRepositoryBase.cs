using Microsoft.EntityFrameworkCore;

namespace CRMSharp.Services
{
    public abstract class CRUDRepositoryBase<TEntity,TContext> : ICRUD<TEntity> where TEntity : class where TContext : DbContext
    {
        protected TContext Context { get; }

        protected CRUDRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task Create(TEntity item)
        {
            await Context.Set<TEntity>().AddAsync(item).ConfigureAwait(false);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual IAsyncEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsAsyncEnumerable();
        }

        public Task<TEntity?> GetById(int id)
        {
            return Context.Set<TEntity>().FindAsync(id).AsTask();
        }

        public async Task<bool> TryRemove(int Id)
        {
            var set = Context.Set<TEntity>();
            var finded = await set.FindAsync(Id).ConfigureAwait(false);
            var result = finded is not null;
            if (result)
            {
                set.Remove(finded!);
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
            return result;
        }

        public async Task Update(TEntity item)
        {
            Context.Set<TEntity>().Update(item);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
