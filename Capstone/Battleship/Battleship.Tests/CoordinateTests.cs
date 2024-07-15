using Battleship.BLL;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class CoordinateTests
    {
        [Test]
        public void Equality()
        {
            Coordinate c1 = new Coordinate(1, 1);
            Coordinate c2 = new Coordinate(1, 1);

            Assert.That(c1.Equals(c2), Is.True);
        }

        [Test]
        public void CoordinateToString()
        {
            Coordinate c1 = new Coordinate(1, 1);
            Coordinate c2 = new Coordinate(2, 2);
            string result1 = c1.ToString();
            string result2 = c2.ToString();

            Assert.That(result1, Is.EqualTo("A1"));
            Assert.That(result2, Is.EqualTo("B2"));
        }

        [Test]
        public void StringToCoordinate()
        {
            var result1 = Coordinate.ToCoordinate("A1");
            var result2 = Coordinate.ToCoordinate("J10");

            Assert.That(result1, Is.EqualTo(new Coordinate(1, 1)));
            Assert.That(result2, Is.EqualTo(new Coordinate(10, 10)));
        }

        [Test]
        public void CoordinateToBoardIndex()
        {
            var result1 = Coordinate.ToBoardIndex(new Coordinate(1, 1));
            var result2 = Coordinate.ToBoardIndex(new Coordinate(1, 2));
            var result3 = Coordinate.ToBoardIndex(new Coordinate(10, 1)); 

            Assert.That(result1, Is.EqualTo(0));
            Assert.That(result2, Is.EqualTo(10));
            Assert.That(result3, Is.EqualTo(9));
        }
    }
}
