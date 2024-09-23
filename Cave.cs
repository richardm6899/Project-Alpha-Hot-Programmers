using System.Runtime.InteropServices;

public class Cave
{
    public int ID;
    public string Name;
    public Monster MonsterLivingHere;
    public Cave LocationToNorth;
    public Cave LocationToEast;
    public Cave LocationToSouth;
    public Cave LocationToWest;

    public Cave(int id, string name, Monster monster)
    {
        this.ID = id;
        this.Name = name;
        this.MonsterLivingHere = monster;
    }
}


