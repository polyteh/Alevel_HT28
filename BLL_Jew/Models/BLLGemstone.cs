using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Jew.Models
{
    public class BLLGemstone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public virtual BLLProduct Product { get; set; }
    }
}
