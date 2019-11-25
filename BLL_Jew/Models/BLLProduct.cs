using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Jew.Models
{
    public class BLLProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int JewTypeId { get; set; }
        public virtual BLLJewType JewType { get; set; }
        public virtual ICollection<BLLGemstone> Gemstone { get; set; }
    }
}
