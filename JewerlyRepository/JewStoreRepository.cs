using JewerlyRepository.Interfaces;
using JewerlyRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace JewerlyRepository
{
    public class JewStoreRepository : IJewStoreRepository
    {
        private JewStoreContext _curJewStoreContext;
        public JewStoreRepository()
        {
            _curJewStoreContext = new JewStoreContext();
        }
        public void Add(Product newProduct)
        {
            _curJewStoreContext.Products.Add(newProduct);
            _curJewStoreContext.SaveChanges();
            return;
        }
        private bool disposed = false;
        //copy this part from metanit
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _curJewStoreContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public IEnumerable<Product> GetByGemsPresence(bool isHaveGems)
        {
            if (isHaveGems == true)
            {
                var productList = _curJewStoreContext.Products.Include(product => product.JewType).Include(product => product.Gemstone).Where(x => x.Gemstone.Count > 0).ToList();
                return productList;
            }
            else
            {
                var productList = _curJewStoreContext.Products.Include(product => product.JewType).Include(product => product.Gemstone).Where(x => x.Gemstone.Count == 0).ToList();
                return productList;
            }
        }

        public Product GetById(int id)
        {
            //i dont know which properties we need to show, so i transfer all data
            var searchProductById = _curJewStoreContext.Products.Include(product => product.JewType).Include(product => product.Gemstone).Where(x => x.Id == id).FirstOrDefault();
            return searchProductById;
        }

        public IEnumerable<Product> GetByType(JewType type)
        {
            var productByType = _curJewStoreContext.Products.Include(product => product.JewType).Include(product => product.Gemstone).Where(x => x.JewType.Name == type.Name).ToList();
            return productByType;
        }
        public JewType SearchByJewType(JewType curType)
        {

            var jewType = _curJewStoreContext.JewTypes.Where(x => x.Name == curType.Name).FirstOrDefault();
            return jewType;
        }
    }
}
