using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Shop
    {
        private int shopID;
        private string address;
        Shop(string address,int ID)
        {
            this.address = address;
            this.shopID = ID;
        }

    }
}
