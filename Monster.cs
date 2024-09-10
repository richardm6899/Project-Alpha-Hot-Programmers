public class Monster
{
    public int ID;
    public string Name;
    public int Damage;
    public int CurrentHitPoints;
    public int MaximumHitPoints;

    public Monster(int id, string name, int damage, int currenthitpoints, int maximumhitpoints)
    {
        ID = id;
        Name = name;
        Damage = damage;
        CurrentHitPoints = currenthitpoints;
        MaximumHitPoints = maximumhitpoints;

    }
}
