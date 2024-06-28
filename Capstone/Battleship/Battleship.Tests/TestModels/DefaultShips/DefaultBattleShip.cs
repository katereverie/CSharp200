using Battleship.UI.Models.Ships;
using Battleship.UI;

namespace Battleship.Tests.TestModels.DefaultShips
{
    public class DefaultBattleShip : BattleShip
    {
        public DefaultBattleShip()
        {
            Coordinate startCoord = new Coordinate(2, 1); // B1
            base.SetCoordinates(startCoord, 'V');
        } 
    }
}
