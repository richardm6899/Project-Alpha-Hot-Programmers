using System.ComponentModel.Design;
using System.Formats.Asn1;
using System.Reflection.PortableExecutable;
using System.Runtime;
using System.Runtime.CompilerServices;

public class Quest
{
    public int ID;
    public string Name;
    public string Description;

    public static bool victory1 = false;
    public static bool victory2 = false;
    public static bool victory3 = false;
    public static bool victory4 = false;
    public static bool victory5 = false;


    public Quest(int id, string name, string description)
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
    }




    // Enters location with a quest, user is asked if he wants to start, once started he must finish the quest.

    // public static void EnterLocationWithAQuest(int LocationID)
    // {
    //     Location location = World.LocationByID(LocationID);
    //     if (LocationID == 3)
    //     {
    //         Console.WriteLine("You have entered " + location.Name + ". Would you like to start the quest? (y/n)");
    //         string input = Console.ReadLine();
    //         if (input == "y")
    //         {
    //             StartQuest(1, 1, 3);
    //         }
    //         else
    //         {
    //             Dont_StartQuest();
    //         }
    //     }
    //     else if (LocationID == 5)
    //     {
    //         Console.WriteLine("You have entered " + location.Name + ". Would you like to start the quest? (y/n)");
    //         string input = Console.ReadLine();
    //         if (input == "y")
    //         {
    //             StartQuest(2, 2, 5);
    //         }
    //         else
    //         {
    //             Dont_StartQuest();
    //         }
    //     }
    //     else if (LocationID == 7)
    //     {
    //         Console.WriteLine("You have entered " + location.Name + ". Would you like to start the quest? (y/n)");
    //         string input = Console.ReadLine();
    //         if (input == "y")
    //         {
    //             StartQuest(3, 3, 7);
    //         }
    //         else
    //         {
    //             Dont_StartQuest();
    //         }
    //     }
    //     else if (LocationID == 9)
    //     {
    //         Console.WriteLine("You have entered " + location.Name + ". Would you like to start the quest? (y/n)");
    //         string input = Console.ReadLine();
    //         if (input == "y")
    //         {
    //             StartQuest(4, 4, 9);
    //         }
    //         else
    //         {
    //             Dont_StartQuest();
    //         }
    //     }
    //     else if (LocationID == 11)
    //     {
    //         Console.WriteLine("You have entered " + location.Name + ". Would you like to start the quest? (y/n)");
    //         string input = Console.ReadLine();
    //         if (input == "y")
    //         {
    //             StartQuest(5, 5, 11);
    //         }
    //         else
    //         {
    //             Dont_StartQuest();
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine("Wrong location ID");
    //     }
    // }


    // Notifies user he'll be returned to previous location
    // public static void Dont_StartQuest() //int questID, int monsterID, int LocationID
    // {
    //     Console.WriteLine("You'll be returned where you came from. Say when you are ready to start the quest.");
    //     //Implement logic to return to previous location
    // }


    // Starts quest and needs requirements in order to proceed, quests partly implemented, needs fight methods
    public static void StartQuest(int questID, int monsterID, int LocationID)
    {
        Quest mission = World.QuestByID(questID); //Making object
        Location location = World.LocationByID(LocationID);
        Monster monster = World.MonsterByID(monsterID);
        Player player = new Player("test", location);
        if (mission.ID == 1) // Blackmisth garden, location 3
        {
            Console.WriteLine("Clear Blacksmith Garden quest accepted");
            Console.WriteLine(mission.Name);
            Console.WriteLine(mission.Description);
            if (monster.ID == 1)
            {
                player.Fighting2(monster);
                //Introduce quest method logic
                if (monster.CurrentHitPoints <= 0)
                {
                    Console.WriteLine($"Return to the blacksmith for your reward and your next quest.");
                    victory1 = true; 
                }
                else
                {
                    Console.WriteLine("Don't give up!");
                    // must be in the statement above
                }
            }
            else
            {
                Console.WriteLine("Incorrect monster for this zone");
            }

        }
        else if (questID == 2 && victory1 == true) //Blackmisth, location 5
        {
            bool menu2 = true;
            Console.WriteLine("Collect Blacksmith items quest accepted");
            Console.WriteLine(mission.Name);
            Console.WriteLine(mission.Description);
            {
                while (menu2 == true)
                {
                    //Introduce quest method logic
                    Console.WriteLine("In order to collect the tools out you must answer the following riddle correctly");
                    Console.WriteLine("Which letter of the alphabet has the most water? (Type in the letter)");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "c")
                    {
                        Console.WriteLine("Correct! You've collected the tools. You received a reward that will aid you in the alchemist, where your next quest awaits.");
                        menu2 = false;
                        victory2 = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect. Try again.");
                    }
                }
            }
        }
        else if (questID == 3 && victory2 == true) // Quest in Alchemist, objective in cave, location 7
        {
            Console.WriteLine("Collect Alchemist items quest accepted");
            Console.WriteLine(mission.Name);
            Console.WriteLine(mission.Description);
            if (monster.ID == 2)
            {
                //Introduce quest method logic
                player.Fighting2(monster);
                if (monster.CurrentHitPoints <= 0)
                {
                    Console.WriteLine($"Return to the Alchemist for your reward and your next quest awaits in the shop basement.");
                    victory3 = true;
                }
                else
                {
                    Console.WriteLine("Don't give up!");
                }
            }
            else
            {
                Console.WriteLine("Incorrect monster for this zone");
            }
        }
        else if (questID == 4) // Shop basement, location 9
        {
            Console.WriteLine("Save Halflings quest accepted");
            Console.WriteLine(mission.Name);
            Console.WriteLine(mission.Description);
            bool menu1 = true;
            //Introduce quest method logic
            Console.WriteLine("In order to save the halflings out you must answer the following riddle correctly");
            while (menu1 == true)
            {
                Console.WriteLine("If the past is history, the future is mistery, today is a ...? That's why its called the present");
                string answer = Console.ReadLine().ToLower();
                if (answer == "gift")
                {
                    Console.WriteLine("Correct! The cages are now unlocked and the halflings are free. You received a reward that will help you in the forest, where your next quest awaits.");
                    menu1 = false;
                    victory4 = true;
                }
                else
                {
                    Console.WriteLine("Try again!");
                }
            }
        }
        else if (questID == 5 && victory4 == true) // Forest, location 11
        {
            Console.WriteLine("Kill Aragog quest accepted");
            Console.WriteLine(mission.Name);
            Console.WriteLine(mission.Description);
            if (monster.ID == 3)
            {
                //Introduce quest method logic
                player.Fighting2(monster);
                if (monster.CurrentHitPoints <= 0)
                {
                    Console.WriteLine($"The villagers now live in piece and harmony, maybe its time to go back to bed.");
                    victory5 = true;
                }
                else
                {
                    Console.WriteLine("Keep trying!");
                }
            }
            else
            {
                Console.WriteLine("Incorrect monster for this zone");
            }
        }
        else
        {
            Console.WriteLine("You must complete another quest to start this quest");
        }
    }

    // Generates a random number, if above 3, returns true, otherwise returns false
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
}
