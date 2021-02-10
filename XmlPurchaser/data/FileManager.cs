using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPurchaser.data
{
    abstract class FileManager<T>
    {
        public abstract List<T> Read();
        public virtual void Write(List<T> items) { }
        public virtual void Write(T item) { }

    }
}
