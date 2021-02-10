using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPurchaser.model
{
    class Card
    {
       public string Id {get;set;}
       public string Name { get; set; }
       public double Percent { get; set; }
       public double Balance { get; set; }
       public double Bonuses { get; set; }

       public override string ToString()
       {
           return "Id: " + Id + "\n" + "Name: " + Name + "\n" + "Percent: " + Percent + "\n" + "Balance: " + Balance + "\n" + "Bonuses: " + Bonuses + "\n";
       }
    }
}
