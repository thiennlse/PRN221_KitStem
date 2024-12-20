﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory.Interface
{
    public interface IKitOrderRepository : IBaseRepository<KitOrder>
    {
        Task<List<KitOrder>> GetAllAsync();
        Task<KitOrder> GetByIdAsync(int id);
    }
}
