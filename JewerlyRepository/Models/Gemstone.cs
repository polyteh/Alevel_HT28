using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyRepository.Models
{
    public class Gemstone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
