using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finfast.Desafio.Infrastucture.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = _entities;

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public T Create(T entity)
        {
            _entities.Add(entity);

            _context.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            _entities.Update(entity);

            _context.SaveChanges();

            return entity;
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);

            _context.SaveChanges();
        }
    }
}
