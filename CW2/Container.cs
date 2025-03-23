namespace CW2;

public class Container
{
    protected internal double MaxLoad {set;get;}
    double Height {set;get;}
    double Mass {set;get;}
    double Depth {set;get;}
    protected internal string SerialNumber {set;get;}
    protected double CurrentLoad {set;get;}
    private static int counter = 1; 
    private string Type {set;get;}

    public Container(string type, double maxLoad)
    {
        SerialNumber = $"KON-{type}-{counter++}";
        MaxLoad = maxLoad;
        CurrentLoad = 0;
        Type = type;
    }

    public virtual void Unload()
    {
        CurrentLoad = 0;
        
    }

    public virtual void Load(double weight)
    {
        if (CurrentLoad + weight > MaxLoad)
            throw new Exception("OverfillException: Przekroczona maksymalna ładowność kontenera.");
        CurrentLoad += weight;
    }
    
    public override string ToString()
    {
        return  $"Kontener | Numer seryjny: {SerialNumber}.";
    }


}