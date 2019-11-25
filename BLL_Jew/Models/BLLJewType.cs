using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Jew.Models
{
    public class BLLJewType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BLLProduct> Product { get; set; }
    }
}
