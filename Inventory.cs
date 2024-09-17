public class Inventory
{
    public List<Weapon> WeaponInventory = new List<Weapon>();

    public List<Potion> PotionInventory = new List<Potion>();

    public void DisplayInventory()
    {
        Console.WriteLine($"You have {WeaponInventory.Count} weapons in your inventory");
        foreach(var weapon in WeaponInventory)
        {
            Console.WriteLine($"Weapon name: {weapon.Name}");
            Console.WriteLine($"Weapon damage: {weapon.Damage}");
        }
        Console.WriteLine($"You have {PotionInventory.Count} potions in your inventory");
        foreach(var potion in PotionInventory)
        {
            Console.WriteLine($"Consumable name: {potion.Name}");
        }
    }


}