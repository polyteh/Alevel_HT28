using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Jew.Models
{
    public class PLProduct
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public decimal Price { get; internal set; }
        public int JewTypeId { get; set; }
        public virtual PLJewType JewType { get; set; }
        public virtual ICollection<PLGemstone> Gemstone { get; set; }
    }
}
