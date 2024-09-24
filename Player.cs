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
    public int Strength = 0;
    public static int Questlog_count = 1;

    public int Defense = 0;
  
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



    // Inventory ----------------------------------------------------
    // add item in player inventory
    // how to: AddItemsToInventory(ConsumableByID(...),WeaponByID(...))

    // oli/Thomas

    public void Quest_log()
    {
        if (Questlog_count == 1)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ Reach the the townhall....               |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 2)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ Reach the Blacksmith's Yard......           |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 3)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ The Blacksmith wants to thank you for    |");
            Console.WriteLine("|+ you work. Head to the Blacksmith.         |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 4)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ Reach the Blacksmith's basemant to       |");
            Console.WriteLine("|+ continue the quest.                      |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 5)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ Talk to the blacksmith to recieve        |");
            Console.WriteLine("|+ your reward.                             |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 6)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ Head to the Alchemist.                   |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 7)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ Check out the cave to retrieve the loot  |");
            Console.WriteLine("|+ from the goblins..                         |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 8)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ Return to the alchemist..                  |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 9)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ Head to the shop....                        |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 10)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ Check out the strange noises in the      |");
            Console.WriteLine("|+ basement....                                |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 11)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ Get better weapons and potions at        |");
            Console.WriteLine("|+ the shop....                                |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }
        else if (Questlog_count == 12)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|+ You are now ready to defeat the          |");
            Console.WriteLine("|+ monster in the woods.....                    |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[Enter]");
            Console.ReadLine();
            Console.Clear();
        }


    }
      // Inventory ----------------------------------------------------
    // add item in player inventory
    // how to: AddItemsToInventory(ConsumableByID(...),WeaponByID(...))

    // oli/Thomas

    public void AddItemToInventory(Consumable consumable, Weapon weapon)
    {
        if (consumable == null && weapon == null)
        {
            Console.WriteLine("You can't do this.");
        }
        else if (consumable == null)
        {
            PlayerInventory.WeaponInventory.Add(weapon);
            Console.WriteLine("you got a weapon");

        }
        else if (weapon == null)
        {
            PlayerInventory.ConsumableInventory.Add(consumable);
            Console.WriteLine("you got a Consumable");
        }
    }

    // oli
    public void RemoveItemFromInventory(Consumable consumable, Weapon weapon)
    {
        if (consumable == null && weapon == null)
        {
            Console.WriteLine("You can't do this.");
        }
        else if (consumable == null)
        {
            PlayerInventory.WeaponInventory.Remove(weapon);
            Console.WriteLine("you removed a weapon");

        }
        else if (weapon == null)
        {
            PlayerInventory.ConsumableInventory.Remove(consumable);
            Console.WriteLine("you remove Consumable");
        }
    }
    // oli

    public void SwitchWeapon()
    {
        bool switch_weapon = true;
        while (switch_weapon)
        {
            // show current weapon name 
            Console.WriteLine($"Current weapon = {Current_Weapon.Name}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Weapon inventory: ");

            // list made to get all available weapon id for switching
            List<int> id_list = new();
            foreach (var weapon in PlayerInventory.WeaponInventory)
            {
                Console.WriteLine($"Weapon ID: {weapon.ID}");
                Console.WriteLine($"Weapon name: {weapon.Name}");
                Console.WriteLine($"Weapon damage: {weapon.Damage}");
                Console.WriteLine("--------------------------------------");
                id_list.Add(weapon.ID);


            }
            Console.WriteLine("Which weapon would you like to equip?: Enter ID");
            Console.WriteLine("--------------------------------------");
            string choice = Console.ReadLine();
            // try parse to check if player inserts a int otherwise invalid
            if (int.TryParse(choice, out int Weapon_id))
            {
                // makes new weapon object to replace with current weapon
                Weapon new_weapon = World.WeaponByID(Convert.ToInt32(Weapon_id));


                if (new_weapon != null && id_list.Contains(new_weapon.ID))
                {
                    // makes it so that the old weapon is placed back into inventory
                    AddItemToInventory(null, World.WeaponByID(Current_Weapon.ID));
                    RemoveItemFromInventory(null, World.WeaponByID(new_weapon.ID));
                    // replace current weapon with new weapon
                    Current_Weapon = new_weapon;
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Current weapon = {Current_Weapon.Name}");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("[Enter]");
                    Console.ReadLine();
                    switch_weapon = false;

                }
                else if (new_weapon != null && !id_list.Contains(new_weapon.ID))
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("You don't have this weapon....");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("[Enter]");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Invalid weapon ID");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("[Enter]");
                    Console.ReadLine();
                }


            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
    // oli/Thomas
    public void DisplayInventory()
    {
        bool display_inventory = true;
        while (display_inventory)
        {

            // shows how many weapons player has and what weapons player has

            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"You have {PlayerInventory.WeaponInventory.Count} weapons in your inventory");
            Console.WriteLine("--------------------------------------");
            foreach (var weapon in PlayerInventory.WeaponInventory)
            {
                Console.WriteLine($"Weapon ID: {weapon.ID}");
                Console.WriteLine($"Weapon name: {weapon.Name}");
                Console.WriteLine($"Weapon damage: {weapon.Damage}");
                Console.WriteLine("--------------------------------------");
            }
            // shows how many Consumables and what Consumable player has
            Console.WriteLine($"You have {PlayerInventory.ConsumableInventory.Count} Consumables in your inventory");
            Console.WriteLine("--------------------------------------");
            foreach (var consumable in PlayerInventory.ConsumableInventory)
            {

                Console.WriteLine($"Consumable name: {consumable.Name}");
                Console.WriteLine("--------------------------------------");
            }
            // Shows current weapon of player
            Console.WriteLine($"Current weapon ------------------");
            Console.WriteLine($"Weapon ID: {Current_Weapon.ID}");
            Console.WriteLine($"Weapon name: {Current_Weapon.Name}");
            Console.WriteLine($"Weapon damage: {Current_Weapon.Damage}");
            // if player has gained weapon let player be able to switch weapon
            if (PlayerInventory.WeaponInventory.Count > 0)
            {
                bool switch_weaponYN = true;
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Would you like to switch your current weapon?: (Y/N)");
                string choice = Console.ReadLine().ToUpper();
                // so can handle incorrect input.
                while (switch_weaponYN)
                {
                    if (choice == "Y")
                    {
                        display_inventory = false;
                        switch_weaponYN = false;
                        SwitchWeapon();
                    }
                    else if (choice == "N")
                    {
                        Console.WriteLine("leaving Inventory...");
                        display_inventory = false;
                        switch_weaponYN = false;

                    }
                    else
                    {
                        Console.WriteLine("Invalid input choice switch weapon Y/N");
                        switch_weaponYN = false;


                    }
                }
            }
            else
            {
                display_inventory = false;
            }

        }
    }

    //Inventory
    // public list<string>Inventory()
    // {

    // }

    public void Fighting2(Monster monster)
    {
        bool run = false;
        Console.WriteLine($"You fight the {monster.Name}");
        while (this.Current_Health > 0 && monster.CurrentHitPoints > 0)
        {
            Console.WriteLine("What do you want to do? (A)ttack, use a (C)onsumable or (R)un?");
            string answer = Console.ReadLine();
            switch (answer.ToUpper())
            {
                case "A":
                    AttackMonster(monster);
                    if (monster.CurrentHitPoints > 0)
                        monster.AttackPlayer(this);
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
                        monster.CurrentHitPoints = monster.MaximumHitPoints;
                    }
                    else
                    {
                        // The player suffers consequences, the quest fails to cancel
                        Console.WriteLine("You failed to flee. The monster attacks you!");
                        monster.AttackPlayer(this);
                    }
                    break;

                case "C":
                    if(this.PlayerInventory.ConsumableInventory.Count != 0)
                    {
                        foreach (var consumable in PlayerInventory.ConsumableInventory)
                            {
                                int count = 1;
                                Console.WriteLine("Pick a Consumable:");
                                Console.WriteLine($"Consumable name: ({count}){consumable.Name}");
                                Console.WriteLine("--------------------------------------");
                            }
                        string id = Console.ReadLine();

                        if(int.TryParse(id, out int ConsumableID))
                        {
                            ConsumableID = ConsumableID - 1;
                            Consumable consumableToUse = PlayerInventory.ConsumableInventory[ConsumableID];
                            if (consumableToUse != null)
                            {
                                consumableToUse.Consuming(this);
                                PlayerInventory.ConsumableInventory.Remove(consumableToUse);
                                Console.WriteLine($"You used {consumableToUse.Name}.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have any consumables.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;

            }
            if (run == true)
            {
                this.Current_Location = World.Locations[0];
                break;

            }
        }
        if (run == false)
        {  
            if (this.Current_Health <= 0)
            {
                Console.WriteLine("You died. GAME OVER");
            }
            else
            {
                Console.WriteLine($"You killed the {monster.Name}!");
                this.Strength = 0;
                this.Defense = 0;
            }
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

        if (diceroll == 20)
        {
            Console.WriteLine("You hit a crit!");
            damage = this.Current_Weapon.Damage + 5;
            Console.WriteLine($"You hit {monster.Name} for {damage}");
        }
        else if (diceroll > 17)
        {
            damage = this.Current_Weapon.Damage;
            Console.WriteLine($"You hit {monster.Name} for {damage}");
        }
        else if (diceroll > 12)
        {
            damage = Convert.ToInt32(Current_Weapon.Damage * 0.8);
            Console.WriteLine($"You hit {monster.Name} for {damage}");
        }
        else if (diceroll > 8)
        {
            damage = Convert.ToInt32(Current_Weapon.Damage * 0.4);
            Console.WriteLine($"You hit {monster.Name} for {damage}");
        }
        else if (diceroll > 4)
        {
            damage = Convert.ToInt32(Current_Weapon.Damage * 0.2);
            Console.WriteLine($"You hit {monster.Name} for {damage}");
        }
        else if (diceroll > 1)
        {
            damage = 0;
            Console.WriteLine("You missed!");
        }
        else if (diceroll == 1)
        {
            Console.WriteLine("You missed and the monster attacks again!");
            monster.AttackPlayer(this);
            damage = 0;
        }


        if (this.Strength > 0)
        {
            damage = Convert.ToInt32(damage * 1.5);
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