
using Customer.Helpers.Interfaces;

namespace Customer.Helpers.Interfaces { }

public interface IBaseService<T> where T : class
{
    Task<IEnumerable<T>> GetAll();

    Task<T> Get(int id);

    Task<T> Get(Guid id);

    Task<bool> Create(T entity);

    Task<bool> Update(T entity);

    Task<bool> Delete(int id);
}

