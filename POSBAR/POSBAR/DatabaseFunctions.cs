using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class DatabaseFunctions
    {
        Database db;
        internal List<Product> productList;
        internal List<Tax> taxes;
        internal List<Customer> customers;
        internal List<Sales> sales;
        internal List<Cashier> cashiers;
        internal List<Bank> banks;
        public DatabaseFunctions()
        {
            this.db = new Database();
            this.productList = this.db.productList;
            this.taxes = this.db.taxes;
            this.customers = this.db.customers;
            this.sales = this.db.sales;
            this.cashiers = this.db.cashiers;
            this.banks = this.db.bank;
        }

        public string getCashierInfo(string personalID)
        {
           Cashier c = this.db.cashiers.Find(x => x.ID == personalID);
            if (c == null)
                return "Böyle bir kayıt bulunamadı.";
            return "Adı: "+c.name+"\nMağaza Numarası: "+c.marketID+"\nID Numarası: "+c.ID;
        }
        public Product getProduct(string barcode)
        {
            return this.db.productList.Find(x => x.barcode == barcode);
        }
        public string getCustomerInfo(string customerID)
        {
            Customer c = this.db.customers.Find(x => x.ID == customerID);
            if (c == null)
                return "Böyle bir kayıt bulunamadı.";
            return c.getInfos();
        }
        public Tax getTax(string basketID)
        {
            return this.db.taxes.Find(x => x.basketID == basketID);
        }
        public Sales getSale(string salesID)
        {
            return this.db.sales.Find(x => x.salesID == salesID);
        }
        public Product getProductByID(string ID)
        {
            return this.db.productList.Find(x => x.ID == ID);
        }
        public Card getCard(string cardNumber,string bankID)
        {
            return this.getBank(bankID).getCard(cardNumber); 
        }
        public Bank getBank(string bankID)
        {
            return this.banks.Find(x => x.confirm(bankID));
        }
        public void addProduct(float price, int amount, string barcode, string name, string ID)
        {
            this.db.productList.Add(new Product(price, amount, barcode, name, ID));
        }
        public void addTax(string basketID, Basket basket, DateTime date, float totalPrice, string cashierID)
        {
            this.db.taxes.Add(new Tax(basketID, basket, date, totalPrice, cashierID));
        }
        public void addSales(string salesID)
        {
            this.db.sales.Add(new Sales(salesID));
        }
        public void addCustomers(string ID, string name, string phoneNumber)
        {
            this.db.customers.Add(new Customer(ID, name, phoneNumber));
        }
        public void addCashier(string name, string ID, string marketID)
        {
            this.db.cashiers.Add(new Cashier(name, ID, marketID));
        }
        public void addBank(string name,string bankID)
        {
            this.db.bank.Add(new Bank(name, bankID));
        }
        public void addCardToBank(Card c,string bankID)
        {
            this.getBank(bankID).addNewCard(c);
        }
        public Product randomProduct(int val)
        {
            return this.db.productList[val];
        }
        public Customer randomCustomer(int val)
        {
            return this.db.customers[val];
        }
        public Tax randomTax(int val)
        {
            return this.taxes[val];
        }
        public Cashier randomCashier(int val)
        {
            return this.cashiers[val];
        }
    } 
}
