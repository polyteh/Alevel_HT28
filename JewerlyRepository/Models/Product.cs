using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyRepository.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int JewTypeId { get; set; }
        public virtual JewType JewType { get; set; }
        public virtual ICollection<Gemstone> Gemstone { get; set; }
    }
}
