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

    public void AttackPlayer(Player player)
    {
        Console.WriteLine($"{Name} attacks {player.Name}!");
        int damage = this.Damage;
        if(player.Defense > 0)
        {
            damage = Convert.ToInt32(damage - (damage * (player.Defense * 0.25)));
        }
        player.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        this.CurrentHitPoints = this.CurrentHitPoints - damage;
        if(CurrentHitPoints > 0)
        {
            Console.WriteLine($"Monsters current health points: {World.MonsterByID(ID).CurrentHitPoints}"); // was Monster[2], changed to MonsterByID[ID]
        }
    }
}