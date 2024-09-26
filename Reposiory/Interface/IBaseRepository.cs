using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> getAll();

        Task<T> getById(int id);

        Task add(T entity);

        Task<T> update(T entity);

        Task deleteById(int id);

    }
}
