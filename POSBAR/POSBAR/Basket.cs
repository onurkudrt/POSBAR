using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Basket
    {
        public string ID;
        private List<string> productList;
        public float totalPrice { get; private set; }

        public Basket(string ID)
        {
            this.ID = ID;
            productList = new List<string>();
        }
        public void addProduct(string ID)
        {
            this.productList.Add(ID);
            this.setTotalPrice();
        }
        public bool removeProduct(string ID)
        {
            bool result = this.productList.Remove(ID);
            if (!result)
                return result;
            this.setTotalPrice();
            return result;
        }
        private void setTotalPrice()
        {
            this.totalPrice = this.calculatePrice();
        }
        private float calculatePrice()
        {
            float price = 0;
            for(int i= 0;i<this.productList.Count; ++i)
                price += Constants.db.getProductByID(this.productList[i]).price;
            return price;
        }
    }
}
