using AutoMapper;
using BLL_Jew.Interfaces;
using BLL_Jew.Models;
using JewerlyRepository;
using JewerlyRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Jew
{
    public class JewService : IJewStoreService
    {
        private JewStoreRepository _myJewStore;
        public JewService()
        {
            _myJewStore = new JewStoreRepository();
        }
        public void Add(BLLProduct newProduct)
        {
            int numberOfGems = newProduct.Gemstone.Count;
            //check jems number, error, if more than 10 gems in one product
            if (numberOfGems > 10)
            {
                Console.WriteLine($"Maximum 10 gems per product, but you have {numberOfGems}. Item add failed.");
                return;
            }
            Product itemToAdd = BLLProductToProduct(newProduct);
            //check if we have such type of product in DB, assign existing type
            JewType searchJewTypeInDB = _myJewStore.SearchByJewType(itemToAdd.JewType);
            if (searchJewTypeInDB != null)
            {
                itemToAdd.JewType = searchJewTypeInDB;
            }
            _myJewStore.Add(itemToAdd);
        }

        public IEnumerable<BLLProduct> GetByGemsPresence(bool isHaveGems)
        {
            IEnumerable<Product> itemsWithOrNoGems = _myJewStore.GetByGemsPresence(isHaveGems);
            List<BLLProduct> itemsToReturn = new List<BLLProduct>();
            if (itemsWithOrNoGems != null)
            {
                foreach (var item in itemsWithOrNoGems)
                {
                    itemsToReturn.Add(ProductToBLLProduct(item));
                }
                return itemsToReturn;
            }
            return null;
        }

        public BLLProduct GetById(int id)
        {
            Product getProductById = _myJewStore.GetById(id);
            if (getProductById != null)
            {
                BLLProduct bllProductId = ProductToBLLProduct(getProductById);
                return bllProductId;
            }
            return null;
        }

        public IEnumerable<BLLProduct> GetByType(BLLJewType type)
        {
            JewType searchForType = BLLJewTypeToJewType(type);
            JewType searchResultJewTypeInDB = _myJewStore.SearchByJewType(searchForType);
            if (searchResultJewTypeInDB != null)
            {
                var searchProductTypeInDB = _myJewStore.GetByType(searchResultJewTypeInDB);
                if (searchProductTypeInDB != null)
                {
                    List<BLLProduct> searchProductByType = new List<BLLProduct>();
                    foreach (var item in searchProductTypeInDB)
                    {
                        searchProductByType.Add(ProductToBLLProduct(item));
                    }
                    return searchProductByType;
                }
                else
                {
                    Console.WriteLine("No items of such type");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("This type diesnt exist in DB");
                return null;
            }
        }
        private BLLProduct ProductToBLLProduct(Product itemToMap)
        {

            BLLJewType mapJewType = new BLLJewType() { Id = itemToMap.JewType.Id, Name = itemToMap.JewType.Name };
            List<BLLGemstone> mapGemstones = new List<BLLGemstone>();
            if (itemToMap.Gemstone != null)
            {
                foreach (var gem in itemToMap.Gemstone)
                {
                    mapGemstones.Add(new BLLGemstone() { Id = gem.Id, Name = gem.Name, Size = gem.Size, Colour = gem.Colour });
                }
            }

            BLLProduct bllProduct = new BLLProduct()
            {
                Id = itemToMap.Id,
                Name = itemToMap.Name,
                Price = itemToMap.Price,
                JewTypeId = itemToMap.JewTypeId,
                JewType = mapJewType,
                Gemstone = mapGemstones
            };
            //i dont know: shoul I for each BLLGemstone assign bllProduct as product?
            return bllProduct;
        }
        private Product BLLProductToProduct(BLLProduct itemToMap)
        {
            JewType mapJewType = new JewType() { Name = itemToMap.JewType.Name };
            List<Gemstone> mapGemstones = new List<Gemstone>();
            if (itemToMap.Gemstone != null)
            {
                foreach (var gem in itemToMap.Gemstone)
                {
                    mapGemstones.Add(new Gemstone() { Name = gem.Name, Size = gem.Size, Colour = gem.Colour, Price = gem.Price });
                }
            }
            decimal productPrice = itemToMap.Gemstone.Sum(x => x.Price);
            Product product = new Product()
            {
                Name = itemToMap.Name,
                Price = productPrice,
                JewTypeId = itemToMap.JewTypeId,
                JewType = mapJewType,
                Gemstone = mapGemstones
            };
            return product;
        }
        private JewType BLLJewTypeToJewType(BLLJewType itemToMap)
        {
            JewType mapJewType = new JewType() { Id = itemToMap.Id, Name = itemToMap.Name };
            return mapJewType;
        }
    }
}
