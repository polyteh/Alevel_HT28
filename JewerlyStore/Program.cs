using PL_Jew;
using PL_Jew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyStore
{
    class Program
    {
        static void Main(string[] args)
        {
            JewWorker myJewWorker = new JewWorker();

            int productId = 9;
            var productById = myJewWorker.GetById(productId);


            PLGemstone amethyst = new PLGemstone() { Name = "Amethyst", Size = 2, Colour = "Red", Price = 55 };
            PLGemstone bigDiamond = new PLGemstone() { Name = "Diamond", Size = 7, Colour = "Sky Blue", Price = 250 };
            PLGemstone greatEmerald = new PLGemstone() { Name = "Emerald", Size = 5, Colour = "Dark Green", Price = 220 };
            PLGemstone smallSapphire = new PLGemstone() { Name = "Sapphire", Size = 1, Colour = "Blue", Price = 10 };

            //add ring with N sapphire (can test >10)
            PLJewType ringType = new PLJewType() { Name = "Ring" };
            List<PLGemstone> smallSapphireCollection = new List<PLGemstone>();
            int sapphireCollectionSize = 9;
            for (int i = 0; i < sapphireCollectionSize; i++)
            {
                smallSapphireCollection.Add(smallSapphire);
            }
            //  myJewWorker.Add(new PLProduct() { Name=$"Ring with {sapphireCollectionSize} sapphires", JewType=ringType,Gemstone=smallSapphireCollection});

            //add new jew type (can change name for Bracelet)
            PLJewType amuletType = new PLJewType() { Name = "Amulet" };
            List<PLGemstone> oneAmethystCollection = new List<PLGemstone>();
            oneAmethystCollection.Add(amethyst);
            // myJewWorker.Add(new PLProduct() { Name = $"Amulet with amethyst", JewType = amuletType, Gemstone = oneAmethystCollection });

            //add ring without gems
            //myJewWorker.Add(new PLProduct() { Name = $"Ring without gems", JewType = ringType });

            bool isHaveGems = false;
            var productsWihoutGems = myJewWorker.GetByGemsPresence(isHaveGems);
            if (productsWihoutGems != null)
            {
                Console.WriteLine(isHaveGems == false ? "Products with no gems" : "Products with gems");
                foreach (var item in productsWihoutGems)
                {
                    Console.WriteLine($"Product {item.Name}, type {item.JewType.Name}");
                }
            }
            else
            {
                Console.WriteLine("No product without gems");
            }

            //get items by type
            //PLJewType typeToGet = amuletType;
            PLJewType typeToGet = ringType;
            var allItems = myJewWorker.GetByType(typeToGet);
            Console.WriteLine($"We have {allItems.Count()} {typeToGet.Name} in the store");

            Console.WriteLine("All tasks have been done");
            Console.ReadKey();
        }
    }
}
