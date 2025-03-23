namespace CW2;

public class Ship
{
    public string Name { get; private set; }
    public int MaxContainers { get; private set; }
    public double MaxWeight { get; private set; }
    public double MaxSpeed { get; set; }
    public List<Container> Containers { get; private set; }
    
    public Ship(string name, int maxContainers, double maxWeight, double maxSpeed)
    {
        Name = name;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        MaxSpeed = maxSpeed;
        Containers = new List<Container>();
    }
    
    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers || GetTotalWeight() + container.MaxLoad > MaxWeight)
            throw new Exception("Nie można załadować kontenera - przekroczone limity statku.");
        
        Containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)    
        {
            LoadContainer(container);
        }
    }
    
    public void UnloadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            container.Unload();
        }
    }
    
    public void RemoveContainer(string serialNumber)
    {
        Containers.RemoveAll(c => c.SerialNumber == serialNumber);
    }
    
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        RemoveContainer(serialNumber);
        LoadContainer(newContainer);
    }
    
    public void TransferContainer(string serialNumber, Ship targetShip)
    {
        Container container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            targetShip.LoadContainer(container);
        }
        else
        {
            throw new Exception("Kontener o podanym numerze seryjnym nie istnieje.");
        }
    }
    
    public double GetTotalWeight()
    {
        double totalWeight = 0;
        foreach (var container in Containers)
            totalWeight += container.MaxLoad;
        return totalWeight;
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"Statek: {Name} | Maksymalna liczba kontenerów: {MaxContainers} | Obecna liczba kontenerów: {Containers.Count} | Maksymalna waga: {MaxWeight} ton");
        Console.WriteLine("Kontenery na pokładzie:");
        foreach (var container in Containers)
            Console.WriteLine(container);
    }
}