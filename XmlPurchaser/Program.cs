using XmlPurchaser.model;
using XmlPurchaser.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPurchaser
{
    class Program
    {
        delegate void Select();
        static void Main(string[] args)
        {
            Select select;
            
            bool flag = true;
            CardService cardService = new CardService();
            PurchaseService purchaseService = new PurchaseService();
            while (flag)
            {
                try{
                Console.WriteLine("1.Add new card");
                Console.WriteLine("2.List cards");
                Console.WriteLine("3.Delete card");
                Console.WriteLine("4.Add new purchase");
                Console.WriteLine("5.List purchases");
                Console.WriteLine("6.Delete purchase");
                Console.WriteLine("7.Buy purchase");
                Console.WriteLine("8.Exit");

                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            cardService.AddNew();
                            break;
                        }
                    case 2:
                        {
                            cardService.Display();
                            break;
                        }
                    case 3:
                        {
                            cardService.Delete();
                            break;
                        }

                    case 4:
                        {
                            purchaseService.AddNew();
                            break;
                        }

                    case 5:
                        {
                            purchaseService.Display();
                            break;
                        }

                    case 6:
                        {
                            purchaseService.Delete();
                            break;
                        }
                    case 7:
                        {
                            select = purchaseService.Display;
                            select();
                            Console.WriteLine("Enter a number of purchase");
                            int number = Int32.Parse(Console.ReadLine());
                            Purchase purchase = purchaseService.GetByNumber(number);
                            select = cardService.Display;
                            select();
                            Console.WriteLine("Enter a number of card");
                            number = Int32.Parse(Console.ReadLine());
                            Card card = cardService.GetByNumber(number);

                            if (card.Balance + card.Bonuses < purchase.Price) {
                        Console.WriteLine("На карте недостаточно средств");
                    } else {
                        

                        card.Balance = card.Balance - purchase.Price + card.Bonuses;
                        card.Bonuses = 0;
                        card.Bonuses = (purchase.Price * card.Percent / 100);
                        
                    }

                            cardService.UpdateCard(card);
                            break;
                        }
                    case 8:
                        {
                            flag = false;
                            break;
                        }
                       
                    default:
                        {
                            break;
                        }
                }
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }

            }
        }

        
    }

    public static class StringExtension
    {
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    } 
}
