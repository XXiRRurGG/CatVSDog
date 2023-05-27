using System.IO;
using System.Media;
using System;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
using NAudio.Wave;
namespace CatVsDog
{
    static class Players
    {
        public static Player dog = new Player();
        public static Player cat = new Player();
    }
    class Program
    {
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public static void FillDeque(DoubleLinkedList Deque)
        {
            string[] cardNames = { "Scratch", "Lick", "Long tongue", "Dust in eyes", "Punch", "Catnip", "Sharp claws", "Rest", "Attentiveness" };
            string[] cardAttributes = { "DMG", "Heal", "HealMtp", "Skip", "DMG", "Heal", "DMGMultiplier", "Stamina", "Dodge" };
            double[] cardValues = { 8, 3, 2.1, 2, 5, 5, 2.1, 2, 1 };
            Dictionary<string, int> cardsType = new Dictionary<string, int>();
            Dictionary<string, bool> availableCards = new Dictionary<string, bool>();
            availableCards["DMG"] = false;
            availableCards["DMGMultiplier"] = false;
            availableCards["Heal"] = false;
            availableCards["HealMtp"] = false;
            availableCards["Stamina"] = false;
            availableCards["Dodge"] = false;
            availableCards["Skip"] = false;
            for (int i = 0; i < 53; i++)
            {
                var rand = new Random();
                int index = rand.Next(0, cardAttributes.Length);
                if (cardsType.ContainsKey("DMG"))
                    if (cardsType["DMG"] == 19)
                    {
                        availableCards["DMG"] = true;
                    }
                if (cardsType.ContainsKey("Heal"))
                    if (cardsType["Heal"] == 9)
                    {
                        availableCards["Heal"] = true;
                    }
                if (cardsType.ContainsKey("DMGMultiplier"))
                    if (cardsType["DMGMultiplier"] == 5)
                    {
                        availableCards["DMGMultiplier"] = true;
                    }
                if (cardsType.ContainsKey("HealMtp"))
                    if (cardsType["HealMtp"] == 5)
                    {
                        availableCards["HealMtp"] = true;
                    }
                if (cardsType.ContainsKey("Skip"))
                    if (cardsType["Skip"] == 5)
                    {
                        availableCards["Skip"] = true;
                    }
                if (cardsType.ContainsKey("Dodge"))
                    if (cardsType["Dodge"] == 5)
                    {
                        availableCards["Dodge"] = true;
                    }
                if (cardsType.ContainsKey("Stamina"))
                    if (cardsType["Stamina"] == 5)
                    {
                        availableCards["Stamina"] = true;
                    }
                if (availableCards[cardAttributes[index]] == false)
                {
                    if (!cardsType.ContainsKey(cardAttributes[index]))
                        cardsType.Add(cardAttributes[index], 0);
                    cardsType[cardAttributes[index]]++;
                    Card temp = new Card();
                    Deque.Add(temp);
                    Deque[i].Name = cardNames[index];
                    Deque[i].Attribute = cardAttributes[index];
                    Deque[i].Value = cardValues[index];
                }

                else
                {
                    while (availableCards[cardAttributes[index]] != false)
                    {
                        index = rand.Next(0, cardAttributes.Length);
                        if (availableCards.ContainsKey(cardAttributes[index]))
                            if (availableCards[cardAttributes[index]] == false)
                            {
                                if (!cardsType.ContainsKey(cardAttributes[index]))
                                    cardsType.Add(cardAttributes[index], 0);
                                cardsType[cardAttributes[index]]++;
                                Card temp = new Card();
                                Deque.Add(temp);
                                Deque[i].Name = cardNames[index];
                                Deque[i].Attribute = cardAttributes[index];
                                Deque[i].Value = cardValues[index];
                            }
                    }
                }
            }
        }
        static void Main()
        {
            string a = "avc";
            if(a[0]=='a')
            {

            }

            DoubleLinkedList Deque = new DoubleLinkedList();
            FillDeque(Deque);
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\OhNoTheDogKilledMe.wav";
            player.Play();
            player.PlayLooping();

            Console.BufferHeight = 1000;
            Console.BufferWidth = 1000;
            

            Players.cat.Name = "Cat";
            Players.dog.Name = "Dog";
            Players.cat.DrawCard(ref Deque);
            Players.cat.DrawCard(ref Deque);
            Players.cat.DrawCard(ref Deque);
            Players.dog.DrawCard(ref Deque);
            Players.dog.DrawCard(ref Deque);
            Players.dog.DrawCard(ref Deque); 
            while (true)
            {
                UI.PrintStats();
                UI.PrintPlayers();
                Players.cat.Discard();
                Players.dog.Discard();
                UI.PrintHand();
                UI.PrintMenu();
                Players.cat.BattleLog();
                Players.dog.BattleLog();
                Players.cat.ResetStatsAfterRound();
                Players.dog.ResetStatsAfterRound();

                int choice = 0; 
                int cardsToDraw = 3;
                while (choice != 2)
                {
                    choice = Convert.ToInt32(Console.ReadLine());       
                    switch (choice)
                    {
                        case 1:
                            {
                                if (Players.cat.GetNumberOfCards() <= 0)
                                {
                                    Console.WriteLine("You don't have any more cards");
                                    Players.cat.AddToLog("You don't have any more cards");
                                }
                                else
                                {
                                    Console.WriteLine("Enter number of card you want to use");
                                    int cardIndex = Convert.ToInt32(Console.ReadLine()) -1;
                                    if (cardIndex > Players.cat.GetNumberOfCards() - 1 || cardIndex < 0)
                                    {
                                        while (cardIndex > Players.cat.GetNumberOfCards() - 1 || cardIndex < 0)
                                        {
                                            Console.WriteLine("Wrong input, try again");
                                            cardIndex = Convert.ToInt32(Console.ReadLine()) -1;
                                        }
                                    }
                                    Players.cat.UseCard(cardIndex, Players.dog);
                                    if (Players.dog.GetHealth() <= 0)
                                    {
                                        Console.Clear();
                                        UI.CatWins();
                                        UI.PrintWinner("Cat");
                                        Console.ReadKey();
                                        return;
                                    }
                                }
                                    break;  
                            }
                        case 2:
                            {
                                Console.WriteLine("You have finished your move");
                                Players.cat.AddToLog("You have finished your move");
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                UI.DogWins();
                                UI.PrintWinner("Dog");
                                Console.ReadKey();
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong input,try again");
                                break;
                            }
                    }
                    Console.Clear();    
                    UI.PrintStats();
                    UI.PrintPlayers();
                    UI.PrintHand();
                    UI.PrintMenu();
                    Players.cat.BattleLog();
                }
                Players.dog.DogFighting(ref Deque);
                if(Players.cat.GetHealth()<=0)
                {
                    Console.Clear();
                    UI.DogWins();
                    UI.PrintWinner("Dog");
                    Console.ReadKey();
                    return;
                }
                if(Deque.Count() == 0)
                {
                    FillDeque(Deque);
                }
                Players.cat.DrawCard(ref Deque);
                Players.cat.DrawCard(ref Deque);
                Players.cat.DrawCard(ref Deque);
                Players.dog.DrawCard(ref Deque);
                Players.dog.DrawCard(ref Deque);
                Players.dog.DrawCard(ref Deque);
                Console.Clear();
            }
        }
    }
}