using Battleship.UI;
using Battleship.UI.Models.Ships;

namespace Battleship.Tests.TestModels.DefaultShips
{
    public class DefaultAircraftCarrier : AircraftCarrier
    {
        public DefaultAircraftCarrier()
        {
            Coordinate startCoord = new Coordinate(1, 1); // A1
            base.SetCoordinates(startCoord, 'V');
        }
    }
}