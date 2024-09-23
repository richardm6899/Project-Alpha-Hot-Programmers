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

    public void Consuming(Player player)
    {
        switch(this.Usage.ToUpper())
        {
            case "P":
                player.Strength = true;
                Console.WriteLine("You feel a surge of energy!");

                break;

            case "H":
                player.Current_Health = player.Current_Health + (this.Strength * 5);
                if(player.Current_Health > player.Max_Health)
                {
                    player.Current_Health = player.Max_Health;
                }
                Console.WriteLine(player.DisplayHealth());
                break;
            
            default:
                Console.WriteLine("This is not a valid usage");
                break;
        }
    }

}