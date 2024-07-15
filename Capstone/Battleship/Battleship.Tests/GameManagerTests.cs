using NUnit.Framework;
using Battleship.BLL;
using Battleship.BLL.Ships;
using Battleship.Tests.TestModels.DefaultShips;
using Battleship.Tests.TestModels;

namespace Battleship.Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        private GameManager _mgr = new GameManager();

        [Test]
        public void TestShipPlacement_Offgrid()
        {
            var startCoord1 = new Coordinate(1, 8); // A8
            var startCoord2 = new Coordinate(6, 8); // F8
            var startCoord3 = new Coordinate(5, 5); // E5

            var result1 = _mgr.CheckOffgridShip(startCoord1, 5, 'V');
            var result2 = _mgr.CheckOffgridShip(startCoord2, 6, 'H');
            var result3 = _mgr.CheckOffgridShip(startCoord3, 6, 'V');
            var result4 = _mgr.CheckOffgridShip(startCoord3, 6, 'H');

            Assert.That(result1, Is.EqualTo(PlacementResult.Offgrid));
            Assert.That(result2, Is.EqualTo(PlacementResult.Offgrid));
            Assert.That(result3, Is.EqualTo(PlacementResult.Placed));
            Assert.That(result4, Is.EqualTo(PlacementResult.Placed));
        }

        [Test]
        public void TestShipPlacement_Overlap()
        {
            var ship1 = new BattleShip();
            var ship2 = new DefaultBattleShip();

            var startCoord = new Coordinate(1, 6); // A6

            var repo = new DefaultShipRepository();
            ship1.SetCoordinates(startCoord, 'H');

            var result1 = _mgr.CheckOverlapShip(ship1, repo.Ships);
            var result2 = _mgr.CheckOverlapShip(ship2, repo.Ships);

            Assert.That(result1, Is.EqualTo(PlacementResult.Added));
            Assert.That(result2, Is.EqualTo(PlacementResult.Overlap));
        }

        [Test]
        public void TestShotPlacement_Overlap()
        {

            var shot1 = new Coordinate(1, 1); // A1
            var shot2 = new Coordinate(1, 2); // A2

            var repo = new DefaultShotHistory(); 

            var result1 = _mgr.CheckOverlapShot(shot1, repo.Shots);
            var result2 = _mgr.CheckOverlapShot(shot2, repo.Shots);

            Assert.That(result1, Is.EqualTo(PlacementResult.Overlap));
            Assert.That(result2, Is.EqualTo(PlacementResult.Placed));

        }

        [Test]
        public void TestShotPlacement_Miss()
        {
            var shot1 = new Coordinate(1, 6); // A6
            var shot2 = new Coordinate(2, 5); // B5
            var shot3 = new Coordinate(3, 4); // C4

            var repo = new DefaultShipRepository();

            var result1 = _mgr.EvaluateValidShot(shot1, repo.Ships);
            var result2 = _mgr.EvaluateValidShot(shot2, repo.Ships);
            var result3 = _mgr.EvaluateValidShot(shot3, repo.Ships);

            bool allMiss = result1 == ShotResult.Miss && result1 == result2 && result2 == result3 ? true : false;

            Assert.That(allMiss, Is.True);
        }

        [Test]
        public void TestShotPlacement_HitButNotSunk()
        {
            var shot1 = new Coordinate(1, 1); // A1
            var shot2 = new Coordinate(2, 1); // B1
            var shot3 = new Coordinate(3, 1); // C1

            var repo = new DefaultShipRepository();

            var result1 = _mgr.EvaluateValidShot(shot1, repo.Ships);
            var result2 = _mgr.EvaluateValidShot(shot2, repo.Ships);
            var result3 = _mgr.EvaluateValidShot(shot3, repo.Ships);

            bool allHit = result1 == ShotResult.Hit && result1 == result2 && result2 == result3? true : false;

            Assert.That(allHit, Is.True);
        }

        public void TestShotPlacement_HitAndSunk()
        {
            var shot1 = new Coordinate(2, 1); //B1
            var shot2 = new Coordinate(1, 1); //A1

            var repo = new DefaultShipRepository();

            repo.Ships[0].CountHit();
            repo.Ships[0].CountHit();
            repo.Ships[0].CountHit();
            repo.Ships[0].CountHit();

            var result1 = _mgr.EvaluateValidShot(shot1, repo.Ships);
            var result2 = _mgr.EvaluateValidShot(shot2 , repo.Ships);

            Assert.That(result1, Is.EqualTo(ShotResult.Hit));
            Assert.That(result2, Is.EqualTo(ShotResult.Sunk));
        }

        [Test]
        public void TestCalculation_RemainingShips()
        {
            var repo = new DefaultShipRepository();

            var shot1 = new Coordinate(1, 1); // A1
            var shot2 = new Coordinate(1, 2); // A2
            var shot3 = new Coordinate(1, 3);
            var shot4 = new Coordinate(1, 4);
            var shot5 = new Coordinate(1, 5);

            _mgr.EvaluateValidShot(shot1, repo.Ships);
            _mgr.EvaluateValidShot(shot2, repo.Ships);
            _mgr.EvaluateValidShot(shot3, repo.Ships);
            _mgr.EvaluateValidShot(shot4, repo.Ships);

            var calResult1 = _mgr.CalculateRemainingShips(repo.Ships);

            _mgr.EvaluateValidShot(shot5 , repo.Ships);

            var calResult2 = _mgr.CalculateRemainingShips(repo.Ships);

            Assert.That(calResult1, Is.EqualTo(5));
            Assert.That(calResult2, Is.EqualTo(4));
        }

        [Test] 
        public void TestCalculation_RemainingHits()
        {
            var repo = new DefaultShipRepository(); // 17

            var calResult1 = _mgr.CalculateRemainingHits(repo.Ships);

            var shot1 = new Coordinate(1, 1);
            var shot2 = new Coordinate(1, 2);

            _mgr.EvaluateValidShot(shot1 , repo.Ships);
            _mgr.EvaluateValidShot(shot2 , repo.Ships);

            var calResult2 = _mgr.CalculateRemainingHits(repo.Ships);

            Assert.That(calResult1 , Is.EqualTo(17));
            Assert.That(calResult2 , Is.EqualTo(15));
        }
    }
}