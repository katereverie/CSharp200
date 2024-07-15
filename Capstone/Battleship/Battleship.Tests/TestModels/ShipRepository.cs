using Battleship.Tests.TestModels.DefaultShips;
using Battleship.BLL;

namespace Battleship.Tests.TestModels
{
    public class ShipRepository
    {
        public Ship[] Ships { get; private set; } = new Ship[5];

        public ShipRepository()
        {
            Ships[0] = new DefaultAircraftCarrier();
            Ships[1] = new DefaultBattleShip();
            Ships[2] = new DefaultCruiser();
            Ships[3] = new DefaultSubmarine();
            Ships[4] = new DefaultDestroyer();
        }
    }
}