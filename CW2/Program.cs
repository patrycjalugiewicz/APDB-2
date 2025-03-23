
using CW2;

Container container = new Container("N",1000);
Container container1 = new Container("N",1000);
LiquidContainer liquidContainer = new LiquidContainer(10000, true);
GasContainer gasContainer = new GasContainer(1000, 1000);
RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(1000, "Jajka", 20);

container.Load(500);
liquidContainer.Load(600);

Ship ship = new Ship("Statek",10, 100000, 200);
ship.LoadContainer(container);
List<Container> containers = new List<Container>();
containers.Add(container1);
containers.Add(liquidContainer);
containers.Add(gasContainer);
containers.Add(refrigeratedContainer);
ship.LoadContainers(containers);
ship.RemoveContainer(liquidContainer.SerialNumber);
ship.ReplaceContainer(gasContainer.SerialNumber, liquidContainer);
Ship ship2 = new Ship("Statek2",10, 100000, 200);
ship.TransferContainer(refrigeratedContainer.SerialNumber, ship2);

//.WriteLine(container);
//.WriteLine(gasContainer);
//Console.WriteLine(liquidContainer);
//Console.WriteLine(refrigeratedContainer);
ship.PrintInfo();
ship2.PrintInfo();