using System.Collections;
using System.Security.Cryptography.X509Certificates;

public static class World
{

    // make lists
    public static readonly List<Consumable> Consumables = new List<Consumable>();
    public static readonly List<Weapon> Weapons = new List<Weapon>();
    public static readonly List<Monster> Monsters = new List<Monster>();
    public static readonly List<Quest> Quests = new List<Quest>();
    public static readonly List<Location> Locations = new List<Location>();
    public static readonly Random RandomGenerator = new Random();
    public static readonly List<Cave> Caves = new List<Cave>();

    //potion ids

    public const int CONSUMABLE_ID_APPLE = 1;
    public const int CONSUMABLE_ID_HEALTH_POTION = 2;
    public const int CONSUMABLE_ID_STRENGTH = 3;
    public const int CONSUMABLE_ID_POTATO = 4;
    public const int CONSUMABLE_ID_DEFENSE_POTION = 5;
    public const int CONSUMABLE_ID_GREATER_DEFENSE_POTION = 6;

    // weapon ids
    public const int WEAPON_ID_RUSTY_SWORD = 1;
    public const int WEAPON_ID_CLUB = 2;
    public const int WEAPON_ID_CLOWN_HAMMER = 3;
    public const int WEAPON_ID_LONG_SWORD = 4;
    public const int WEAPON_ID_EXCALIBUR = 5;
    public const int WEAPONS_ID_BOW = 6;
    public const int Weapon_ID_FIST = 7;

    // monster ids
    public const int MONSTER_ID_COCKROACH = 1;
    public const int MONSTER_ID_LOOT_GOBLIN = 2;
    public const int MONSTER_ID_ARAGOG = 3;

    // quest ids
    public const int QUEST_ID_CLEAR_BLACKSMITH_GARDEN = 1;
    public const int QUEST_ID_BLACKSMITHS_ITEMS = 2;
    public const int QUEST_ID_ALCHEMISTS_ITEMS = 3;
    public const int QUEST_ID_SAVE_HALFLINGS = 4;
    public const int QUEST_ID_ARAGOG = 5;

    //  location ids
    public const int LOCATION_ID_HOME = 1;
    public const int LOCATION_ID_TOWN_HAll = 2;
    public const int LOCATION_ID_BLACKSMITH_YARD = 3;
    public const int LOCATION_ID_BLACKSMITH = 4;
    public const int LOCATION_ID_BLACKSMITH_BASEMENT = 5;
    public const int LOCATION_ID_ALCHEMIST_TOWER = 6;
    public const int LOCATION_ID_CAVE = 7;
    public const int LOCATION_ID_SHOP = 8;
    public const int LOCATION_ID_SHOP_BASEMENT = 9;
    public const int LOCATION_ID_CAMPFIRE = 10;
    public const int LOCATION_ID_FOREST = 11;

    // cave ids

    public const int LOCATION_ID_CAVE_1 = 12;
    public const int LOCATION_ID_CAVE_2 = 13;
    public const int LOCATION_ID_CAVE_3 = 14;
    public const int LOCATION_ID_CAVE_4 = 15;
    public const int LOCATION_ID_CAVE_5 = 16;
    public const int LOCATION_ID_CAVE_GOBLIN = 17;
    public const int LOCATION_ID_CAVE_ITEM = 18;
    public const int LOCATION_ID_CAVE_SNAKE = 19;


    // call methods to add everything to the made lists
    static World()
    {
        PopulateWeapons();
        PopulateMonsters();
        PopulateQuests();
        PopulateLocations();
        PopulateConsumables();
    }


    public static void PopulateConsumables()
    {

        Consumables.Add(new Consumable(CONSUMABLE_ID_APPLE, "Apple", 1, "h", 1));
        Consumables.Add(new Consumable(CONSUMABLE_ID_HEALTH_POTION, "Health Potion", 10, "h", 3));
        Consumables.Add(new Consumable(CONSUMABLE_ID_STRENGTH, "Strength Potion", 1, "p", 5));
        Consumables.Add(new Consumable(CONSUMABLE_ID_POTATO, "Potato", 5, "h", 2));
        Consumables.Add(new Consumable(CONSUMABLE_ID_DEFENSE_POTION, "Defense Potion", 1, "d", 20));
        Consumables.Add(new Consumable(CONSUMABLE_ID_GREATER_DEFENSE_POTION, "Greater Defense Potion", 2, "d", 50));


    }
    //  add weapons to the weapons list 
    public static void PopulateWeapons()
    {
        // id
        // name
        // max damage

        Weapons.Add(new Weapon(Weapon_ID_FIST, "Fist", 1, 0));
        Weapons.Add(new Weapon(WEAPON_ID_RUSTY_SWORD, "Rusty sword", 10, 5));
        Weapons.Add(new Weapon(WEAPON_ID_CLUB, "Sword", 15, 7));
        Weapons.Add(new Weapon(WEAPON_ID_CLOWN_HAMMER, "Clown Hammer", 3, 3));
        Weapons.Add(new Weapon(WEAPON_ID_LONG_SWORD, "Long sword", 20, 8));
        Weapons.Add(new Weapon(WEAPON_ID_EXCALIBUR, "Excalibur", 10000, 1000000000));
        Weapons.Add(new Weapon(WEAPONS_ID_BOW, "Bow", 25, 15));

    }


    //  add monsters to the monsters lits
    public static void PopulateMonsters()
    {
        // id
        // name
        // max damage
        // current health
        // max health
        Monster cockroach = new Monster(MONSTER_ID_COCKROACH, "cockroach", 5, 25, 25);


        Monster lootGoblin = new Monster(MONSTER_ID_LOOT_GOBLIN, "loot goblin", 10, 50, 50);


        Monster aragog = new Monster(MONSTER_ID_ARAGOG, "Aragog", 25, 100, 100);


        Monsters.Add(cockroach);
        Monsters.Add(lootGoblin);
        Monsters.Add(aragog);
    }


    //  add quests to the quest list
    public static void PopulateQuests()
    {
        // id
        // name
        // description
        Quest clearBlacksmithGarden =
            new Quest(
                QUEST_ID_CLEAR_BLACKSMITH_GARDEN,
                "Go to the blacksmith to upgrade sword",
                "Kill cockroaches in the blacksmith's garden. "
                );

        Quest blacksmithsItems =
            new Quest(
                QUEST_ID_BLACKSMITHS_ITEMS,
                "The blacksmith couldn't find his tools.",
                "Go to the basement to get them for him"
                );


        Quest clearCave =
            new Quest(
                QUEST_ID_ALCHEMISTS_ITEMS,
                "A goblin took the alchemists supplies",
                "Get them back and slay the goblin"
                );


        Quest saveHalflings =
            new Quest(
                QUEST_ID_SAVE_HALFLINGS,
                "You see the halflings in cages",
                "Get them out"
                );


        Quest clearForest =
            new Quest(
                QUEST_ID_ARAGOG,
                "Get rid of the clicking sounds in the forest",
                "Kill Aragog"
                );


        Quests.Add(clearBlacksmithGarden);
        Quests.Add(blacksmithsItems);
        Quests.Add(clearCave);
        Quests.Add(saveHalflings);
        Quests.Add(clearForest);
    }


    //  add locations to the locations list
    public static void PopulateLocations()
    {
        // Create each location
        Location home = new Location(LOCATION_ID_HOME, "Home", "You really need to clean up the place.", null, null);

        Location townHall = new Location(LOCATION_ID_TOWN_HAll, "Town square", "You see a scared Mayor.", null, null);
        townHall.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_BLACKSMITH_GARDEN);

        Location alchemistTower = new Location(LOCATION_ID_ALCHEMIST_TOWER, "Alchemist's tower", "The alchemist really doesn't want you here.", null, null);
        alchemistTower.QuestAvailableHere = QuestByID(QUEST_ID_ALCHEMISTS_ITEMS);

        Location cave = new Location(LOCATION_ID_CAVE, "Cave", "It's cold and moist in here.", null, null);

        Location blacksmithYard = new Location(LOCATION_ID_BLACKSMITH_YARD, "Blacksmith's yard", "It doesn't look so nice.", null, null);
        blacksmithYard.MonsterLivingHere = MonsterByID(MONSTER_ID_COCKROACH);

        Location blacksmith = new Location(LOCATION_ID_BLACKSMITH, "Blacksmith", "You see the blacksmith sitting next to a fire", null, null);
        blacksmith.QuestAvailableHere = QuestByID(QUEST_ID_BLACKSMITHS_ITEMS);

        Location blacksmithBasement = new Location(LOCATION_ID_BLACKSMITH_BASEMENT, "blacksmith's basement", "It's dark. There's a lot of stuff down here.", null, null);

        Location shop = new Location(LOCATION_ID_SHOP, "Shop", "There are things all around you.", null, null);
        shop.QuestAvailableHere = QuestByID(QUEST_ID_SAVE_HALFLINGS);

        Location shopBasement = new Location(LOCATION_ID_SHOP_BASEMENT, "Shop basement", "You see cages.", null, null);

        Location campFire = new Location(LOCATION_ID_CAMPFIRE, "Campfire", "You find a campfire, you rest", null, null);

        Location forest = new Location(LOCATION_ID_FOREST, "Forest", "A monster!", null, null);
        forest.QuestAvailableHere = QuestByID(QUEST_ID_ARAGOG);
        forest.MonsterLivingHere = MonsterByID(MONSTER_ID_ARAGOG);

        // cave locations
        Location cave_1 = new Location(LOCATION_ID_CAVE_1, "Cave 1", "Cave room", null, null);

        Location cave_2 = new Location(LOCATION_ID_CAVE_2, "Cave 2", "Cave chamber", null, null);

        Location cave_3 = new Location(LOCATION_ID_CAVE_3, "Cave 3", "Cave hall", null, null);

        Location cave_4 = new Location(LOCATION_ID_CAVE_4, "Cave 4", "Cave place", null, null);

        Location cave_5 = new Location(LOCATION_ID_CAVE_5, "Cave 5", "Cave bedroom", null, null);

        Location cave_goblin = new Location(LOCATION_ID_CAVE_GOBLIN, "Cave goblin", "Cave goblin", null, null);
        cave_goblin.MonsterLivingHere = MonsterByID(MONSTER_ID_LOOT_GOBLIN);

        Location cave_item = new Location(LOCATION_ID_CAVE_ITEM, "Cave item", "Cave Item", null, null);

        Location cave_snake = new Location(LOCATION_ID_CAVE_SNAKE, "Cave snake", "Cave Snake", null, null);

        // Link the locations together
        home.LocationToNorth = townHall;
        home.LocationToEast = blacksmithYard;
        home.LocationToSouth = alchemistTower;
        home.LocationToWest = campFire;

        townHall.LocationToNorth = shop;
        townHall.LocationToSouth = home;

        shop.LocationToNorth = shopBasement;
        shop.LocationToSouth = home;

        shopBasement.LocationToSouth = shop;

        blacksmithYard.LocationToEast = blacksmith;
        blacksmithYard.LocationToWest = home;

        blacksmith.LocationToEast = blacksmithBasement;
        blacksmith.LocationToWest = blacksmithYard;

        blacksmithBasement.LocationToWest = blacksmith;

        alchemistTower.LocationToNorth = home;
        alchemistTower.LocationToSouth = cave;

        cave.LocationToNorth = alchemistTower;

        campFire.LocationToEast = home;
        campFire.LocationToWest = forest;

        forest.LocationToEast = campFire;


        // link cave locations
        cave_1.LocationToNorth = cave_item;
        cave_1.LocationToWest = cave_3;
        cave_1.LocationToEast = cave_2;

        cave_2.LocationToEast = cave_snake;
        cave_2.LocationToWest = cave_1;

        cave_3.LocationToNorth = cave_4;
        cave_3.LocationToEast = cave_1;

        cave_4.LocationToWest = cave_goblin;
        cave_4.LocationToEast = cave_item;
        cave_4.LocationToSouth = cave_3;

        cave_5.LocationToSouth = cave_item;

        cave_goblin.LocationToEast = cave_4;

        cave_item.LocationToNorth = cave_5;
        cave_item.LocationToSouth = cave_1;
        cave_item.LocationToWest = cave_4;

        cave_snake.LocationToWest = cave_2;

        // Add the locations to the static list
        Locations.Add(home);  // Locations[0]
        Locations.Add(townHall);  // Locations[1]
        Locations.Add(alchemistTower);  // Locations[2]
        Locations.Add(cave);// Locations[3]
        Locations.Add(blacksmithYard);// Locations[4]
        Locations.Add(blacksmith);// Locations[5]
        Locations.Add(blacksmithBasement);// Locations[6]
        Locations.Add(shop);// Locations[7]
        Locations.Add(shopBasement);// Locations[8]
        Locations.Add(campFire);// Locations[9]
        Locations.Add(forest);// Locations[10]

        // add cave locations
        Locations.Add(cave_1);// Locations[11]
        Locations.Add(cave_2);// Locations[12]
        Locations.Add(cave_3);// Locations[13]
        Locations.Add(cave_4);// Locations[14]
        Locations.Add(cave_5);// Locations[15]
        Locations.Add(cave_goblin);// Locations[16]
        Locations.Add(cave_item);// Locations[17]
        Locations.Add(cave_snake);// Locations[18]
    }



    //  get a location by the id
    public static Location LocationByID(int id)
    {
        foreach (Location location in Locations)
        {
            if (location.ID == id)
            {
                return location;
            }
        }

        return null;
    }

    public static Consumable ConsumableByID(int id)
    {
        foreach (var consumable in Consumables)
        {
            if (consumable.ID == id)
            {
                return consumable;
            }
        }

        return null;
    }

    //  get weapon by the id
    public static Weapon WeaponByID(int id)
    {
        foreach (Weapon item in Weapons)
        {
            if (item.ID == id)
            {
                return item;
            }
        }

        return null;
    }



    public static Monster MonsterByID(int id)
    {
        foreach (Monster monster in Monsters)
        {
            if (monster.ID == id)
            {
                return monster;
            }
        }

        return null;
    }

    //  get quest by the id
    public static Quest QuestByID(int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.ID == id)
            {
                return quest;
            }
        }

        return null;
    }
}