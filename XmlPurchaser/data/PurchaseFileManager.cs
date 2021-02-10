using XmlPurchaser.model;
using XmlPurchaser.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlPurchaser.data
{
    class PurchaseFileManager : FileManager<Purchase>
    {
        private const string filename = "xmls/purchases.xml";
       

        public override List<Purchase> Read()
        {
            List<Purchase> purchases = new List<Purchase>();
            XDocument xdoc = XDocument.Load(filename);
            var items = from xe in xdoc.Element(XmlPurchaseFields.PURCHASES).Elements(XmlPurchaseFields.PURCHASE)
                        select new Purchase
                        {
                            Id = xe.Attribute(XmlPurchaseFields.ID).Value,
                            Name = xe.Attribute(XmlPurchaseFields.NAME).Value,
                            Price = Double.Parse(xe.Element(XmlPurchaseFields.PRICE).Value)
                        };

            purchases.AddRange(items);
            return purchases;
        }

        public override void Write(List<Purchase> items)
        {
            XDocument xdoc = XDocument.Load(filename);
            XElement root = xdoc.Element(XmlPurchaseFields.PURCHASES);
            xdoc.Descendants().Where(e => e.Name == XmlPurchaseFields.PURCHASE).Remove();
            foreach (Purchase item in items)
            {
                root.Add(new XElement(XmlPurchaseFields.PURCHASE,
                    new XAttribute(XmlPurchaseFields.ID, item.Id),
                            new XAttribute(XmlPurchaseFields.NAME, item.Name),
                            new XElement(XmlPurchaseFields.PRICE, item.Price)));
            }
            xdoc.Save(filename);
        }

        public override void Write(Purchase item)
        {
            XDocument xdoc = XDocument.Load(filename);
            XElement root = xdoc.Element(XmlPurchaseFields.PURCHASES);

            root.Add(new XElement(XmlPurchaseFields.PURCHASE,
                new XAttribute(XmlPurchaseFields.ID, item.Id),
                        new XAttribute(XmlPurchaseFields.NAME, item.Name),
                        new XElement(XmlPurchaseFields.PRICE, item.Price)));

            xdoc.Save(filename);
        }
    }
}
