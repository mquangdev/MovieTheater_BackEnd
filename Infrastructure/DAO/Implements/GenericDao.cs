using Core.Entities.Base;
using Infrastructure.DAO.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.DAO.Implements
{
    public class GenericDao<T> : IGenericDao<T> where T : BaseEntity
    {
        protected readonly MovieTheaterContext _context;
        private readonly IUserIdentity _userIdentity;
        protected DbSet<T> DbSet;
        protected Guid UserId => _userIdentity.UserId;
        public GenericDao(MovieTheaterContext context, IUserIdentity userIdentity)
        {
            _context = context;
            _userIdentity = userIdentity;
            DbSet = _context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            entity.InsertedById = UserId;
            entity.InsertedAt = DateTime.Now;
            DbSet.Add(entity);
            return entity;
        }

        public virtual void Delete(T entity, bool isHardDelete = false)
        {
            if (isHardDelete)
            {
                DbSet.Remove(entity);
            }
            else
            {
                entity.IsDeleted = true;
                Update(entity);
            }
        }

        public virtual async void Delete(Expression<Func<T, bool>> condition, bool isHardDelete = false)
        {
            var entities = await GetQuery(condition).ToListAsync();
            foreach (var entity in entities)
            {
                Delete(entity, isHardDelete);
            }
        }

        public virtual async Task<T> GetByIdAsync(Guid Id)
        {
            return await GetQuery(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> GetQuery()
        {
            return DbSet;
        }

        public virtual IQueryable<T> GetQuery(Expression<Func<T, bool>> condition)
        {
            return DbSet.Where(condition);
        }

        public virtual IQueryable<T> GetQueryById(Guid Id)
        {
            return GetQuery(x => x.Id == Id);
        }

        public T Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedById = UserId;
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}