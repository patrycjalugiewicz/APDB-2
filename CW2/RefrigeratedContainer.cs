namespace CW2;

public class RefrigeratedContainer:Container
{
    public double Temperature { get; private set; }
    public string ProductType { get; private set; }
    private static readonly Dictionary<string, double> RequiredTemperatures = new Dictionary<string, double>
    {
        { "Banany", 13.3 },
        {"Czekolada", 18.0},
        { "Ryby", -2.0 },
        {"Mięso", -15.0},
        {"Lody", -18},
        {"Pizza mrożona", -30},
        {"Ser", 7.2},
        {"Kiełbaski", 5.0},
        {"Masło", 20.5},
        {"Jajka", 19.0}
       
    };
    
    public RefrigeratedContainer(double maxLoad, string productType, double temperature) : base("R", maxLoad)
    {
        if (!RequiredTemperatures.ContainsKey(productType))
            throw new ArgumentException("Nieobsługiwany typ produktu.");
        Temperature = temperature;
        if (RequiredTemperatures.ContainsKey(productType) && Temperature < RequiredTemperatures[productType])
        {
            throw new Exception($"Zbyt niska temperatura dla {productType}.");
        }
        
        ProductType = productType;
        Temperature = RequiredTemperatures[productType];
    }
    
    public override void Load(double weight)
    {
        if (ProductType == null)
            throw new Exception("Nie można załadować nieznanego produktu.");
        
        base.Load(weight);
    }
    
    public void Load(double weight, string productType)
    {
        if (productType != ProductType)
            throw new Exception($"Nie można załadować produktu {productType} do kontenera przeznaczonego na {ProductType}.");
        
        Load(weight);
    }
    
    public override string ToString()
    {
        return  $"Kontener Chłodniczy | Numer seryjny: {SerialNumber} | Produkt: {ProductType} | Temperatura: {Temperature}°C.";
    }
}
    
