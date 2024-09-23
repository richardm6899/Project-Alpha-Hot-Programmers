public class Weapon
{
    //fields
    public int ID;
    public string Name;
    public int Damage;
    public int Price;

    // constructor
    public Weapon(int id, string name, int damage, int price)
    {
        this.ID = id;
        this.Name = name;
        this.Damage = damage;
        Price = price;
    }

    // methods
    public string Info()
    {
        return $"Name: {this.Name}, Damage:{this.Damage}";
    }
}