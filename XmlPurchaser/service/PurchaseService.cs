using XmlPurchaser.data;
using XmlPurchaser.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPurchaser.service
{
    class PurchaseService : Service
    {
        List<Purchase> purchases;
        PurchaseFileManager purchaseFileManager = new PurchaseFileManager();
        public override void AddNew()
        {
            Purchase purchase = new Purchase();
            try
            {
                Console.WriteLine("Enter purchase id");
                purchase.Id = Console.ReadLine();
                Console.WriteLine("Enter purchase name");
                purchase.Name = Console.ReadLine();
                Console.WriteLine("Enter purchase price");
                purchase.Price = Double.Parse(Console.ReadLine());

                purchaseFileManager.Write(purchase);
            }
            catch (Exception e) { }

        }

        public override void Display()
        {
            purchases = purchaseFileManager.Read();
            int i = 1;
            foreach (Purchase purchase in purchases)
            {
                Console.WriteLine(i + ". " + purchase);
                i++;
            }
        }

        public Purchase GetByNumber(int number)
        {
            return purchases[number - 1];
        }
       

        public override void Delete()
        {
            Display();
            Console.WriteLine("Enter a number of record to delete");
            int index = Int32.Parse(Console.ReadLine());
            purchases.RemoveAt(index - 1);
            purchaseFileManager.Write(purchases);
        }

        
    }
}
