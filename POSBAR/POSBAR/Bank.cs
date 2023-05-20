using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Bank
    {
        private string name;
        private string ID;
        private List<Card> cards;
        public Bank(string name,string ID)
        {
            this.name = name;
            this.ID = ID;
            this.cards = new List<Card>();
        }
        public void addNewCard(Card c)
        {
            this.cards.Add(new Card(c.getCardNumber(this.ID), c.date, c.CVV, c.customerID, c.cardID, this.ID, c.limit));
        }
        public Card getCard(string cardNumber)
        {
            return this.cards.Find(x=> x.confirm(cardNumber,this.ID));
        }
        public bool confirm(string bankID)
        {
            return bankID == this.ID;
        }
    }
}
