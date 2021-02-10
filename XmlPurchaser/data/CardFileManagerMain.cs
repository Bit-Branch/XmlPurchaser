using XmlPurchaser.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPurchaser.data
{
    partial class CardFileManager: FileManager<Card>
    {
        protected int Recordscount { get; set; }
    }
}
