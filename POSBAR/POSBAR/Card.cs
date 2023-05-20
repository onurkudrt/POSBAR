using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Card
    {
        private string cardNumber;
        public DateTime date { get; private set; }
        public string CVV { get; private set; }
        public string customerID { get; private set; }
        public string cardID { get; private set; }
        public string bankID { get; private set; }
        public float limit { get; private set; }

        public Card(string cardNumber, DateTime date, string CVV, string customerID, string cardID, string bankID, float limit)
        {
            this.cardNumber = cardNumber;
            this.date = date;
            this.CVV = CVV;
            this.customerID = customerID;
            this.cardID = cardID;
            this.bankID = bankID;
            this.limit = limit;
        }
        public bool pay(float amount)
        {
            if (amount > this.limit)
                return false;
            this.limit -= amount;
            return true;
        }
        public void restoreCash(float amount)
        {
            this.limit += amount;
        }
        public bool confirm(string cardNumber,string bankID)
        {
            return this.cardNumber == cardNumber && this.bankID == bankID;
        }
        public Card getCardInfo(string cardNumber, string bankID)
        {
            if (!this.confirm(cardNumber,bankID))  return null;
            return this;
        }
        public string getCardNumber(string bankID)
        {
            if (this.confirm(this.cardNumber, bankID))
                return this.cardNumber;
            return null;
        }
    }
}
