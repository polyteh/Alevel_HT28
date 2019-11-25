using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Jew.Models
{
    public class PLJewType
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public virtual ICollection<PLProduct> Product { get; set; }
    }
}
