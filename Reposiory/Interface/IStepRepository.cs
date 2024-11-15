using BusinessObject.Models;
using BusinessObject.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Reposiory.Interface
{
    public interface IStepRepository : IBaseRepository<Step>
    {
        Task<Step> UpdateAsync(Step step);
    }
}
