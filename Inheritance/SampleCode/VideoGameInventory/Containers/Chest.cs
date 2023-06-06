using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameInventory.Containers
{
    public class Chest : InventoryBase
    {
        public Chest() : base(5)
        {

        }

        public Chest(int capacity) : base(capacity)
        {

        }
    }
}
