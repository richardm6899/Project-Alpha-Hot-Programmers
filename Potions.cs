public class Potion
{
    public string Name;

    public int ID;

    public int Strength;

    public string Usage;

    public Potion(int id, string name, int strength, string usage)
    {
        this.ID = id;
        this.Name = name;
        this.Strength = strength;
        this.Usage = usage;
    }

    public int Consuming(Player player)
    {
        if(this.Usage == "p")
        {
            this.Strength
        }
    }


}