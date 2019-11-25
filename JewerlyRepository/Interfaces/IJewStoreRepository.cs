using JewerlyRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyRepository.Interfaces
{
    public interface IJewStoreRepository : IDisposable 
    {
        void Add(Product newProduct);
        Product GetById(int id);
        IEnumerable<Product> GetByType(JewType type);
        IEnumerable<Product> GetByGemsPresence(bool isHaveGems);
    }
}
