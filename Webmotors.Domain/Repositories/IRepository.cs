namespace Webmotors.Domain.Repositories
{
    public interface IRepository<T> : IBaseRepository, IReadOnlyRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
