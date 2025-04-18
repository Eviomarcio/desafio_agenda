namespace Agenda.Infrastructure.Persistence.Persistence.Interface
{
    public interface IRepositotyGeneric<T> where T : class
    {
        Task<T> Add(T objector);
        Task<T> Update(T objector);
        Task Delete(T objector);
        Task<T> GetEntityById(int id);
        Task<List<T>> ListAll();
    }
}