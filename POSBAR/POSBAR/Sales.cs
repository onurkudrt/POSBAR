using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Sales
    {
        public string salesID { get; private set; }
        public float totalPrice { get; private set; }

        private Basket basket;
        public Sales(string salesID)
        {
            this.salesID = salesID;
            this.basket = new Basket(salesID);
        }
        
        public bool addProduct(string productID,int times)
        {
            if (Constants.db.getProductByID(productID) == null)
                return false;
            for (int i = 0; i < times; ++i)
                this.basket.addProduct(productID);
                return true;
        }
        public void removeProduct(string productID)
        {
            this.basket.removeProduct(productID);
        }
        private void installTotalPrice(float price)
        {
            this.totalPrice = this.basket.totalPrice;
        }
        public Basket getBasket()
        {
            return this.basket;
        }
    }
}
