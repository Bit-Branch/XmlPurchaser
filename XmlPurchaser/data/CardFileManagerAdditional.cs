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
    partial class CardFileManager : FileManager<Card>
    {
        private const string filename = "xmls/cards.xml";
       

        public override List<Card> Read()
        {
            List<Card> cards = new List<Card>();
            XDocument xdoc = XDocument.Load(filename);
            var items = from xe in xdoc.Element(XmlCardFields.CARDS).Elements(XmlCardFields.CARD)
            select new Card 
            {
                Id = xe.Attribute(XmlCardFields.ID).Value,
                Name = xe.Attribute(XmlCardFields.NAME).Value,
                Percent = Double.Parse(xe.Element(XmlCardFields.PERCENT).Value),
                Balance = Double.Parse(xe.Element(XmlCardFields.BALANCE).Value),
                Bonuses = Double.Parse(xe.Element(XmlCardFields.BONUCES).Value) 
            };

            cards.AddRange(items);
            return cards;
        }

        public override void Write(List<Card> items)
        {
            XDocument xdoc = XDocument.Load(filename);
            XElement root = xdoc.Element(XmlCardFields.CARDS);
            xdoc.Descendants().Where(e => e.Name == XmlCardFields.CARD).Remove();
            foreach (Card item in items)
            {
                root.Add(new XElement(XmlCardFields.CARD,
                    new XAttribute(XmlCardFields.ID, item.Id),
                            new XAttribute(XmlCardFields.NAME, item.Name),
                            new XElement(XmlCardFields.PERCENT, item.Percent),
                            new XElement(XmlCardFields.BALANCE, item.Balance),
                            new XElement(XmlCardFields.BONUCES, item.Bonuses)));
            }
            xdoc.Save(filename);
        }

        public static void Update(Card card)
        {
            XDocument xmlDoc = XDocument.Load(filename);
            var items = (from item in xmlDoc.Descendants(XmlCardFields.CARD)
                         where item.Attribute(XmlCardFields.ID).Value == card.Id
                         select item).ToList();
            foreach (var item in items)
            {
                item.Attribute(XmlCardFields.ID).Value = card.Id;
                item.Attribute(XmlCardFields.NAME).Value = card.Name;
                item.Element(XmlCardFields.PERCENT).Value = card.Percent.ToString();
                item.Element(XmlCardFields.BALANCE).Value = card.Balance.ToString();
                item.Element(XmlCardFields.BONUCES).Value = card.Bonuses.ToString();
            }
            xmlDoc.Save(filename);
        }

        public override void Write(Card item)
        {
            XDocument xdoc = XDocument.Load(filename);
            XElement root = xdoc.Element(XmlCardFields.CARDS);

            root.Add(new XElement(XmlCardFields.CARD,
                    new XAttribute(XmlCardFields.ID, item.Id),
                            new XAttribute(XmlCardFields.NAME, item.Name),
                            new XElement(XmlCardFields.PERCENT, item.Percent),
                            new XElement(XmlCardFields.BALANCE, item.Balance),
                            new XElement(XmlCardFields.BONUCES, item.Bonuses)));
            
            xdoc.Save(filename);
        }
    }
}
