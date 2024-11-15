using BusinessObject.Models;
using BusinessObject.RequestModel;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IStepService
    {
        Task<Step> GetById(int id);
        Task<Step> UpdateAsync(Step step);
    }
}
