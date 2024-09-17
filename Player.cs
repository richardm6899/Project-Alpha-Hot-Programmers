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
    // Inventory ----------------------------------------------------
    // add item in player inventory
    // how to: AddItemsToInventory(PotionByID(...),WeaponByID(...))

    // oli/Thomas
    public void AddItemToInventory(Potion potion, Weapon weapon)
    {
        if (potion == null && weapon == null)
        {
            Console.WriteLine("You can't do this.");
        }
        else if (potion == null)
        {
            PlayerInventory.WeaponInventory.Add(weapon);
            Console.WriteLine("you got a weapon");

        }
        else if (weapon == null)
        {
            PlayerInventory.PotionInventory.Add(potion);
            Console.WriteLine("you got a potion");
        }
    }
    // oli
    public void RemoveItemFromInventory(Potion potion, Weapon weapon)
    {
        if (potion == null && weapon == null)
        {
            Console.WriteLine("You can't do this.");
        }
        else if (potion == null)
        {
            PlayerInventory.WeaponInventory.Remove(weapon);
            Console.WriteLine("you removed a weapon");

        }
        else if (weapon == null)
        {
            PlayerInventory.PotionInventory.Remove(potion);
            Console.WriteLine("you remove potion");
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
            foreach(var weapon in PlayerInventory.WeaponInventory)
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
            // try parse to check if player inserts a 
            if (int.TryParse(choice, out int Weapon_id))
            {
                // makes new weapon object to replace with current weapon
                Weapon new_weapon = World.WeaponByID(Convert.ToInt32(Weapon_id));
                

                if (new_weapon != null && id_list.Contains(new_weapon.ID))
                {
                    // makes it so that the old weapon is placed back into inventory
                    AddItemToInventory(null,World.WeaponByID(Current_Weapon.ID));
                    RemoveItemFromInventory(null,World.WeaponByID(new_weapon.ID));
                    // replace current weapon with new weapon
                    Current_Weapon = new_weapon;
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Current weapon = {Current_Weapon.Name}");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("[Enter]");
                    Console.ReadLine();
                    switch_weapon = false;
                    Console.Clear();
                }
                else if(new_weapon != null && !id_list.Contains(new_weapon.ID))
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("You don't have this weapon....");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("[Enter]");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Invalid weapon ID");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("[Enter]");
                    Console.ReadLine();
                    Console.Clear();
                }


            }
            else
            {
                Console.WriteLine("Invalid output");
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
            // shows how many potions and what potion player has
            Console.WriteLine($"You have {PlayerInventory.PotionInventory.Count} potions in your inventory");
            Console.WriteLine("--------------------------------------");
            foreach (var potion in PlayerInventory.PotionInventory)
            {

                Console.WriteLine($"Consumable name: {potion.Name}");
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
                        Console.WriteLine("leaving Inventory;");
                        display_inventory = false;
                        switch_weaponYN = false;

                    }
                    else
                    {
                        Console.WriteLine("Invalid input choice switch weapon Y/N");
                        switch_weaponYN = false;
                        Console.Clear();

                    }
                }
            }

            
        }

    }



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