using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPurchaser.service
{
    abstract class Service
    {
        public abstract void AddNew();

        public abstract void Delete();

        public abstract void Display();
    }
}
