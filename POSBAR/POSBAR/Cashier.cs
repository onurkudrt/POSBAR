using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Cashier:Employee
    {
        private DatabaseFunctions db;
        private Generator gen;
        private Product currentProduct;
        private Sales currentSale;
        public Cashier(string name,string ID,string marketID)
        {
            this.ID = ID;
            this.name = name;
            this.marketID = marketID;
            this.gen = new Generator();
            this.db = Constants.db;
        }
        public void pay(string cardNumber,string bankID)
        {
            this.newPayment(cardNumber, bankID);
        }
        public void giveback(string TaxID,string cardNumber,string bankID)
        {
            this.createGiveBackRequest(TaxID, cardNumber, bankID);
        }
        public Card readCard(string cardNumber, string bankID)
        {
            return this.db.getCard(cardNumber, bankID);
        }
        public string addProductIntoBasket(string barcode,int times) //hazır
        {
            this.currentProduct = this.readBarcode(barcode);
            if (this.currentProduct == null)
                return "Tanımsız barkod algılandı.";
            if (this.currentSale == null)
                this.currentSale = this.createSale();
            this.currentSale.addProduct(this.currentProduct.ID, times);
            string temp = this.getProductInfo(this.currentProduct);
            this.currentProduct = null;
            return temp;
        }
        public void removeProductFromBasket(string productID) //hazır
        {
            this.currentSale.removeProduct(productID);
        }
        private Product readBarcode(string barcode)
        {
            return db.getProduct(barcode);
        }
        private Sales createSale()
        {
            return new Sales(gen.createID(Constants.SALE_ID_LENGTH));
        }
                
        private string getProductInfo(Product p)
        {
            return "Ürün: " + p.name + "\nFiyat: " + p.price.ToString();
        }
        private string newPayment(string cardNumber,string bankID)
        {
            Payment payment = new Payment(this.readCard(cardNumber, bankID), this.currentSale,this.ID,gen.createDateTime());
            Tax t = payment.pay();
            if (t == null)
                return null;
            this.currentSale = null;
            return this.showPaymentResult(t);
        }
        private string showPaymentResult(Tax t)
        {
            if (t == null)
                return "Ödeme Gerçekleştirilemedi.";
            return t.getTaxInfo();
        }
        private Tax createGiveBackRequest(string TaxID,string cardNumber,string bankID)
        {
            Tax t = this.db.getTax(TaxID);
            if (t == null)
                return null;
            Payment p = new Payment(this.readCard(cardNumber, bankID), this.currentSale, this.ID, DateTime.Today);
            p.payback();
            t = p.createTax();
            this.db.addTax(t.basketID, t.basket, DateTime.Today, -t.totalPrice, this.ID);
            return t;
        }
        public string getCashierInfo()
        {
            return this.name+"\n"+ this.ID + "\n"+this.marketID+"\n";
        }
    }
}
