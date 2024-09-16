public class Weapon
{
    //fields
    public int ID;
    public string Name;
    public int Damage;

    // constructor
    public Weapon(int id, string name, int damage)
    {
        this.ID = id;
        this.Name = name;
        this.Damage = damage;
    }

    // methods
    public string Info()
    {
        return $"Name: {this.Name}, Damage:{this.Damage}";
    }
}