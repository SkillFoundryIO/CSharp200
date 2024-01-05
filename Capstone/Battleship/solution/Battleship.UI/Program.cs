using Battleship.UI.Actions;
using Battleship.UI.Interfaces;
using Battleship.UI.Workflows;

IPlayer p1 = PlayerFactory.GetPlayer(1);
IPlayer p2 = PlayerFactory.GetPlayer(2);

App app = new App(p1, p2);
app.Run();