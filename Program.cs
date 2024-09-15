//     public static void Main()
//     {
//         bool menu = false;
//         bool test = true;
//         // ------------------------------- menu
//         while (menu)
//         {
//             Console.WriteLine("hi welcome to ");
//             Console.WriteLine("press enter to continue");
//             Console.ReadLine();
//             menu = false;
//             home = true;

//         }
//         // ------------------------------ 1. home (H)
//         while (home)
//         {
//             Console.WriteLine("You just woke up?");
//             Console.WriteLine("You wake up, go down stairs, eat a meal, life is good.\nyou go outside, and see the town is fucked. what to do what to do.\nYou must reach the town hall to talk to the mayor");

//             string choice = Map("H");
//             Console.WriteLine(choice, "----------------");
//             if (choice == "T")
//             {
//                 home = false;
//                 town_hall = true;

//             }
//             else
//             {
//                 while (test)
//                 {
//                     Console.WriteLine("nothing going on here");
//                     string choice1 = Map(choice);
//                     if (choice1 == "T")
//                     {
//                         test = false;
//                         town_hall = false;
//                     }
//                     string choice2 = Map(choice1);
//                     Console.WriteLine($"you are at {choice2}------------------------------------------------");
//                     if (choice2 == "T")
//                     {
//                         test = false;
//                         town_hall = false;
//                     }
//                     string choice3= Map(choice2);
//                     Console.WriteLine($"you are at ----------------{choice3}------------------------------------------------");
//                     if (choice3 == "T")
//                     {
//                         test = false;
//                         town_hall = false;
//                     }

//                 }

//             }

//         }
//         //--------------------- 2.town hall ---- (acquire sword)(T)
//         while (town_hall)
//         {
//             Console.WriteLine("you go to the town hall to ask what is happening. \nthe mayor says the town was attacked, and he needs your help to hunt the thing in the forest. \nhe gives you a weapon, it sucks (rusty sword). he says you can go to the blacksmith to make it better.");
//             break;
//         }

//         // ------------------- 3.black smith yard ----- (cockroach fight)(BY)
//         while (blacksmith_yard)
//         {
//             Console.WriteLine("You go to the blacksmith. his front yard is being destroyed by huge cockroaches. u fight them.");
//         }
//         // -------------------- 4. enter blacksmith shop(B)
//         while (blacksmith)
//         {
//             Console.WriteLine("you kill them, you enter blacksmith shop .the blacksmith thanks you and ask for another favour. he will reward the second quest with a better sword. ");
//         }
//         // --------------------- 5. enter blacksmith basement(BB)
//         while (blacksmith_basement)
//         {
//             Console.WriteLine("he asks you to find an item from his cellar. You enter his cellar. \nhe says he heard clicking sound in the forest last night behind his house, he said not to go there until you're very strong. \nhe said the alchemist could give you potions.");
//         }
//         // ---------------------- 6. alchemist(A)
//         while (alchemist)
//         {
//             Console.WriteLine("you go to the alchemists house he wont open the door.\n he was robbed by the loot goblins that live in the cave behind his house.\n he says he wants his stuff back and then he might talk to you.");
//         }
//         // ---------------------- 7. cave (fight)(C)
//         while (cave)
//         {
//             Console.WriteLine("you go into the cold damp cave behind the alchemists tower.\n you don't wanna go inside, but u gotta. u go inside you're very cold. you hear chatter. \nyou round the corner and see a loot goblin looking into a bag. he hears you. \nhe runs towards u. u fight.");
//         }
//         // ---------------------- 8. alchemist return(A)
//         while (alchemist_2)
//         {
//             Console.WriteLine("You collect the bag and go back to the alchemist. \nHe lets you in, you can tell he actually doesn't want you here. he gives you stuffs and shoos you out of his house.\nHe says he doesn't want to see you again, if u want stuff go to the shop behind the town hall.\nDon't come back here.");
//         }
//         //  -------------------- 9. shop(s)
//         while (shop)
//         {
//             Console.WriteLine("go to behind the town hall to the shop. if you go to the blacksmith he will warn you to go to the shop to get some better stuff. talk to the shopkeeper. you hear screaming down stairs....");
//         }
//         // ---------------------- 10.shop basement (puzzle mini game)(SB)
//         while (shop_basement)
//         {
//             Console.WriteLine("he looks embarrassed. \nyou look disappointed.\n you go down stairs and see halflings in cages.\nyou sigh. you try to open the cages.\npuzzle mini game.");
//         }
//         // you can now buy stuff in shop(S)
//         // shop where you can engage with the shopkeeper
//         while (shop2)
//         {
//             Console.WriteLine("the shop keeper also talks about clicking sounds in the forest.\nhe says he's very scared of spiders.");
//         }
//         // ---------------------- 11.location forest(F)
//         while (forest)
//         {
//             Console.WriteLine("(location forest) go to the forest to kill aragog (end quest)");
//         }
//         // ----------------------- 12.campfire song song
//         while (campfire)
//         {

//         }


//     }
//
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
        Console.Clear();
        System.Console.WriteLine("Player starting stats:");

        System.Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nLocation: {player.Current_Location.Name}");
        Console.WriteLine("-------------------------------");
        System.Console.WriteLine("[enter]");
        System.Console.ReadKey();
        Console.Clear();
        while (running)
        {
            while (home) // first time coming home without ever moving /game intro
            {

                Console.WriteLine("Trrriiiing Triiiing.\nIts 9 AM. Time to start the day.\nAs you walk down your cat goerge greets you.");
                Console.WriteLine("Lovely morning isn't it. As you take your first look outside you see chaos and mayhem everywhere.");
                Console.WriteLine("Time to start and adventure.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("You need to reach the townhall(T) to meet the mayor.");
                Console.WriteLine("        SB\n         |\n         S\n         |\n         T\n         |\n    F-CF-H-Y-B-BB\n         |\n         A\n         |\n         C");
                Console.WriteLine("-------------------------------");
                System.Console.WriteLine("[enter]");
                System.Console.ReadKey();
                Console.Clear();
                home = false;
                return_home = true;
            }

            System.Console.WriteLine($"Name:{player.Name}\nHealth: {player.Current_Health}\nLocation: {player.Current_Location.Name}");
            Console.WriteLine("        SB\n         |\n         S\n         |\n         T\n         |\n    F-CF-H-Y-B-BB\n         |\n         A\n         |\n         C");
            Console.WriteLine("-------------------------------");
            System.Console.WriteLine("Current location: " + player.Current_Location.Name);
            System.Console.WriteLine(player.Current_Location.Compass());
            System.Console.WriteLine("Where to go?");
            string direction = Console.ReadLine().ToUpper();
            Console.Clear();
            player.MoveTo(player.Current_Location.GetLocationAt(direction));

            // return home
            // can add new functionality to home if need be (inventory or crafting lol)
            if (player.Current_Location.ID == 1)
            {
                // if already player been  return_home = true so next time home player can choose to heal

                while (return_home)
                {
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
                        Quest.StartQuest(1, 1, 3);
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
                Quest.StartQuest(2, 0, 4);
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
                Quest.StartQuest(3, 2, 7);
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
                    Quest.StartQuest(4, 0, 9);
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
                Quest.StartQuest(5, 3, 11);
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