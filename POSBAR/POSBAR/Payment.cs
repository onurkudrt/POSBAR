using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Payment
    {
        public float paymentAmount;
        public string paymentID;
        public string cardID;
        public string bankID;
        private Tax tax;
        private Card card;
        private Sales sale;
        private string cashierID;
        private DateTime date;
        public Payment(Card card, Sales sale,string cashierID,DateTime date)
        {
            this.card = card;
            this.sale = sale;
            this.paymentAmount = sale.totalPrice;
            this.paymentID = sale.salesID;
            this.cashierID = cashierID;
            this.date = date;
        }
        ~Payment()
        {

        }
        private bool payFunction()
        {
            return this.card.pay(this.paymentAmount);
        }
        public Tax pay()
        {
            if (this.payFunction() == false)
                return null;
            return createTax();
        }
        private void getTax()
        {
            this .tax = new Tax(this.sale.salesID, this.sale.getBasket(), this.date, this.sale.totalPrice, this.cashierID);
        }
        public Tax createTax()
        {
            this.getTax();
            Constants.db.addTax(this.tax.basketID, this.tax.basket, this.tax.date, this.tax.totalPrice, this.cashierID);
            return this.tax;
        }
        public string getCardNumber()
        {
            return this.card.getCardNumber(this.card.bankID);
        }
        public void payback()
        {
            this.card.pay(-this.paymentAmount);
        }
    }
}
