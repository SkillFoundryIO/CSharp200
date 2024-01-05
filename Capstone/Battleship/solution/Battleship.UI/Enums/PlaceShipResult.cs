using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.UI.Enums
{
    public enum PlaceShipResult
    {
        Success,
        ShipOffBoard,
        ShipOverlap,
        Error         // shouldn't ever hit this
    }
}
