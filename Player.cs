using System.Transactions;

public class Player
{
    public int Current_Health;

    public Weapon Current_Weapon;

    public Location Current_Location;
    public int Max_Health;

    public string Name;
    bool dead = false;
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
        } while (World.Monsters != null || this.Current_Health != 0);
    }

    public void Fighting2(Monster monster)
    {
        if (monster.CurrentHitPoints > 0)
        {
            Console.WriteLine($"You see the {monster.Name}");
            Console.WriteLine("Do you try to kill them? (Y/N)?");
            string user_answer = Console.ReadLine().ToLower();
            if (user_answer == "y")
            {
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
                            if (monster.CurrentHitPoints <= 0)
                            {
                                Console.WriteLine($"The {monster.Name} is dead!");
                                break;
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
            }
            if (this.Current_Health <= 0)
            {
                Console.WriteLine("You died. GAME OVER");
            }
        }
        else
        {
            Console.WriteLine($"the {monster.Name} is dead!");
        }
    }

    public bool MoveTo(Location newlocation)
    {
        if (newlocation != null)
        {
            Current_Location = newlocation;
            if (Current_Location.QuestAvailableHere != null)
            {
                if (Quest.quest_log.Contains(Current_Location.QuestAvailableHere) == false)
                { 
                Quest.StartQuest(Current_Location.QuestAvailableHere, Current_Location, Current_Location.MonsterLivingHere, this);
                }   
            }
            if (Current_Location.MonsterLivingHere != null)
                {
                    Fighting2(Current_Location.MonsterLivingHere);
                }
            }
            if (Current_Location == World.Locations[6] || Current_Location == World.Locations[8])
            {
                Quest.Riddles(this);
            }
                return true;
        {
            return false;
        }
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