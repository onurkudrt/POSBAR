using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Tax
    {
        public string basketID;
        public Basket basket;
        public DateTime date;
        public float totalPrice;
        public string cashierID;
        public Tax(string basketID,Basket basket,DateTime date,float totalPrice,string cashierID)
        {
            this.basketID = basketID;
            this.basket = basket;
            this.date = date;
            this.totalPrice = totalPrice;
            this.cashierID = cashierID;
        }

        public string getTaxInfo()
        {
            string temp = "Kasiyer: " + this.cashierID+"\nİşlem Tarihi: "+this.date.ToString();
            return temp + "\n\nToplam Tutar: " + totalPrice.ToString();
        }
    }
}
