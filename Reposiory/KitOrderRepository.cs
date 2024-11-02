using BusinessObject.Models;
using Reposiory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory
{
    public class KitOrderRepository : BaseRepository<KitOrder>, IKitOrderRepository
    {
        public KitOrderRepository(KitStemDBContext dbContext) : base(dbContext)
        {

        }
    }
}
