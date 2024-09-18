using System.Formats.Asn1;

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

    public void Fighting2(Monster monster)
{
    Console.WriteLine($"You fight the {monster.Name}");
    while (this.Current_Health > 0 && monster.CurrentHitPoints > 0)
    {
        Console.WriteLine("What do you want to do? (A)ttack, use a (C)onsumable or (R)un?");
        bool run = false;
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
                Console.WriteLine("");
                int treshhold = 12;
                if (RollDice(treshhold))
                {
                     // The player flees,the quest is cancelled
                    Console.WriteLine("You successfully fled from the combat!");
                    run = true;
                    //player.Current_Location = World.Locations[0];
                }
                else
                {
                     // The player suffers consequences, the quest fails to cancel
                    Console.WriteLine("You failed to flee. The monster attacks you!");
                    monster.AttackPlayer(this);
                }
                break;
            default:
                Console.WriteLine("Invalid input. Please try again.");
                break;
        }
        if(run == true)
        {
            this.Current_Location = World.Locations[0];
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
        Console.WriteLine($"You try to hit {monster.Name} with {this.Current_Weapon.Name}");
        monster.TakeDamage(RollDamage(monster));
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
    
    public int RollDamage(Monster monster)
    {
        Random random = new Random();
        int diceroll = random.Next(1, 21);
        
        int damage = 0;
        
        if(diceroll == 20)
        {
            Console.WriteLine("You hit a crit!");
            damage = this.Current_Weapon.Damage + 5;
            Console.WriteLine($"You hit {monster.Name} for {damage}");
        }
        else if(diceroll > 17)
        {
            damage = this.Current_Weapon.Damage;
            Console.WriteLine($"You hit {monster.Name} for {damage}");
        }
        else if(diceroll > 12)
        {
            damage = Convert.ToInt32(Current_Weapon.Damage * 0.8);
            Console.WriteLine($"You hit {monster.Name} for {damage}");
        }
        else if(diceroll > 8)
        {
            damage = Convert.ToInt32(Current_Weapon.Damage * 0.4);
            Console.WriteLine($"You hit {monster.Name} for {damage}");
        }
        else if(diceroll > 4)
        {
            damage = Convert.ToInt32(Current_Weapon.Damage * 0.2);
            Console.WriteLine($"You hit {monster.Name} for {damage}");
        }
        else if(diceroll > 1)
        {
            damage = 0;
            Console.WriteLine("You missed!");
        }
        else if(diceroll == 1)
        {
            Console.WriteLine("You missed and the monster attacks again!");
            monster.AttackPlayer(this);
            damage = 0;
        }

        return damage;
    }

    public bool RollDice(int succestreshhold)
    {
        Random random = new Random();
        int diceroll = random.Next(1, 21);
    
        if (diceroll > succestreshhold)
        {
            Console.WriteLine($"That is a succes!");
            return true;
        }
        else
        {
            Console.WriteLine($"That is a fail...");
            return false;
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