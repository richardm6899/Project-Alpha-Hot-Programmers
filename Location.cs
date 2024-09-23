public class Location
{
    public int ID;

    public string Name;

    public string Description;

    public Quest QuestAvailableHere;
    
    public Monster MonsterLivingHere;
    public Location LocationToNorth;
    public Location LocationToEast;
    public Location LocationToSouth;
    public Location LocationToWest;

    public Location(int id, string name, string description, Quest quest, Monster fight)
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
        this.QuestAvailableHere = quest;
        this.MonsterLivingHere = fight;
    }

    public string Compass()
    {
        //Settings > Debug > Console: Collapse Identical Lines
        string s = "From here you can go:\n";
        if (LocationToNorth != null)
        {
            s += "    N\n    |\n";
        }
        if (LocationToWest != null)
        {
            s += "W---|";
        }
        else
        {
            s += "    |";
        }
        if (LocationToEast != null)
        {
            s += "---E";
        }
        s += "\n";
        if (LocationToSouth != null)
        {
            s += "    |\n    S\n";
        }
        return s;
        }

    public Location GetLocationAt(string location)
    {
        if (location == "N") return LocationToNorth;
        if (location == "E") return LocationToEast;
        if (location == "S") return LocationToSouth;
        if (location == "W") return LocationToWest;
        return null;
    }

    public static void Map()
    {
        System.Console.WriteLine("H - Home");
        System.Console.WriteLine("T - Town hall");
        System.Console.WriteLine("BY - Blacksmith Yard");
        System.Console.WriteLine("B - Blacksmith");
        System.Console.WriteLine("BB - Blacksmith Basement");
        System.Console.WriteLine("A - Alchemist tower");
        System.Console.WriteLine("C - Cave");
        System.Console.WriteLine("S - Shop");
        System.Console.WriteLine("SB - Shop Basement");
        System.Console.WriteLine("CF - CampFire");
        System.Console.WriteLine("F - Forest");
    }
}