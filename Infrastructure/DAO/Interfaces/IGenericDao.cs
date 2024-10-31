using Core.Entities.Base;
using System.Linq.Expressions;

namespace Infrastructure.DAO.Interfaces
{
    public interface IGenericDao<T> where T : BaseEntity
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity, bool isHardDelete = false);

        void Delete(Expression<Func<T, bool>> condition, bool isHardDelete = false);

        IQueryable<T> GetQuery();

        IQueryable<T> GetQueryById(Guid Id);

        Task<T> GetByIdAsync(Guid Id);

        IQueryable<T> GetQuery(Expression<Func<T, bool>> condition);
    }
}