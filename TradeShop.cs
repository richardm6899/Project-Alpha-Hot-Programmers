//  The player must be able to buy items with currency they have received from quests or other ventures. - oli
//  The player must be able to sell inventory items they have received from quests or other ventures. - oli
//  The player must be able to enter and leave the shop while travelling. - oli
//  The player gets an overview of what the player can buy and sell. (preview of inventory)
//  The player can only buy and sell what he can afford.

using System.Security.Cryptography.X509Certificates;

static class TradeShop //oli
{
    public static bool running_shop = true;
    public static bool Selling = false;
    public static bool Buying = false;
    public static void TradeShopOG(Player player)
    {

        Console.Clear();
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Hello and welcome to Sir Hubert Albert the third's trade shop.");
        Console.WriteLine("We sell and buy,Consumables and weapons to help you on your quest.");

        while (running_shop)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Would you like to (B)uy item, (S)ell item or (L)eave shop: (B/S/L)");
            string choice = Console.ReadLine().ToUpper();
            Console.Clear();
            {
                if (choice == "S")
                {
                    bool S = true;
                    while (S)
                    {
                        Console.WriteLine("Would you like to sell (C)onsumables or (W)eapons: (C/W)");
                        string weap_cons = Console.ReadLine().ToUpper();
                        if (weap_cons == "C")
                        {
                            SellConsumable(player);
                            S = false;
                        }
                        else if (weap_cons == "W")
                        {
                            SellWeapon(player);
                            S = false;
                        }
                        else
                        {
                            Console.WriteLine("invalid input");
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("[Enter]");
                            Console.ReadLine();
                            Console.Clear();
                        }

                    }

                }
                else if (choice == "B")
                {
                    bool B = true;
                    while (B)
                    {
                        Console.WriteLine("Would you like to Buy (C)onsumables or (W)eapons: (C/W)");
                        string weap_cons = Console.ReadLine().ToUpper();
                        if (weap_cons == "C")
                        {
                            BuyConsumable(player);
                            B = false;
                        }
                        else if (weap_cons == "W")
                        {
                            BuyWeapon(player);
                            B = false;
                        }
                        else
                        {
                            Console.WriteLine("invalid input");
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("[Enter]");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }


                }
                else if (choice == "L")
                {
                    running_shop = false;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("[Enter]");
                    Console.ReadLine();
                    Console.Clear(); // choice buy or sell;
                }
            }
        }
    }

    public static Player SellWeapon(Player player)
    {
        Selling = true;
        while (Selling)
        {
            Console.WriteLine("These are the weapons you have....");
            foreach (var weapon in player.PlayerInventory.WeaponInventory)
            {
                Console.WriteLine($"Weapon ID: {weapon.ID}");
                Console.WriteLine($"Weapon name: {weapon.Name}");
                Console.WriteLine($"Weapon damage: {weapon.Damage}");
                Console.WriteLine($"Weapon Price: ${weapon.Price}");
                Console.WriteLine("..................................");
            }
            Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nMoney: ${player.Coins}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("What item would you like to sell for currency. Give a number. (id)");
            string id = Console.ReadLine();
            if (int.TryParse(id, out int trade_id)) //so int is made but player doens't get error when entering id with something other than int
            {
                foreach (var weapon in player.PlayerInventory.WeaponInventory)
                {
                    if (trade_id == weapon.ID)

                    {
                        bool confirmation_sell = true;
                        while (confirmation_sell)
                        {
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine($"Do you want to sell {weapon.Name} for ${weapon.Price}: (Y/N) ");
                            Console.WriteLine("--------------------------------------");
                            string yes_no = Console.ReadLine().ToUpper();
                            if (yes_no == "Y")
                            {
                                player.Coins += weapon.Price; // money added to coins when item is sold
                                player.RemoveItemFromInventory(null, World.WeaponByID(weapon.ID)); //removes sold item from player inventory
                                Console.WriteLine($"You have removed {weapon.Name} from your inventory");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine($"{weapon.Price} added to coins");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nMoney: ${player.Coins}");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("[Enter]");
                                Console.ReadLine();
                                Console.Clear();
                                confirmation_sell = false;
                                Selling = false;
                                return player; //return still bit of a mystery why it works lol


                            }
                            else if (yes_no == "N") //when no is entered get redirectd back to TradeshopOG
                            {
                                Console.WriteLine("[Enter]");
                                Console.ReadLine();
                                Console.Clear();
                                confirmation_sell = false;
                                Selling = false;
                                return player;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input"); //when invalid input is entered get redirectd back to TradeshopOG 
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("[Enter]");
                                Console.ReadLine();
                                Console.Clear();
                                confirmation_sell = false;
                                Selling = false;
                                return player;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("You dont have this weapon."); //when invalid input is entered get redirectd back to TradeshopOG
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("[Enter]");
                        Console.ReadLine();
                        Console.Clear();
                        Selling = false;
                        return player;
                    }

                }

            }
            else
            {
                Console.WriteLine("invalid input");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("[Enter]");
                Console.ReadLine();
                Console.Clear();
                Selling = false;
                return player;

            }
            return player;

        }
        return player;
    }
    public static Player SellConsumable(Player player)
    {
        Selling = true;
        while (Selling)
        {
            Console.WriteLine("These are the consumables you have....");
            foreach (var consumable in player.PlayerInventory.ConsumableInventory)
            {
                Console.WriteLine($"Consumable ID: {consumable.ID}");
                Console.WriteLine($"Consumable Name: {consumable.Name}");
                Console.WriteLine($"Consumable Strength: {consumable.Strength}");
                Console.WriteLine($"Consumable Usage: {consumable.Usage}");
                Console.WriteLine($"Consumable Price: ${consumable.Price}");

                Console.WriteLine("..................................");
            }
            Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nMoney: ${player.Coins}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("What item would you like to sell for currency. Give a number. (id)");
            string id = Console.ReadLine();
            if (int.TryParse(id, out int trade_id))
            {
                foreach (var consumable in player.PlayerInventory.ConsumableInventory)
                {
                    if (trade_id == consumable.ID)

                    {
                        bool confirmation_sell = true;
                        while (confirmation_sell)
                        {
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine($"Do you want to sell {consumable.Name} for ${consumable.Price}: (Y/N) ");
                            Console.WriteLine("--------------------------------------");
                            string yes_no = Console.ReadLine().ToUpper();
                            if (yes_no == "Y")
                            {
                                player.Coins += consumable.Price;
                                player.RemoveItemFromInventory(World.ConsumableByID(consumable.ID), null);
                                Console.WriteLine($"You have removed {consumable.Name} from your inventory");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine($"{consumable.Price} added to coins");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nMoney: ${player.Coins}");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("[Enter]");
                                Console.ReadLine();
                                Console.Clear();
                                confirmation_sell = false;
                                Selling = false;
                                return player;


                            }
                            else if (yes_no == "N")
                            {
                                Console.WriteLine("[Enter]");
                                Console.WriteLine("--------------------------------------");
                                Console.ReadLine();
                                Console.Clear();
                                confirmation_sell = false;
                                Selling = false;
                                return player;
                            }
                            else
                            {
                                Console.WriteLine("input error");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("[Enter]");
                                Console.ReadLine();
                                Console.Clear();
                                confirmation_sell = false;
                                Selling = false;
                                return player;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("You dont have this consumable.");
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("[Enter]");
                        Console.ReadLine();
                        Console.Clear();
                        Selling = false;
                        return player;
                    }

                }

            }
            else
            {
                Console.WriteLine("invalid input");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("[Enter]");
                Console.ReadLine();
                Console.Clear();
                Selling = false;
                return player;

            }
            return player;

        }
        return player;
    }
    public static void BuyConsumable(Player player) //makes buying possible consumables
    {
        bool Buying = true;
        while (Buying)
        {
            Console.WriteLine("This is our assortiment at the moment: ");
            foreach (var consumable in World.Consumables)
            {
                Console.WriteLine($"Consumable ID: {consumable.ID}");
                Console.WriteLine($"Consumable Name: {consumable.Name}");
                Console.WriteLine($"Consumable Strength: {consumable.Strength}");
                Console.WriteLine($"Consumable Usage: {consumable.Usage}");
                Console.WriteLine($"Consumable Price: ${consumable.Price}");

                Console.WriteLine("..................................");
            }

            player.DisplayInventory();// can be annoying cause switch weapon will be asked often.
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nMoney: ${player.Coins}");
            Console.WriteLine("What item would you like to Buy for currency. Give a number. (id)");

            string id = Console.ReadLine();
            if (int.TryParse(id, out int buy_id)) // to catch error if player gives input of non int otherwise will trip out somewhere  // could maybe delete it but too lazy to check lol
            {
                foreach (var consumable in World.Consumables) // go trough consumable wordl list to find same consumable as given id
                {
                    if (buy_id == consumable.ID) //get right weapon
                    {
                        if (player.Coins >= consumable.Price) //see if player can afford weapon
                        {
                            if (!player.PlayerInventory.ConsumableInventory.Contains(consumable)) //to check if player doesnt own consumable
                            {
                                Consumable bought_Consumable = World.ConsumableByID(consumable.ID);
                                player.AddItemToInventory(bought_Consumable, null);
                                player.Coins -= consumable.Price;
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine($"You have bought: {bought_Consumable.Name}");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("[Enter]");

                                Console.ReadLine();
                                Console.Clear();
                                Buying = false;

                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("You already own this Consumable."); // cant own same thing cause will get fucked up in the loop
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("[Enter]");
                                Console.ReadLine();
                                Console.Clear();
                                Buying = false;
                            }
                        }

                        else
                        {
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("You don't have enough money for this Consumable"); //not enough currency for weapon
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("[Enter]");
                            Console.ReadLine();
                            Console.Clear();
                            Buying = false;
                        }


                    }
                }
            }
            else
            {
                Console.WriteLine("invalid input (non matching id given) ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("[Enter]");
                Console.ReadLine();
                Console.Clear();
                Buying = false; // tryparse; 64
            }

        }
    }
    public static void BuyWeapon(Player player) // identical to BuyConsumable but with weapons
    {
        bool Buying = true;
        while (Buying)
        {
            Console.WriteLine("This is our assortiment at the moment: ");
            foreach (var weapon in World.Weapons)
            {
                Console.WriteLine($"Weapon ID: {weapon.ID}");
                Console.WriteLine($"Weapon name: {weapon.Name}");
                Console.WriteLine($"Weapon damage: {weapon.Damage}");
                Console.WriteLine($"Weapon Price: ${weapon.Price}");
                Console.WriteLine("..................................");

            }

            player.DisplayInventory();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nMoney: ${player.Coins}");
            Console.WriteLine("What item would you like to Buy for currency. Give a number. (id)");

            string id = Console.ReadLine();
            if (int.TryParse(id, out int buy_id))
            {
                foreach (var weapon in World.Weapons)
                {
                    if (buy_id == weapon.ID) //get right weapon
                    {
                        if (player.Coins >= weapon.Price)
                        {
                            if (!player.PlayerInventory.WeaponInventory.Contains(weapon))
                            {
                                Weapon bought_weapon = World.WeaponByID(buy_id);
                                player.AddItemToInventory(null, bought_weapon);
                                player.Coins -= weapon.Price;
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine($"You have bought: {bought_weapon.Name}");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("[Enter]");
                                Console.ReadLine();
                                Console.Clear();
                                Buying = false;

                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("You already own this weapon.");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("[Enter]");
                                Console.ReadLine();
                                Console.Clear();
                                Buying = false;
                            }
                        }

                        else
                        {
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("You don't have enough money for this weapon");
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("[Enter]");
                            Console.ReadLine();
                            Console.Clear();
                            Buying = false;
                        }


                    }
                }
            }
            else
            {
                Console.WriteLine("invalid input (non matching id given) 2 ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("[Enter]");
                Console.ReadLine();
                Console.Clear();
                Buying = false; // tryparse; 64
            }

        }
    }

}