using System.Linq.Expressions;

namespace Agenda.Infrastructure.Persistence.Interface
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<T> Add(T objector);
        Task<T> Update(T objector);
        Task<bool> Delete(T objector);
        Task<T> GetEntityById(int id);
        Task<List<T>> ListAll();
        Task<List<T>> Get(Expression<Func<T, bool>> where);
    }
}