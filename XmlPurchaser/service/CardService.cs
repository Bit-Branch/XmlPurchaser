using XmlPurchaser.data;
using XmlPurchaser.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPurchaser.service
{
    class CardService : Service
    {
        List<Card> cards;
        CardFileManager cardFileManager = new CardFileManager();
        public override void AddNew()
        {
            Card card = new Card();
            try
            {
                Console.WriteLine("Enter card id");
                card.Id = Console.ReadLine();
                Console.WriteLine("Enter card name");
                card.Name = Console.ReadLine();
                Console.WriteLine("Enter card percent");
                card.Percent = Double.Parse(Console.ReadLine());
                Console.WriteLine("Enter card balance");
                card.Balance = Double.Parse(Console.ReadLine());
                Console.WriteLine("Enter card bonuses");
                card.Bonuses = Double.Parse(Console.ReadLine());

                cardFileManager.Write(card);
            }
            catch (Exception e) { }
        }

        public override void Display()
        {
            cards = cardFileManager.Read();
           int i = 1;
           foreach (Card card in cards)
           {
               Console.WriteLine(i + ". " + card);
               i++;
           }
        }

        public Card GetByNumber(int number)
        {
            return cards[number - 1];
        }

        public void UpdateCard(Card card)
        {
            CardFileManager.Update(card);
        }

        public override void Delete()
        {
            Display();
            Console.WriteLine("Enter a number of record to delete");
            int index = Int32.Parse(Console.ReadLine());
            cards.RemoveAt(index - 1);
            cardFileManager.Write(cards);
        }
    }
}
