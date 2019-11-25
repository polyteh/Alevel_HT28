using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Jew.Models
{
    public class PLGemstone
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public virtual PLProduct Product { get; set; }
    }
}
