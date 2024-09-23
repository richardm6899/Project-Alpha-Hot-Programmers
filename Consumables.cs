public class Consumable
{
    public string Name;

    public int ID;

    public int Strength;

    public string Usage;
    public int Price;

    public Consumable(int id, string name, int strength, string usage,int price)
    {
        this.ID = id;
        this.Name = name;
        this.Strength = strength;
        this.Usage = usage;
        Price = price;
        
    }


}