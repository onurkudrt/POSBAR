using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Product
    {
        public string name;
        public string barcode;
        public int amount;
        public float price;
        public string ID { get; private set; }
        public Product(float price,int amount,string barcode,string name,string ID)
        {
            this.price = price;
            this.amount = amount;
            this.barcode = barcode;
            this.name = name;
            this.ID = ID;
        }

        public string getProductInfos()
        {
            return name + "\n" + barcode + "\n" + ID + "\n" + price.ToString()+"\n"+amount+"\n";
        }
    }
}
