using Battleship.BLL;
using Battleship.BLL.Ships;


namespace Battleship.Tests.TestModels.DefaultShips
{
    public class DefaultCruiser : Cruiser
    {
        public DefaultCruiser()
        {
            Coordinate startCoord = new Coordinate(3, 1); // D1
            base.SetCoordinates(startCoord, 'V');
        }
    }
}
