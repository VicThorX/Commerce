using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Data.Services
{
    public interface IBaseService<T>
    {
        Task<T> Create(T entity);
        Task<T> Get(string id);
        Task<List<T>> GetAll();
        Task Remove(T entityOut);
        Task Remove(string id);
        Task Update(string id, T entityIn);
    }
}
