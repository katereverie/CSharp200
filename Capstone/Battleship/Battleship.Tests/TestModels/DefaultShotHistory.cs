using Battleship.BLL;

namespace Battleship.Tests.TestModels
{
    public class DefaultShotHistory
    {
        public List<Coordinate> Shots { get; set; } = new List<Coordinate>();

        public DefaultShotHistory()
        {
            // (A1, B2, C3, D4 ... J10)
            for (int i = 0; i < 10; i++)
            {
                Shots.Add(new Coordinate(1 + i, 1 + i));
            }
        }
    }
}