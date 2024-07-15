using Battleship.BLL;
using Battleship.BLL.Ships;

namespace Battleship.Tests.TestModels.DefaultShips
{
    public class DefaultDestroyer : Destroyer
    {
        public DefaultDestroyer()
        {
            Coordinate startCoord = new Coordinate(5, 1); // E1
            base.SetCoordinates(startCoord, 'V');
        }
    }
}
