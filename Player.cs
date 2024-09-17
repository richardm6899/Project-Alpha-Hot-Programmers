public class Player
{
    public int Current_Health;

    public Weapon Current_Weapon;

    public Location Current_Location;
    public int Max_Health;
    public Inventory PlayerInventory = new Inventory();
    public int Coins;
    public string Name;
    //Player Info
    public Player(string name, Location current_location)
    {
        this.Name = name;
        // this.Coins = coins;
        this.Current_Health = 100;
        this.Max_Health = 100;
        // this.Defense = defense;
        this.Current_Weapon = World.Weapons[0];
        this.Current_Location = World.Locations[0];
        this.Coins = 10;
        
    }

    public void AddItemsToInventory(Potion potion, Weapon weapon)
    {
        if(potion == null && weapon == null)
        {
            Console.WriteLine("You can't do this.");
        } 
        else if(potion == null)
        {
            PlayerInventory.WeaponInventory.Add(weapon);
            Console.WriteLine("you got a weapon");

        }
        else if(weapon == null)
        {
            PlayerInventory.PotionInventory.Add(potion);
            Console.WriteLine("you got a potion");
        }
    }

    //Inventory
    // public list<string>Inventory()
    // {

    // }

    public void Fighting(Monster monster)
    {
        Console.WriteLine($"You fight the {monster}");
        string answer1 = Console.ReadLine();
        do
        {
            AttackMonster(monster);
            monster.AttackPlayer(this);
        }while(World.Monsters != null|| this.Current_Health != 0);
    }

    public void Fighting2(Monster monster)
{

    Console.WriteLine($"You fight the {monster.Name}");
    while (this.Current_Health > 0 && monster.CurrentHitPoints > 0)
    {
        Console.WriteLine("What do you want to do? (A)ttack or (R)un?");
        string answer = Console.ReadLine();
        switch (answer.ToUpper())
        {
            case "A":
                AttackMonster(monster);
                if (monster.CurrentHitPoints > 0)
                {
                    monster.AttackPlayer(this);
                }
                break;
            case "R":
                if (CancelFight())
                {
                    Console.WriteLine("You successfully fled from the combat!");
                    //player.Current_Location = World.Locations[0];
                }
                else
                {
                    Console.WriteLine("You failed to flee. The monster attacks you!");
                    monster.AttackPlayer(this);
                }
                break;
            default:
                Console.WriteLine("Invalid input. Please try again.");
                break;
        }
    }
    if (this.Current_Health <= 0)
    {
        Console.WriteLine("You died. GAME OVER");
    }
    else
    {
        Console.WriteLine($"You killed the {monster.Name}!");
    }
}

    public bool MoveTo(Location newlocation)
    {
        if (newlocation != null)
        {
            Current_Location = newlocation;
            return true;
        }
        return false;
    }

    public void Heal(int health)
    {
        this.Current_Health = Current_Health + health;
    }

    public void FullHealth()
    {
        this.Current_Health = this.Max_Health;
        Console.WriteLine(DisplayHealth());
    }

    public void AttackMonster(Monster monster)
    {
        Console.WriteLine($"You hit {monster.Name}! for {Current_Weapon.Damage}");
        monster.TakeDamage(Current_Weapon.Damage);
    }

    public void TakeDamage(int damage)
    {
        if (Current_Health <= 0)
        {
            Console.WriteLine("You died\n GAME OVER");

        }
        else
        {
            this.Current_Health = this.Current_Health - damage;
            Console.WriteLine(DisplayHealth());
        }
    }

    public string DisplayHealth()
    {
        return $"Current health: {this.Current_Health}";
    }



    
    public string Get_Current_Location()
    {
        return this.Current_Location.Name;
    }
    
    public static bool CancelFight()
    {
        int rolldice = new Random().Next(1, 7);
        int fleethreshhold = 3;

        if (rolldice > fleethreshhold)
        {
            return true; // The player flees,the quest is cancelled
        }
        else
        {
            return false; // The player suffers consequences, the quest fails to cancel
        }
    }





    // //Less coins
    // public int Spend()
    // {

    // }

    // //More coins
    // public int Pay()
    // {

    // }


}