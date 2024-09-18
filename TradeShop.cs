

//  The player must be able to buy items with currency they have received from quests or other ventures. - oli
//  The player must be able to sell inventory items they have received from quests or other ventures. - oli
//  The player must be able to enter and leave the shop while travelling. - oli
//  The player gets an overview of what the player can buy and sell. (preview of inventory)
//  The player can only buy and sell what he can afford.

class TradeShop
{
    public Player player; 
    
    public TradeShop(Player playa)
    {
        player = playa;

    }
    
    public void TradeShopOG()
    {
        bool running_shop = true;
        bool Trading = false;
        bool Buying = true;

        while (running_shop)
        {
            Console.WriteLine("Hello and welcome to Sir Hubert Albert the third's trade shop.");
            Console.WriteLine("We sell and buy, potions and weapons to help you on your quest.");
            Console.WriteLine("Would you like to (B)uy or (T)rade?: (B/T)");
            string choice = Console.ReadLine();
            {
                if(choice == "T")
                {
                    Trading = true;
                    while (Trading)
                    {
                        Console.WriteLine("What item would you like to Trade for currency. Give a number. (id)");
                        int trade_id = Convert.ToInt32(Console.ReadLine());
                    }
                }
                else if (choice== "B")
                {
                    Buying = true;
                    while (Buying)
                    {
                        Console.WriteLine("What item would you like to Buy for currency. Give a number. (id)");
            
                        int trade_id = Convert.ToInt32(Console.ReadLine());
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    
    }
    
}