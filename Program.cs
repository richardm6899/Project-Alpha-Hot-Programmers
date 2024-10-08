﻿using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

class Program
{
    public static void Main()
    {
        // before game starts
        bool running = true; // main game loop only false if you want game to stop
        bool home_screen = true;  // home screen -- could implement pause game

        // quests
        bool quest_blacksmith_garden = false; // fight roaches 
        bool quest_blacksmith_items = false; // find items in basement 
        bool quest_alchemists_items = false; // fight loot goblin
        bool quest_save_halflings = false; // save halflings from cages. math mini game?
        bool quest_aragog = false; // fight aragog (big ass spider in the forest)

        //places
        bool shop = false;
        bool home = true;
        bool shop_basement = false;
        bool blacksmith_yard = false;
        bool blacksmith = false;
        bool blacksmith_basement = false;
        bool alchemist_tower = false;
        bool cave = false;
        bool campfire = false;
        bool forest = false;
        bool return_home = false; // sets to true when been home already so player can choose to go to bed to heal

        // rewards
        bool reward_mayor = false;  // you get rusty sword and can go to blacksmith
        bool reward_blacksmith = false; // you get better sword and can go to alchemist
        bool reward_alchemist = false; // you get health potion you can go to shop, when u return items
        bool reward_shopkeeper = false; // you can shop in the shop

        // cave things
        bool item = true;
        bool goblin_in_room = true;

        //home screen
        while (home_screen)
        {
            System.Console.WriteLine("Hey Welcome to Hot Adventure.");
            Console.WriteLine("-------------------------------");
            System.Console.WriteLine("press [enter] to start.");
            Console.WriteLine("-------------------------------");
            System.Console.ReadLine();
            home_screen = false;
        }


        // player name
        System.Console.WriteLine("What is your characters name? ");
        string? player_name = Console.ReadLine();
        while (player_name == null || player_name == "")
        {
            System.Console.WriteLine("Incorrect Input\nPlayer name: ");
            player_name = Console.ReadLine();
        }
        player_name = char.ToUpper(player_name[0]) + player_name.Substring(1); // capitalize first letter

        // create player
        Player player = new Player(player_name, World.Locations[0]);

        Console.WriteLine("-------------------------------");
        // System.Console.Clear();
        System.Console.WriteLine("Player starting stats: ");

        // player starting stats
        System.Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nCoins: {player.Coins}\nLocation: {player.Current_Location.Name}");
        Console.WriteLine("-------------------------------");
        System.Console.WriteLine("[enter]");
        System.Console.ReadLine();
        // System.Console.Clear();
        while (running)
        {
            // if player dies
            if (player.Current_Health <= 0)
            {
                System.Console.WriteLine("You died....)");
                break;
            }
            while (home) // first time coming home without ever moving /game intro
            {

                Console.WriteLine("-------------------------------");
                Console.WriteLine("Trrriiiing Triiiing.\nIts 9 AM. Time to start the day.\nAs you walk down your cat George greets you.");
                Console.WriteLine("Lovely morning isn't it. You sit down grab an apple.");
                player.AddItemToInventory(World.Consumables[0], null);
                Console.WriteLine("As you take your first look outside you see chaos and mayhem everywhere.");
                Console.WriteLine("Time to start and adventure.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("You need to reach the town hall(T) to meet the mayor, he might know what to do.");
                Console.WriteLine("-------------------------------");

                System.Console.WriteLine("[enter]");
                System.Console.ReadLine();
                // System.Console.Clear();
                home = false;
            }

            System.Console.WriteLine($"Name: {player.Name}\nHealth: {player.Current_Health}\nCoins: {player.Coins}\nLocation: {player.Current_Location.Name}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        SB\n         |\n         S\n         |\n         T\n         |\n    F-CF-H-Y-B-BB\n         |\n         A\n         |\n         C");
            Console.WriteLine("-------------------------------");
            System.Console.WriteLine("[enter]");
            Console.ReadLine();
            System.Console.WriteLine("Current location: " + player.Current_Location.Name);
            System.Console.WriteLine(player.Current_Location.Compass());
            System.Console.WriteLine("Where to go? N/E/S/W");
            System.Console.WriteLine("Map info: M");
            System.Console.WriteLine("Inventory: I");
            System.Console.WriteLine("Quest Log: L");
            System.Console.WriteLine("Quit game: Q");
            string direction = Console.ReadLine().ToUpper();
            // System.Console.Clear();

            // player choice
            // show info about map
            if (direction == "M") Location.Map();

            // quest log (what you have to do now/what you are doing)
            if (direction == "L") player.Quest_log();

            // show player inventory
            if (direction == "I") player.DisplayInventory();

            // quit game
            if (direction == "Q")
            {
                System.Console.WriteLine("Quitting game........");
                System.Console.ReadKey();
                break;
            }
            // game play
            else player.MoveTo(player.Current_Location.GetLocationAt(direction));

            // home
            if (player.Current_Location.ID == 1)
            {
                System.Console.WriteLine("You enter you home.");
                System.Console.WriteLine(player.Current_Location.Description);
            }

            // town hall
            if (player.Current_Location.ID == 2)
            {
                Console.WriteLine("-------------------------------");
                System.Console.WriteLine("You see the mayor.\nYou go up to him.");

                // no weapon you have done nothing yet.
                if (quest_blacksmith_garden == false && reward_mayor == false)
                {
                    string user_save_town = "";
                    do
                    {
                        // mayor tells u about quest to get to the blacksmith
                        System.Console.WriteLine("The mayor tells you about a scary monster in the forest.");
                        System.Console.WriteLine("He asks if you could try to save the town.\nY/N. ");
                        Console.WriteLine("-------------------------------");

                        user_save_town = System.Console.ReadLine().ToUpper();
                        if (user_save_town == "Y")
                        {
                            // gives weapon
                            // System.Console.Clear();
                            Console.WriteLine("-------------------------------");
                            System.Console.WriteLine("The mayor thanks you, but sees you don't have a weapon.");
                            System.Console.WriteLine("He gives you a rusty looking sword.");
                            System.Console.WriteLine("He apologizes for not having anything better for you");

                            // recieve weapon
                            player.AddItemToInventory(null, World.Weapons[1]);
                            System.Console.WriteLine("He says the blacksmith might be able to improve your sword,\nbut his garden is overrun by cockroaches.");
                            Console.WriteLine("-------------------------------");
                            // start quest blacksmith garden

                            // "Go to the blacksmith to upgrade sword",
                            // "Kill cockroaches in the blacksmith's garden. "
                            blacksmith_yard = true;
                            reward_mayor = true;
                            // quest log naar 2
                            if (Player.Questlog_count == 1)
                            {
                                Player.Questlog_count = 2;
                            }
                        }
                        else if (user_save_town == "N")
                        {
                            Console.WriteLine("-------------------------------");
                            System.Console.WriteLine("The mayor looks kind of sad.\nYou think he's about to cry.");
                            System.Console.WriteLine("You decide to walk away.");
                            Console.WriteLine("-------------------------------");
                            player.Current_Location = World.Locations[0];
                        }
                        else System.Console.WriteLine("Incorrect input");
                    } while (user_save_town != "Y" && user_save_town != "N");
                }
                //  themayor has given you a weapon and you return to him
                else if (reward_mayor)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("The mayor is grateful you want to help the town.");
                    Console.WriteLine("-------------------------------");
                }
            }

            // blacksmith yard
            if (player.Current_Location.ID == 3)
            {
                // you go to the blacksmith garden, you have seen the mayor, and haven't finished the cockroach fight
                if (blacksmith_yard && quest_blacksmith_garden == false)
                {
                    // System.Console.WriteLine("You see huge cockroaches in the garden.");
                    // System.Console.WriteLine("Do you try to kill them? (Y/N) ");
                    // string user_answer = Console.ReadLine().ToLower();
                    // you choose to fight the roaches
                    //questlog_count naar 3
                    if (Player.Questlog_count == 2)
                    {
                        Player.Questlog_count = 3;
                    }
                    if (player.Current_Location.MonsterLivingHere.CurrentHitPoints <= 0)
                    {
                        // fight roaches
                        // if win blacksmith = true and quest_blacksmith_garden = true
                        blacksmith = true;
                        quest_blacksmith_garden = true;
                        //  else stay false and die or respawn.
                    }
                    // you do not choose to fight
                    else
                    {
                        // go back home
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Nothing to find here right now. Time to go back home...");
                        Console.WriteLine("-------------------------------");
                        player.Current_Location = World.Locations[0];
                    }
                }
                //  you go to the garden and have been by the mayor, and have killed the roaches
                else if (quest_blacksmith_garden)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You return to the blacksmiths garden.");
                    System.Console.WriteLine("There are no more cockroaches.");
                    Console.WriteLine("-------------------------------");
                }
                //  have not been by the mayor
                else if (blacksmith_yard == false)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You need to find a weapon to go here.");
                    System.Console.WriteLine("Going back home...");
                    Console.WriteLine("-------------------------------");
                    // go back home
                    player.Current_Location = World.Locations[0];
                }
            }

            // blacksmith
            if (player.Current_Location.ID == 4)
            {
                // you killed the cockroaches but don't have the blacksmiths items yet
                if (quest_blacksmith_items == false)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("The blacksmith thanks you for killing the monsters in hig garden.");
                    System.Console.WriteLine("He asks you to find his tools in his basement.");
                    System.Console.WriteLine("He says he'll give you a better sword if you do.");
                    Console.WriteLine("-------------------------------");
                    blacksmith_basement = true;
                    //questlog naar 4
                    if (Player.Questlog_count == 3)
                    {
                        Player.Questlog_count = 4;
                    }

                }
                // you give the items to the blacksmith and he gives a better sword
                else if (reward_blacksmith == false)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You give the tools, the blacksmith smiles.");
                    // you get better weapon
                    System.Console.WriteLine("The blacksmith gives you a better sword.");
                    player.AddItemToInventory(null, World.Weapons[2]);
                    reward_blacksmith = true;

                    System.Console.WriteLine("He tells you about an alchemist that lives near that could give you potions for battle.");
                    Console.WriteLine("-------------------------------");
                    alchemist_tower = true;
                    // questlog_count naar 6
                    if (Player.Questlog_count == 5)
                    {
                        Player.Questlog_count = 6;
                    }
                }
                // you gave the items and he gave sword
                else if (reward_blacksmith)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("The blacksmith just kind of stares at you weirdly.");
                    System.Console.WriteLine("He keeps talking about a mean alchemist that lives south of him.");
                    System.Console.WriteLine("You think about leaving.");
                    Console.WriteLine("-------------------------------");
                }
            }

            // blacksmith basement
            if (player.Current_Location.ID == 5)
            {
                // "mini game" look for items in boxes. you find weird shit and in one of the boxes you find 
                // maybe switch statements
                // when correct box found
                quest_blacksmith_items = true;
                if (Player.Questlog_count == 4)
                {
                    Player.Questlog_count = 5;
                }
            }


            // alchemists tower
            if (player.Current_Location.ID == 6)
            {
                // you haven't given the items to the blacksmith yet
                if (alchemist_tower == false)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You knock on the door. Someone yells at you.");
                    System.Console.WriteLine("You decide to go back home");
                    Console.WriteLine("-------------------------------");
                    player.Current_Location = World.Locations[0];
                }
                // you've given the items to the blacksmith but you don't have the alchemists items yet
                else if (quest_alchemists_items == false)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You hear the alchemist inside.\nHe sounds upset.");
                    System.Console.WriteLine("You hear him say something about a goblin and his stuff.");
                    System.Console.WriteLine("His muttering about a nearby cave gives you the idea to go there and try to get his stuff back.");
                    System.Console.WriteLine("You hope this will make him want to talk to you.");
                    Console.WriteLine("-------------------------------");
                    cave = true;
                    // questlog count naar 7 
                    if (Player.Questlog_count == 6)
                    {
                        Player.Questlog_count = 7;
                    }
                }
                // you defeated the loot goblin and you're returning their items
                else if (quest_alchemists_items && reward_alchemist == false)
                {
                    // you get the alchemists items from the cave
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You knock on the door.\nA small peep hole opens.");
                    System.Console.WriteLine("The alchemist starts yelling at you.\nYou show the bag you took from the loot goblin.");
                    System.Console.WriteLine("They stop yelling.\nThe door slightly opens.\nYou hear the alchemist say \"I'll give you some potions for the bag\"");
                    System.Console.WriteLine("You agree.\nThey say \"Don't come back here, if you want more stuff go to the shop.\"");
                    Console.WriteLine("-------------------------------");
                    // you get potions
                    reward_alchemist = true;
                    shop = true;
                    //player count naar 9
                    if (Player.Questlog_count == 8)
                    {
                        Player.Questlog_count = 9;
                    }
                }
                // you've given the items to the alchemist
                else if (reward_alchemist)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You knock on the door.\nYou hear humming.\nThe door doesn't open");
                    Console.WriteLine("-------------------------------");
                    player.Current_Location = World.Locations[0];
                }
            }

            // cave
            if (player.Current_Location.ID == 7)
            {
                Console.WriteLine("-------------------------------");
                System.Console.WriteLine("You walk to the cave behind the tower.");
                System.Console.WriteLine("You see a board next to the entrance.");
                Art.CaveMap();
                System.Console.WriteLine("Do you enter? Y/N ");
                Console.WriteLine("-------------------------------");
                string user_cave = "";
                do
                {
                    user_cave = Console.ReadLine().ToUpper();
                    if (user_cave == "Y")
                    {
                        bool in_cave = true;
                        // you enter the cave
                        player.Current_Location = World.Locations[11];
                        do
                        {
                            // player dies
                            if (player.Current_Health <= 0)
                            {
                                break;
                            }
                            System.Console.WriteLine($"Name: {player.Name}\nHealth: {player.Current_Health}\nCoins: {player.Coins}\nLocation: {player.Current_Location.Name}");
                            System.Console.WriteLine("[enter]");
                            Console.ReadLine();
                            System.Console.WriteLine("Current location: " + player.Current_Location.Name);
                            System.Console.WriteLine(player.Current_Location.Compass());
                            System.Console.WriteLine("Where to go? N/E/S/W");
                            System.Console.WriteLine("Inventory: I");
                            // System.Console.WriteLine("Quest Log: L");
                            System.Console.WriteLine("Cave map: C");
                            System.Console.WriteLine("Exit cave: EC");
                            string cave_direction = Console.ReadLine().ToUpper();
                            // System.Console.Clear();

                            // player choice

                            // quest log (what you have to do now/what you are doing)
                            // if (direction == "L") quest log

                            // show player inventory
                            if (cave_direction == "I") player.DisplayInventory();

                            // show cave map
                            if (cave_direction == "C") Art.InsideCaveMap();

                            if (cave_direction == "EC")
                            {
                                in_cave = false;
                                player.Current_Location = World.Locations[3];
                            }

                            // game play
                            else player.MoveTo(player.Current_Location.GetLocationAt(cave_direction));

                            switch (player.Current_Location.ID)
                            {
                                // cave room 1
                                case 12:
                                    {
                                        System.Console.WriteLine("You're at the cave entrance. It's cold, the walls are moist. ieuw.");
                                        System.Console.WriteLine("You hear sounds all around you. \nWhich way do you go?");
                                        break;
                                    }

                                // cave room 2
                                case 13:
                                    {
                                        System.Console.WriteLine("You hear hissing sounds to your right.\nIt might not be smart to go that way.");
                                        break;
                                    }

                                // cave room 3
                                case 14:
                                    {
                                        System.Console.WriteLine("You see a few gold coins.\nYou hear whispering.");
                                        break;
                                    }

                                // cave room 4
                                case 15:
                                    {
                                        if (World.Monsters[1].CurrentHitPoints <= 0)
                                        {
                                            System.Console.WriteLine("You see the goblins stuff on the ground.\nIt might be from the Alchemist.");
                                            System.Console.WriteLine("You take it with you.");
                                            quest_alchemists_items = true;
                                        }
                                        System.Console.WriteLine("There are coins leading west.\nThere are also food scraps laying around.");
                                        break;
                                    }

                                // cave room 5
                                case 16:
                                    {
                                        System.Console.WriteLine("It's a dead end.\nYou sit down for a bit.");
                                        break;
                                    }

                                // cave room goblin
                                case 17:
                                    {
                                        break;
                                    }
                                // cave room item

                                case 18:
                                    {
                                        if (item)
                                        {
                                            System.Console.WriteLine("You see an item on the ground.\nPick it up? Y/N");
                                            string player_pick_up = Console.ReadLine().ToUpper();
                                            if (player_pick_up == "Y")
                                            {
                                                player.AddItemToInventory(World.Consumables[3], null);
                                                System.Console.WriteLine("You pick up a potato.\nMaybe it would be better heated up.");
                                                item = false;
                                            }
                                            else
                                            {
                                                System.Console.WriteLine("You've already picked up the item here.");
                                            }
                                        }
                                        break;
                                    }

                                // cave room snake
                                case 19:
                                    {
                                        System.Console.WriteLine("You see a whole lotta snakes in the room.");
                                        System.Console.WriteLine("You try to run away but one bites you in the leg.\nYou lose 5 health.");
                                        player.Current_Health -= 5;
                                        player.Current_Location = World.Locations[12];
                                        break;
                                    }

                                default:
                                    {
                                        System.Console.WriteLine("Error");
                                        break;
                                    }

                            }

                            user_cave = "N";

                        } while (in_cave == true);
                    }
                    else if (user_cave == "N")
                    {
                        Console.WriteLine("-------------------------------");
                        System.Console.WriteLine("You don't enter the cave just yet.");
                        System.Console.WriteLine("You return to the alchemists tower.");
                        Console.WriteLine("-------------------------------");
                        player.Current_Location = World.Locations[2];
                    }
                    else System.Console.WriteLine("Incorrect input");
                } while (user_cave != "Y" && user_cave != "N");
            }

            //shop
            if (player.Current_Location.ID == 8)
            {
                // alchemists quest has net been done
                if (shop == false)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("There is a sign on the door.\nIt reads");
                    Art.ShopSign();
                    System.Console.WriteLine("You return to the town hall.");
                    Console.WriteLine("-------------------------------");
                    player.Current_Location = World.Locations[1];
                }
                else if (shop && reward_shopkeeper == false)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You enter the shop.\nYou see a weird looking thing behind the counter.");
                    System.Console.WriteLine("The thing starts talking \"Welcome to my sh-\"");
                    System.Console.WriteLine("While he's talking you hear strange sounds coming from his basement.\nHe kind of looks embarrassed.");
                    System.Console.WriteLine("You decide to go look down there.\nThe creature looks at you but doesn't say anything.");
                    Console.WriteLine("-------------------------------");
                    shop_basement = true;
                    // count naar 10
                    if (Player.Questlog_count == 9)
                    {
                        Player.Questlog_count = 10;
                    }

                }
                else if (reward_shopkeeper)
                {
                    TradeShop.running_shop = true;
                    TradeShop.TradeShopOG(player);
                    // player count naar 12
                    if (Player.Questlog_count == 11)
                    {
                        Player.Questlog_count = 12;
                    }
                    player.Current_Location = World.Locations[1];
                    campfire = true;
                }

            }

            // shop basement 
            if (player.Current_Location.ID == 9)
            {
                //after youve done the quest you get new quest log
                Console.WriteLine("-------------------------------");
                Console.WriteLine("[Enter]");
                Console.ReadLine();
                if (shop_basement)
                {
                    if (Player.Questlog_count == 10)
                    {
                        Player.Questlog_count = 11;
                    }
                    reward_shopkeeper = true;
                }


            }
            // campfire
            if (player.Current_Location.ID == 10)
            {
                if (campfire)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("In the clearing of the forest you spot a faint light with several shadows around it.");
                    Console.WriteLine("You approach the campfire.\nYou spot fellow villagers taking a break from the chaos all around.");
                    Console.WriteLine("This is a safe haven. The campfire has healing properties.");
                    Console.WriteLine("Holding your hands near the fire might heal you up for battle.");
                    Console.WriteLine("-------------------------------");

                    bool campfire_heal = true;
                    while (campfire_heal)
                    {
                        Console.WriteLine("Would you like to heal up? (Y/N)");
                        Console.WriteLine("-------------------------------");
                        string campfire_choice = Console.ReadLine().ToUpper();
                        Console.Clear();
                        if (campfire_choice == "Y")
                        {
                            // heal player
                            player.FullHealth();
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("player healed");
                            Console.WriteLine("-------------------------------");
                            campfire_heal = false;
                        }
                        else if (campfire_choice == "N")
                        {
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("healing rejected");
                            Console.WriteLine("-------------------------------");
                            campfire_heal = false;

                        }
                        else
                        {
                            Console.WriteLine("invalid input (Y/N)");
                        }
                    }
                }
                else if (campfire == false)
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You see a campfire in the distance.");
                    System.Console.WriteLine("It looks scary\nYou turn back for now.");
                    System.Console.WriteLine("Returning home..");
                    Console.WriteLine("-------------------------------");
                    player.Current_Location = World.Locations[0];
                }
            }

            // aragog 
            if (player.Current_Location.ID == 11)
            {
                quest_aragog = true;
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Aragog lives here\nDo you fight him?\nY/N ");
                Console.WriteLine("-------------------------------");
                string user_aragog = System.Console.ReadLine().ToUpper();
                if (user_aragog == "Y")
                {
                    bool beaten_aragog = true;
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You defeated the monster, you can return home to rest.");
                    Console.WriteLine("-------------------------------");
                }

                else if (user_aragog == "N")
                {
                    Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("You don't dare to fight Aragog yet.");
                    System.Console.WriteLine("You return to the campfire...");
                    Console.WriteLine("-------------------------------");
                    player.Current_Location = World.Locations[9];
                }
            }

            // end game
            if (player.Current_Location.ID == 1 && quest_aragog == true)
            {
                Console.WriteLine("-------------------------------");
                System.Console.WriteLine("You did it!!!\nYou defeated the monster in the forest and helped the village people.");
                System.Console.WriteLine("You are a hero.");
                Console.WriteLine("-------------------------------");
                running = false;
            }
        }
    }
}