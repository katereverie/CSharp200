using Battleship.UI.Interfaces;
using Battleship.UI.Models.Ships;
using Battleship.UI.Utilities;
using Battleship.UI.Workflows;

Console.WriteLine("Welcome to Battleship where only the best Captain survives!\n");

IPlayer p1;
IPlayer p2;

// Player Selection
while (true)
{
    ConsoleIO.PrintPlayerSelectionRules();

    p1 = PlayerFactory.GetPlayer("First player - (H)uman or (C)omputer? Your choice: ");
    p2 = PlayerFactory.GetPlayer("Second player - (H)uman or (C)omputer? Your choice: ");

    if (!p1.IsHuman && !p2.IsHuman)
    {
        ConsoleIO.PrintErrorMessage("At least one player must be human.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        continue;
    }

    break;
}

App app = new App(p1, p2);

// Setup Games
Console.Clear();

app.SetUpGame(p1, new AircraftCarrier());
app.SetUpGame(p1, new BattleShip());
app.SetUpGame(p1, new Cruiser());
app.SetUpGame(p1, new Submarine());
app.SetUpGame(p1, new Destroyer());

app.SetUpGame(p2, new AircraftCarrier());
app.SetUpGame(p2, new BattleShip());
app.SetUpGame(p2, new Cruiser());
app.SetUpGame(p2, new Submarine());
app.SetUpGame(p2, new Destroyer());

// Game Begins
app.RunGame();