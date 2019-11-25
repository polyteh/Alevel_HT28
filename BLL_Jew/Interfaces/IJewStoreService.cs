using BLL_Jew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Jew.Interfaces
{
    public interface IJewStoreService
    {
        void Add(BLLProduct newProduct);
        BLLProduct GetById(int id);
        IEnumerable<BLLProduct> GetByType(BLLJewType type);
        IEnumerable<BLLProduct> GetByGemsPresence(bool isHaveGems);
    }
}
