using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Database
    {
        public List<Product> productList;
        public List<Customer> customers;
        public List<Cashier> cashiers;
        public List<Tax> taxes;
        public List<Sales> sales;
        public List<Bank> bank;
        public Database()
        {
            this.productList = new List<Product>();
            this.sales = new List<Sales>();
            this.taxes = new List<Tax>();
            this.customers = new List<Customer>();
            this.cashiers = new List<Cashier>();
            this.bank = new List<Bank>();
        }
    }
}
