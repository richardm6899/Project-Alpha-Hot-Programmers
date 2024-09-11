public class Quest
{
    public int ID;
    public string Name;
    public string Description;


    public Quest(int id, string name, string description)
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
    }

    /* There is a list of quests that need to be cleared, when starting going into a location with a quest,
    the player will be asked to start the quest which gets the Name of the quest ID to start from the list,
    the same would apply viceverse, if the player chooses to cancel, the quests gets the Name of the quest 
    The player can flee from a monster, cancelling the current quest by rolling a certain number on dice(random num).
    */

    // As a player I want to fight a monster to complete a quest

    public static void StartQuest(int questID, int monsterID, int LocationID)
    {
        Quest mission = World.QuestByID(questID); //Making object
        if (questID == 1)
        {
            Console.WriteLine("Clear Blacksmith Garden quest accepted");
            Console.WriteLine(mission.Name);
            Console.WriteLine(mission.Description);

        }
        else if (questID == 2)
        {
            Console.WriteLine("Collect Blacksmith items quest accepted");
        }
        else if (questID == 3)
        {
            Console.WriteLine("Collect Alchemist items quest accepted");
        }
        else if (questID == 4)
        {
            Console.WriteLine("Save Halflings quest accepted");
        }
        else if (questID == 5)
        {
            Console.WriteLine("Kill Aragog quest accepted");
        }
        else
        {
            Console.WriteLine("No quest available");
        }
    }
    public static bool CancelQuest()
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
