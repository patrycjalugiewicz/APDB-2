namespace CW2;

public class GasContainer: Container, IHazardNotifier

{
    double Pressure {set;get;}
    
    public GasContainer(double maxLoad, double pressure) : base("G", maxLoad)
    {
        Pressure = pressure;
        
    }

    public override void Unload()
    {
        CurrentLoad *= 0.05;
    }


    public void Notify(string msg)
    {
        Console.WriteLine($"Ostrzeżnenie! {msg} - {SerialNumber}.");
    }
    
    public override string ToString()
    {
        return  $"Kontener na gaz | Numer seryjny: {SerialNumber} | Ciśnienie: {Pressure}.";
    }
}