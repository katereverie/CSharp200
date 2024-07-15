using Battleship.Tests.TestModels.DefaultShips;
using Battleship.BLL;

namespace Battleship.Tests.TestModels
{
    public class DefaultShipRepository
    {
        public List<Ship> Ships { get; private set; } = new List<Ship>(5);

        public DefaultShipRepository()
        {
            Ships.Add(new DefaultAircraftCarrier());
            Ships.Add(new DefaultBattleShip());
            Ships.Add(new DefaultCruiser());
            Ships.Add(new DefaultSubmarine());
            Ships.Add(new DefaultDestroyer());
        }
    }
}