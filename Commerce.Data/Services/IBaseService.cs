using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Data.Services
{
    public interface IBaseService<T>
    {
        Task<T> Create(T category);
        Task<T> Get(string id);
        Task<List<T>> GetAll();
        Task Remove(T categoryOut);
        Task Remove(string id);
        Task Update(string id, T categoryIn);
    }
}
