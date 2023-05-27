using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatVsDog
{
    class Card
    {
        public Card next;
        public Card prev;
        string name;
        string attribute;
        double value;
        public string[] card = new string[10];
        public string Attribute
        {
            get { return attribute; }
            set { attribute = value; }
        }
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void SetCard()
        {
            //card = new string[10];
            card[0] = "-----------------";
            card[1] = "|               |";
            var splittedName = name.Split(' ',2);
            card[2] = "|               |";
            int counter = 3;
            if (splittedName.Length < 2)
            {
                card[counter] = "|               |";
                counter++;
            }
            foreach (var partOfName in splittedName)
            {
                int temp = 8 + partOfName.Length / 2;
                card[counter ] = ("|" + String.Format("{0," + temp + "}", partOfName) + "\t|");
                counter++;
            }
            int temp2 = 8 + attribute.Length / 2;
            card[5] = ("|" + String.Format("{0," + temp2 + "}", attribute) + "\t|");
            card[6] = ("|" + String.Format("{0,8}", value) + "\t|");
            card[7] = ("|               |");
            card[8] = ("|               |");
            card[9] = ("-----------------");
        }
        public void SetDogsCard()
        {
            //card = new string[10];
            card[0] = "-----------------";
            card[1] = "|    ######     |";
            card[2] = "|  ##       ##  |";
            card[3] = "|           ##  |";
            card[4] = "|       ###     |";
            card[5] = "|      ##       |";
            card[6] = "|      ##       |";
            card[7] = "|               |";
            card[8] = "|      ##       |";
            card[9] = "-----------------";

        }
        public void ShowCard()
        {
            SetCard();
            foreach(var element in card)
            {
                Console.WriteLine(element);
            }
        }
    }
    class DoubleLinkedList
    {
        Card head;
        int length = 0;
        public void Add(Card card)
        {
            if(head==null)
            {
                head=card;
            }
            else
            {
                Card temp = head;
                while(temp.next!=null)
                {
                    temp = temp.next;
                }
                temp.next = card;
                card.prev = temp;
            }
            length++;
        }
        public void DeleteBack()
        {
            if(head!=null)
            {
                Card temp = head;
                while(temp.next.next!=null)
                {
                    temp=temp.next;
                }
                temp.next = null;
                length--;
            }
        }
        public void RemoveAt(int index)
        {
            Card temp = head;
            for (int i = 0; i < index; i++)
            {
                if (temp != null)
                    temp = temp.next;
                else
                    break;
            }
            if (temp != null && temp.next != null)
            {
                Card nodeToDelete = temp.next;
                temp.next = temp.next.next;
                if (temp.next.next != null)
                    temp.next.next.prev = temp.next;
                nodeToDelete = null;
                length--;
            }
            else if(temp != null && length>0)
            {
                Card temp2 = temp.prev;
                temp2.next = null;
                length--;
            }
        }
        public Card GetAt(int index)
        {
            Card temp = head;
            for (int i = 0; i < index; i++)
            {
                if (temp != null)
                    temp = temp.next;
                else
                    break;
            }
            return temp;
        }
        public Card this[int index]
        {
            get => GetAt(index);
        }
        public int Count()
        {
            return length;
        }
    }
}
