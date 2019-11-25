using PL_Jew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Jew.Interfaces
{
    public interface IJewStoreWorker
    {
        void Add(PLProduct newProduct);
        PLProduct GetById(int id);
        IEnumerable<PLProduct> GetByType(PLJewType type);
        IEnumerable<PLProduct> GetByGemsPresence(bool isHaveGems);
    }
}
