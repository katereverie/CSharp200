using Battleship.UI;
using Battleship.UI.Models.Ships;

namespace Battleship.Tests.TestModels.DefaultShips
{
    public class DefaultSubmarine : Submarine
    {
        public DefaultSubmarine()
        {
            Coordinate startCoord = new Coordinate(4, 1); // D1
            base.SetCoordinates(startCoord, 'V');
        }
    }
}
