using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
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

        //home screen
        while (home_screen)
        {

            System.Console.WriteLine("Hey Welcome to Hot Adventure.");
            Console.WriteLine("-------------------------------");
            System.Console.WriteLine("press [enter] to start.");
            Console.WriteLine("-------------------------------");
            System.Console.ReadKey();
            home_screen = false;
        }
        // ask player for name and show player beginning stats
        System.Console.WriteLine("What is your characters name? ");
        string player_name = Console.ReadLine();
        Player player = new Player(player_name, World.Locations[0]);
        Console.WriteLine("-------------------------------");
        System.Console.Clear();
        System.Console.WriteLine("Player starting stats:");

        System.Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nLocation: {player.Current_Location.Name}");
        Console.WriteLine("-------------------------------");
        System.Console.WriteLine("[enter]");
        System.Console.ReadKey();
        System.Console.Clear();
        while (running)
        {
            while (home) // first time coming home without ever moving /game intro
            {

                Console.WriteLine("-------------------------------");
                Console.WriteLine("Trrriiiing Triiiing.\nIts 9 AM. Time to start the day.\nAs you walk down your cat George greets you.");
                Console.WriteLine("Lovely morning isn't it. As you take your first look outside you see chaos and mayhem everywhere.");
                Console.WriteLine("Time to start and adventure.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("You need to reach the town hall(T) to meet the mayor.");
                Console.WriteLine("        SB\n         |\n         S\n         |\n         T\n         |\n    F-CF-H-Y-B-BB\n         |\n         A\n         |\n         C");
                Console.WriteLine("-------------------------------");
                System.Console.WriteLine("[enter]");
                System.Console.ReadKey();
                System.Console.Clear();
                home = false;
                return_home = true;
            }

            System.Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nLocation: {player.Current_Location.Name}");
            Console.WriteLine("        SB\n         |\n         S\n         |\n         T\n         |\n    F-CF-H-Y-B-BB\n         |\n         A\n         |\n         C");
            Console.WriteLine("-------------------------------");
            System.Console.WriteLine("Current location: " + player.Current_Location.Name);
            System.Console.WriteLine(player.Current_Location.Compass());
            System.Console.WriteLine("Where to go? N/E/S/W");
            System.Console.WriteLine("Map info: M");
            System.Console.WriteLine("Quit game: Q");
            string direction = Console.ReadLine().ToUpper();
            System.Console.Clear();

            // player choice
            // show info about map
            if (direction == "M") Location.Map();
            // quest log (what you have to do now/what you are doing)
            // if (direction == "L") quest log
            // quit game
            if (direction == "Q")
            {
                System.Console.WriteLine("Quitting game........");
                System.Console.ReadKey();
                break;
            }
            // game play
            else player.MoveTo(player.Current_Location.GetLocationAt(direction));

            // return home
            // can add new functionality to home if need be (inventory or crafting lol)
            if (player.Current_Location.ID == 1)
            {
                // if already player been  return_home = true so next time home player can choose to heal

                while (return_home)
                {
                    return_home = true;
                    // player can choose to heal up or leave home
                    System.Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nLocation: {player.Current_Location.Name}");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Welcome back home do you want to go to bed?: (Y/N)");
                    string Bed = Console.ReadLine().ToUpper();

                    if (Bed == "Y")
                    {
                        Console.WriteLine("snooze snooze");
                        // insert heal up
                        return_home = false;
                        home = false;

                    }
                    else if (Bed == "N")
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Leaving home......");
                        Console.WriteLine("-------------------------------");
                        return_home = false;
                        home = false;
                    }
                    else
                    {
                        Console.WriteLine("invalid answer.");
                    }


                }
                //  when here is check point. health back to max 

            }

            // town hall
            if (player.Current_Location.ID == 2)
            {
                System.Console.WriteLine(player.Current_Location.Description);
                // no weapon
                if (quest_blacksmith_garden == false)
                {
                    // mayor tells u about quest to get to the blacksmith
                    // gives weapon
                    System.Console.WriteLine();
                    blacksmith_yard = true;
                    reward_mayor = true;
                }
                //  yes weapon
                else if (reward_mayor)
                {
                    System.Console.WriteLine("The mayor is grateful you want to help the town.");
                }
            }

            // blacksmith yard
            if (player.Current_Location.ID == 3)
            {
                // you go to the blacksmith garden, you have seen the mayor, and haven't finished the cockroach fight
                if (blacksmith_yard && quest_blacksmith_garden == false)
                {
                    System.Console.WriteLine("You see huge cockroaches in the garden.");
                    System.Console.WriteLine("Do you try to kill them? (Y/N) ");
                    string user_answer = Console.ReadLine().ToLower();
                    // you choose to fight the roaches
                    if (user_answer == "y")
                    {
                        // fight roaches
                        // if win blacksmith = true and quest_blacksmith_garden = true
                        Quest.StartQuest(1, 1, 3, player);
                        blacksmith = true;
                        quest_blacksmith_garden = true;
                        //  else stay false and die or respawn.
                    }
                    // you do not choose to fight
                    else
                    {
                        // go back home
                        Console.WriteLine("Nothing to find here right now. Time to go back home...");
                        player.Current_Location = World.Locations[0];
                    }
                }
                //  you go to the garden and have been by the mayor, and have killed the roaches
                else if (quest_blacksmith_garden)
                {
                    System.Console.WriteLine("You return to the blacksmiths garden.");
                    System.Console.WriteLine("There are no more cockroaches.");
                }
                //  have not been by the mayor
                else if (blacksmith_yard == false)
                {
                    System.Console.WriteLine("You need to find a weapon to go here.");
                    // go back home
                    player.Current_Location = World.Locations[0];
                }
            }

            // blacksmith
            if (player.Current_Location.ID == 4)
                // you killed the cockroaches but don't have the blacksmiths items yet
                if (quest_blacksmith_items == false)
                {
                    System.Console.WriteLine("The blacksmith thanks you for killing the monsters in hig garden.");
                    System.Console.WriteLine("He asks you to find his tools in his basement.");
                    System.Console.WriteLine("He says he'll give you a better sword if you do.");
                    blacksmith_basement = true;

                }
                // you give the items to the blacksmith and he gives a better sword
                else if (reward_blacksmith == false)
                {
                    System.Console.WriteLine("You give the tools, the blacksmith smiles.");
                    // you get better weapon
                    System.Console.WriteLine("The blacksmith gives you a better sword.");
                    reward_blacksmith = true;
                    System.Console.WriteLine("He tells you about an alchemist that lives near that could give you potions for battle.");
                    alchemist_tower = true;
                }
                // you gave the items and he gave sword
                else if (reward_blacksmith)
                {
                    System.Console.WriteLine("The blacksmith just kind of stares at you weirdly.");
                    System.Console.WriteLine("He keeps talking about a mean alchemist that lives south of him.");
                    System.Console.WriteLine("You think about leaving.");
                }

            // blacksmith basement
            if (player.Current_Location.ID == 5)
            {
                // "mini game" look for items in boxes. you find weird shit and in one of the boxes you find 
                // maybe switch statements
                Quest.StartQuest(2, 0, 4, player);
                // when correct box found
                quest_blacksmith_items = true;
            }

            if (player.Current_Location.ID == 6)
            {
                // you haven't given the items to the blacksmith yet
                if (alchemist_tower == false)
                {
                    System.Console.WriteLine("You knock on the door. Someone yells at you.");
                    System.Console.WriteLine("You decide to go back home");
                    player.Current_Location = World.Locations[0];
                }
                // you've given the items to the blacksmith but you don't have the alchemists items yet
                else if (quest_alchemists_items == false)
                {
                    System.Console.WriteLine("You hear the alchemist inside.\nHe sounds upset.");
                    System.Console.WriteLine("You hear him say something about a goblin and his stuff.");
                    System.Console.WriteLine("His muttering about a nearby cave gives you the idea to go there and try to get his stuff back.");
                    System.Console.WriteLine("You hope this will make him want to talk to you.");
                    cave = true;
                }
                // you defeated the loot goblin and you're returning their items
                else if (quest_alchemists_items && reward_alchemist == false)
                {
                    // you get the alchemists items from the cave
                    System.Console.WriteLine("You knock on the door.\nA small peep hole opens.");
                    System.Console.WriteLine("The alchemist starts yelling at you.\nYou show the bag you took from the loot goblin.");
                    System.Console.WriteLine("They stop yelling.\nThe door slightly opens.\nYou hear the alchemist say \"I'll give you some potions for the bag\"");
                    System.Console.WriteLine("You agree.\nThey say \"Don't come back here, if you want more stuff go to the shop.\"");
                    // you get potions
                    reward_alchemist = true;
                    shop = true;
                }
                // you've given the items to the alchemist
                else if (reward_alchemist)
                {
                    System.Console.WriteLine("You knock on the door.\nYou hear humming.\nThe door doesn't open");
                    player.Current_Location = World.Locations[0];
                }
            }

            // cave
            if (player.Current_Location.ID == 7)
            {

                // choose from 3 ways to find the goblin
                // n = back to cave
                // s = you hear rustling its the goblin looking in his bag, jou fight him
                quest_alchemists_items = true;
                Quest.StartQuest(3, 2, 7, player);
                // w = you don't hear a lot, dead end
                // e = you hear what sounds like chatter = a whole lotta bats (we can do another fight or run away)
            }

            //shop
            if (player.Current_Location.ID == 8)
            {
                // alchemists quest has net been done
                if (shop == false)
                {
                    System.Console.WriteLine("There is a sign on the door.\nIt reads");
                    System.Console.WriteLine("Out Getting Things\nWill Be Back Later.");
                    player.Current_Location = World.Locations[1];
                }
                else if (shop)
                {
                    System.Console.WriteLine("You enter the shop.\nYou see a weird looking thing behind the counter.");
                    System.Console.WriteLine("The thing starts talking \"Welcome to my sh\"");
                    System.Console.WriteLine("While he's talking you hear strange sounds coming from his basement.\nHe kind of looks embarrassed.");
                    System.Console.WriteLine("You decide to go look down there.\nThe creature looks at you but doesn't say anything.");
                    shop_basement = true;

                }
            }
            // shop basement 
            if (player.Current_Location.ID == 9)
            {

                if (shop_basement)
                {
                    // puzzle/quest om slot te openen en de halflings te bevrijden
                    Console.WriteLine("You go down stairs and see halflings in cages..\nYou sigh and look at the shop keeper");
                    Console.WriteLine("You try to open the cages however, there's a special lock holding them in the cell.");
                    Console.WriteLine("Complete the puzzle to save the halflings.....");
                    Quest.StartQuest(4, 0, 9, player);
                    // if quest completed then shop basement false Y om door te gaan
                    string test_doorgang = Console.ReadLine();
                    if (test_doorgang == "Y")
                    {
                        reward_shopkeeper = true;
                    }

                }

            }
            // campfire
            if (player.Current_Location.ID == 10)
            {
                Console.WriteLine("In the clearing of the forest you spot a faint light with several shadows around it.");
                Console.WriteLine("You approach the campfire.\nYou spot fellow villagers taking a break from the chaos all around.");
                Console.WriteLine("This is a safe haven. The campfire has healing properties.\nHolding your hands near the fire will heal you up for battle;");
                Console.WriteLine("-------------------------------");

                bool campfire_heal = true;
                while (campfire_heal)
                {
                    Console.WriteLine("Would you like to heal up? (Y/N)");
                    string campfire_choice = Console.ReadLine().ToUpper();
                    Console.Clear();
                    if (campfire_choice == "Y")
                    {
                        // heal player
                        Console.WriteLine("player healed");
                        campfire_heal = false;
                    }
                    else if (campfire_choice == "N")
                    {

                        Console.WriteLine("healing rejected");
                        campfire_heal = false;

                    }
                    else
                    {
                        Console.WriteLine("invalid input (Y/N)");
                    }
                }
            }

            // aragog 
            if (player.Current_Location.ID == 11)
            {
                quest_aragog = true;
                Console.WriteLine("Aragog lives here");
                Quest.StartQuest(5, 3, 11, player);
                bool beaten_aragog = true;
            }
            if (player.Current_Location.ID == 1 && quest_aragog == true)
            {
                System.Console.WriteLine("YOU DID IT.\n You have beaten aragog.\nReturn home to ");
                running = false;
            }

        }
    }
}