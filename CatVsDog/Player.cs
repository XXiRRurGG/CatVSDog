using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatVsDog
{
    class Player
    {
        int numberOfCards;
        int health = 50;
        double dmgMultiplier = 1;
        double healMultiplier = 1;
        int numberOfCardsToSkip=0;
        int stamina = 3;
        int Dodge=0;
        string name;
        List<string> log = new List<string>();
        public Card[] hand = new Card[5];

        public int GetHealth() {  return health; }
        public int dodge
        {
            get { return Dodge; }
            set { Dodge = value; }  
        }
        public int Stamina
        {
            get { return stamina; }
            set { stamina = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void ResetStatsAfterRound()
        {
            dmgMultiplier = 1;
            healMultiplier = 1;
            stamina = 3;
            log.Clear();
        }
        public void Discard()
        {
            var rand = new Random();
            int index = rand.Next(0, 5);
            Card[] temp = new Card[5];
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                if (i != index)
                {
                    temp[counter] = hand[i];
                    counter++;
                }
            }
            hand = temp;
            numberOfCards--;
        }
        public void BattleLog()
        {
            foreach(var element in log)
            {
                Console.WriteLine(element);
            }
        }
        public void DrawCard(ref DoubleLinkedList Deque )
        {
            if(numberOfCardsToSkip>0)
            {
                numberOfCardsToSkip--;
                log.Add(String.Format("{1} has skipped 1 card,has to skip {0} more cards", numberOfCardsToSkip,Name));
                Console.WriteLine("{1} has skipped 1 card,has to skip {0} more cards", numberOfCardsToSkip,Name);
            }
            else
            {
                if(numberOfCards>=5)
                {
                    Console.WriteLine("{0} have full hand",Name);
                    log.Add(String.Format("{0} has full hand",Name));
                }
                else
                {
                    if (Deque.Count() == 0)
                    {
                        Console.WriteLine("Deque has ended");
                        log.Add("Deque has ended");
                        return;
                    }
                    else
                    {
                        hand[numberOfCards] = Deque[Deque.Count() - 1];
                        numberOfCards++;
                        Deque.RemoveAt(Deque.Count() - 1);
                    }
                }
            }
        }
        public void UseCard(int numberOfCard,Player enemy) 
        {
            if (numberOfCards > 0)
            {
                if (stamina > 0 && hand[numberOfCard].Attribute != "Stamina")
                {
                    switch (hand[numberOfCard].Attribute)
                    {
                        case "DMG":
                            {
                                if(enemy.Dodge==0)
                                enemy.health -= (int)Math.Round(hand[numberOfCard].Value * dmgMultiplier);
                                else
                                {
                                    string dodgeLog = String.Format("{0} has dodged", enemy.Name);
                                    log.Add(dodgeLog);
                                    Console.WriteLine(dodgeLog);
                                }
                                stamina--;
                                break;
                            }
                        case "Heal":
                            {
                                health += (int)Math.Round(hand[numberOfCard].Value * healMultiplier);
                                stamina--;
                                break;
                            }
                        case "HealMtp":
                            {
                                healMultiplier *= hand[numberOfCard].Value;
                                stamina--;
                                break;
                            }
                        case "DMGMultiplier":
                            {
                                dmgMultiplier *= hand[numberOfCard].Value;
                                stamina--;
                                break;
                            }
                        case "Skip":
                            {
                                enemy.numberOfCardsToSkip += (int)hand[numberOfCard].Value;
                                stamina--;
                                break;
                            }
                        case "Stamina":
                            {
                                stamina += (int)hand[numberOfCard].Value;
                                break;
                            }
                        case "Dodge":
                            {
                                Dodge += (int)hand[numberOfCard].Value;
                                stamina--;
                                break;
                            }
                    }
                }
                else if (hand[numberOfCard].Attribute == "Stamina")
                {
                    stamina += (int)hand[numberOfCard].Value;
                }
                else
                {
                    Console.WriteLine("{0} doesn't have any more stamina",Name);
                    log.Add(String.Format("{0} doesn't have any more stamina", Name));
                    return;
                }
                string tempStr = String.Format("{0} has used {1}", name, hand[numberOfCard].Name);
                log.Add(tempStr);
                Console.WriteLine("{0} has used {1}", name, hand[numberOfCard].Name);
                for (int i = numberOfCard; i < numberOfCards - 1; i++)
                {
                    hand[i] = hand[i + 1];
                }
                numberOfCards--;
            }
            else
            {
                Console.WriteLine("{0} doesn't have any more cards",Name);
                log.Add(String.Format("{0} doesn't have any more cards", Name));
            }
        }
        public void AddToLog(string element)
        {
            log.Add(element);
        }
        public int GetNumberOfCards() {  return numberOfCards; }
        public double[] GetAllValues()
        {
            double[] values = {stamina,health,Dodge,numberOfCardsToSkip,dmgMultiplier,healMultiplier};
            return values;
        }
        public void DogFighting(ref DoubleLinkedList Deque)
        {
            int cardsToDraw = 3;
            if(Deque.Count() > 0)
            while (numberOfCards < 5 && cardsToDraw > 0)
            {
                cardsToDraw--;
                DrawCard(ref Deque);
            }
            while (stamina>0 && numberOfCards>0)
            {
                if (Deque.Count() > 0)
                    while (numberOfCards<5 && cardsToDraw>0)
                    {
                    cardsToDraw--;
                    DrawCard(ref Deque);
                    }
                int tempNumberOfCards = numberOfCards;
                Dictionary<string, int> attributes = new Dictionary<string, int>();
                Dictionary<string, int> appearance = new Dictionary<string, int>();
                attributes["DMG"] = -1;
                attributes["DMGMultiplier"] = -1;
                attributes["Heal"] = -1;
                attributes["HealMtp"] = -1;
                attributes["Stamina"] = -1;
                attributes["Dodge"] = -1;
                attributes["Skip"] = -1;

                appearance["DMG"] = 0;
                appearance["Heal"] = 0;
                if(attributes["Dodge"] > -1)
                {
                    UseCard(attributes["Dodge"], Players.cat);
                }
                if(attributes["Skip"] > -1 && stamina>0)
                {
                    UseCard(attributes["Skip"], Players.cat);
                }
                if (attributes["Stamina"] > -1 && numberOfCards > 2 && stamina < 2)
                {
                    UseCard(attributes["Stamina"], Players.cat);
                }
                if (attributes["HealMtp"] > -1 && attributes["Heal"] > -1 && stamina > 1)
                {
                    UseCard(attributes["HealMtp"], Players.cat);
                    if(stamina > 1)
                    {
                        for(int i=attributes["HealMtp"];i<numberOfCards ;i++)
                        {
                            if(stamina <=1)
                            {
                                break;
                            }
                            else if(hand[i].Attribute == "HealMtp")
                            {
                                UseCard(i, Players.cat);
                            }
                        }
                    }
                    for (int i = 0; i < numberOfCards; i++)
                    {
                        if (stamina > 0 && hand[i].Attribute == "Heal")
                        {
                            UseCard(i, Players.cat);
                            appearance["Heal"]--;
                            i = -1;
                        }
                    }
                }
                else if(attributes["Heal"] > -1 && stamina > 0)
                {
                    for (int i = 0; i < numberOfCards; i++)
                    {
                        if (stamina > 0 && hand[i].Attribute == "Heal")
                        {
                            UseCard(i, Players.cat);
                            appearance["Heal"]--;
                            i = -1;
                        }
                    }
                }
                if (attributes["DMG"] > -1 && attributes["DMGMultiplier"] > -1 && stamina > 1)
                {
                    UseCard(attributes["DMGMultiplier"], Players.cat);
                    if (stamina > 1)
                    {
                        for (int i = attributes["DMGMultiplier"]; i < numberOfCards; i++)
                        {
                            if (stamina <= 1)
                            {
                                break;
                            }
                            else if (hand[i].Attribute == "DMGMultiplier")
                            {
                                UseCard(i, Players.cat);
                            }
                        }
                    }
                    for (int i = 0; i < numberOfCards; i++)
                    {
                        if (stamina > 0 && hand[i].Attribute == "DMG")
                        {
                            UseCard(i, Players.cat);
                            if (tempNumberOfCards == numberOfCards)
                            {
                                return;
                            }
                            appearance["DMG"]--;
                            i = -1;
                        }
                    }
                }
                else if(attributes["DMG"] > -1 && stamina > 0)
                {
                    for (int i = 0; i < numberOfCards; i++)
                    {
                        if (stamina > 0 && hand[i].Attribute == "DMG")
                        {
                            UseCard(i, Players.cat);
                            appearance["DMG"]--;
                            i = -1;
                            if (tempNumberOfCards == numberOfCards)
                            {
                                return;
                            }
                        }
                    }
                }
                if(numberOfCards >= 3 && stamina >=2)
                {
                    while (stamina > 0 && numberOfCards > 2)
                    {
                        tempNumberOfCards = numberOfCards;
                        UseCard(numberOfCards - 1, Players.cat);
                        if (tempNumberOfCards == numberOfCards)
                        {
                            return;
                        }
                    }
                }
                if (tempNumberOfCards == numberOfCards)
                {
                    return;
                }
            }
        }
    }
}
