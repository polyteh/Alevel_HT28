using BLL_Jew;
using BLL_Jew.Models;
using PL_Jew.Interfaces;
using PL_Jew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Jew
{
    public class JewWorker : IJewStoreWorker
    {
        JewService _jewService;
        public JewWorker()
        {
            _jewService = new JewService();
        }
        public void Add(PLProduct newProduct)
        {
            if (IsTypeNull(newProduct))
            {
                Console.WriteLine("You need define product type");
                return;
            }
            BLLProduct productToAdd = PLProductToBLLProduct(newProduct);
            _jewService.Add(productToAdd);
        }
        public IEnumerable<PLProduct> GetByGemsPresence(bool isHaveGems)
        {
            var productBLLByGemsPresents = _jewService.GetByGemsPresence(isHaveGems);
            if (productBLLByGemsPresents != null)
            {
                List<PLProduct> productPLByGemsPresents = new List<PLProduct>();
                foreach (var item in productBLLByGemsPresents)
                {
                    productPLByGemsPresents.Add(BLLProductToPLProduct(item));
                }
                return productPLByGemsPresents;
            }
            return null;
        }
        public PLProduct GetById(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Id should be positive");
                return null;
            }
            BLLProduct bllProductById = _jewService.GetById(id);
            if (bllProductById != null)
            {
                PLProduct plProductById = BLLProductToPLProduct(bllProductById);
                return plProductById;
            }
            Console.WriteLine($"No product with id={id}");
            return null;
        }
        public IEnumerable<PLProduct> GetByType(PLJewType jewType)
        {
            if (jewType == null)
            {
                Console.WriteLine("Cant define type");
                return null;
            }
            BLLJewType typeToDefine = PLJewTypeToBLLJewType(jewType);
            var bllProductByType = _jewService.GetByType(typeToDefine);
            if (bllProductByType != null)
            {
                List<PLProduct> plProductByType = new List<PLProduct>();
                foreach (var item in bllProductByType)
                {
                    plProductByType.Add(BLLProductToPLProduct(item));
                }
                return plProductByType;
            }
            return null;
        }
        /// <summary>
        /// check for null
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        private bool IsTypeNull(PLProduct newProduct)
        {
            if (newProduct.JewType == null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// map item from presentation layer to business layer
        /// </summary>
        /// <param name="itemToMap"></param>
        /// <returns></returns>
        private BLLProduct PLProductToBLLProduct(PLProduct itemToMap)
        {
            BLLJewType mapJewType = new BLLJewType() { Name = itemToMap.JewType.Name };
            List<BLLGemstone> mapGemstones = new List<BLLGemstone>();
            //send information about price of each gemstone
            if (itemToMap.Gemstone != null)
            {
                foreach (var gem in itemToMap.Gemstone)
                {
                    mapGemstones.Add(new BLLGemstone() { Name = gem.Name, Size = gem.Size, Colour = gem.Colour, Price = gem.Price });
                }
            }
            // no information about product price
            BLLProduct bllProduct = new BLLProduct()
            {
                Name = itemToMap.Name,
                JewTypeId = itemToMap.JewTypeId,
                JewType = mapJewType,
                Gemstone = mapGemstones
            };
            //i dont know: shoul I for each BLLGemstone assign bllProduct as product?
            return bllProduct;
        }/// <summary>
        /// map product from business layer to presentation layer
        /// </summary>
        /// <param name="itemToMap"></param>
        /// <returns></returns>
        private PLProduct BLLProductToPLProduct(BLLProduct itemToMap)
        {
            PLJewType mapJewType = new PLJewType() { Name = itemToMap.JewType.Name };
            List<PLGemstone> mapGemstones = new List<PLGemstone>();
            if (itemToMap.Gemstone != null)
            {
                foreach (var gem in itemToMap.Gemstone)
                {
                    mapGemstones.Add(new PLGemstone() { Name = gem.Name, Size = gem.Size, Colour = gem.Colour });
                }
            }
            //product price from DB is mapped here
            PLProduct plProduct = new PLProduct()
            {
                Name = itemToMap.Name,
                Price = itemToMap.Price,
                JewTypeId = itemToMap.JewTypeId,
                JewType = mapJewType,
                Gemstone = mapGemstones
            };
            return plProduct;
        }
        /// <summary>
        /// map jewerly type from presentation level to business level
        /// </summary>
        /// <param name="itemToMap"></param>
        /// <returns></returns>
        private BLLJewType PLJewTypeToBLLJewType(PLJewType itemToMap)
        {
            BLLJewType mapJewType = new BLLJewType() { Name = itemToMap.Name };
            return mapJewType;
        }
    }
}
