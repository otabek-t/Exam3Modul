namespace CarDataAccess.Entity;

public class Car
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double EngineCapasity { get; set; }
    public double Price { get; set; }
    public int MileAge { get; set; }
    public string Color { get; set; }
}
