namespace CW2;

public class LiquidContainer: Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }
    
    public LiquidContainer(double maxLoad, bool isHazardous) : base("L",maxLoad)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        double LoadLimit = IsHazardous ? MaxLoad *0.5 : MaxLoad * 0.9;
        if (CurrentLoad + weight > LoadLimit)
        {
            Notify("Przekroczono limit wagowy ładunku dla kontenera z numerem seryjnym");
        }
    }
    public void Notify(string msg)
    {
        Console.WriteLine($"Ostrzeżnenie! {msg} - {SerialNumber}.");
    }
    
    public override string ToString()
    {
        return  $"Kontener na płyny  | Numer seryjny: {SerialNumber} | Ładunek niebezpieczny: {IsHazardous}.";
    }
}