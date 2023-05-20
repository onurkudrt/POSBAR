using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Customer
    {
        public string ID;
        protected string name;
        protected string phoneNumber;
        private Card card;
        public Customer(string ID,string name,string phoneNumber)
        {
            this.ID = ID;
            this.name = name;
            this.phoneNumber = phoneNumber;
            Generator generate = new Generator();
            this.card = new Card(generate.createCardNumber(),generate.createDateTime(),generate.createBarcodeForProduct(),generate.createID(Constants.CUSTOMER_ID_LENGTH),generate.createID(Constants.CARD_ID_LENGTH),generate.createID(Constants.BANK_ID_LENGTH),generate.randomFloatValue(generate.random(2,10)));
        }

        public string getInfos()
        {
            return  this.name + "\n" + this.phoneNumber+"\n"+this.ID+"\n";
        }
        public Card getCard()
        {
            return this.card;
        }
    }
}
