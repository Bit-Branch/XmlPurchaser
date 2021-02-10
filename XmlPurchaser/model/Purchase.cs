using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPurchaser.model
{
    class Purchase
    {
        public string Id{ get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + "\n" + "Name: " + Name + "\n" + "Price: " + Price + "\n";
        }
    }
}
