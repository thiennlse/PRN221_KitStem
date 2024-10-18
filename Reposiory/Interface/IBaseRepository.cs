using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task Add (T entity);

        Task Remove (int id);

        Task Update (T entity);

        IQueryable<T> GetQueryable(CancellationToken cancellationToken = default);

        void CheckCancellationToken(CancellationToken cancellationToken = default);

    }
}
