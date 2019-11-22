using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyRepository
{
    public class JewStoreRepository
    {
        private JewStoreContext _curJewStoreContext;
        public JewStoreRepository()
        {
            _curJewStoreContext = new JewStoreContext();
        }
    }
}
