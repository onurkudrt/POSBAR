using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSBAR
{

    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
        }
       
        public Shows show;
        private void Form1_Load(object sender, EventArgs e)
        {
                Constants.db = new DatabaseFunctions();
                this.show = new Shows(Constants.db);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.selectFunction();
        }
        public void selectFunction()
        {
            this.resetListItem();
            switch (comboBox1.Text)
            {
               case "Kasiyerleri Görüntüle":
                    this.putItemsForCashiers(this.show.showCashiers());
                    break;
               case "Müşterileri Görüntüle":
                    this.putItemsForCustomers(this.show.showCustomers());
                    break;
               case "Müşteri Arayüzü":
                    MessageBox.Show("Henüz oluşturulmadı");
                    break;
               case "Kasiyer Arayüzü":
                    CashierInterface cashier = new CashierInterface();
                    cashier.ShowDialog();
                    break;
               case "Stok Görüntüle":
                    this.putToItems(this.show.showStock());
                    break;
               case "Test Verisini Yükle":
                    TestData test = new TestData();
                    test.run(10);
                    break;
               default:
                    MessageBox.Show("Geçerli Bir İşlem Seçin!");
                    break;
            };

        }
        private void putToItems(string text)
        {
            string[] array = text.Split('\n');
            for(int i=0;i<array.Length-9;i+=9)
            {
                string[] row = { array[i], array[i + 8], array[i + 6], array[i + 4], array[i + 2] };
                ListViewItem item = new ListViewItem(row);
                this.listView1.Items.Add(item);
            }
        }
        private void putItemsForCashiers(string text)
        {
            string[] array = text.Split('\n');
            for(int i=0;i<array.Length-5;i+=5)
            {
                string[] row = { array[i], array[i + 2], array[i + 4] };
                ListViewItem item = new ListViewItem(row);
                this.listView1.Items.Add(item);
            }
        }
        private void putItemsForCustomers(string text)
        {
            string[] array = text.Split('\n');
            for(int i =0;i<array.Length-8;i+=8)
            {
                string[] row = { array[i], array[i + 2], array[i + 4] };
                this.listView1.Items.Add(new ListViewItem(row));
            }
        }
        private void resetListItem()
        {
            this.listView1.Items.Clear();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class Shows
    {
        public DatabaseFunctions db;
        public Shows(DatabaseFunctions db)
        {
            this.db = db;
        }

        public string showCustomers()
        {
            if (this.db.customers.Count == 0)
            {
                MessageBox.Show("Henüz hiç müşteri verisi yok.\nTest verisini yükleyin.");
                return "";
            }
            string temp = "";
            for (int i = 0;i<this.db.customers.Count; ++i)
                temp += db.customers[i].getInfos();
           return temp;
        }
        public string showStock()
        {
            if (db.productList.Count == 0)
            {
                MessageBox.Show("Henüz hiç stok verisi yok.\nTest verisini yükleyin.");
                return "";
            }
            string temp = "";
            for (int i = 0; i<db.productList.Count; ++i)
            {
                temp += db.productList[i].getProductInfos();
            }
            return temp;
        }
        public string showCashiers()
        {
            if(db.cashiers.Count == 0)
            {
                MessageBox.Show("Hiç kasiyer yok\nTest verisini yükleyin.");
                return "";
            }
            string temp = "";
            for (int i = 0; i < db.cashiers.Count; ++i)
                temp += db.cashiers[i].getCashierInfo();
            return temp;
        }
    }
    public static class Constants
    {
        public const int CUSTOMER_ID_LENGTH = 10;
        public const int PRODUCT_ID_LENGTH = 7;
        public const int CASHIER_ID_LENGTH = 8;
        public const int CVV_LENGTH = 3;
        public const int CARD_NUMBER_LENGTH = 16;
        public const int BARCODE_LENGTH = 13;
        public const int SALE_ID_LENGTH = 12;
        public const int BASKET_ID_LENGTH = 12;
        public const int CARD_ID_LENGTH = 10;
        public const int BANK_ID_LENGTH = 4;
        public const int SHOP_ID_LENGTH = 6;
        public static DatabaseFunctions db;
    }
    public class TestData
    {
        DatabaseFunctions db;
        public TestData()
        {
            this.db = Constants.db;
        }
        public void run(int dataSize)
        {
            Generator generator = new Generator();
            string[] productArray = new string[] { "Çilek", "Gofret", "Peynir", "Makarna", "Et", "Tavuk", "Deodorant", "Şampuan", "Deterjan", "Patates", "Domates", "Maydonoz" };
            for (int i=0;i<dataSize;++i)
            {
                db.addCustomers(Constants.CUSTOMER_ID_LENGTH.ToString(), generator.randomNameGenerator() , generator.phoneGenerator());
                db.addCashier(generator.randomNameGenerator(), Constants.CASHIER_ID_LENGTH.ToString(), Constants.SHOP_ID_LENGTH.ToString());
                db.addProduct(0, generator.random(100), generator.createBarcodeForProduct(), generator.randomNameGenerator(), generator.createID(Constants.PRODUCT_ID_LENGTH));
                Basket basket = this.basketGenerator(new Random().Next(1,30));
                db.addSales(basket.ID);
                db.addTax(basket.ID, basket, generator.createDateTime(),0, generator.createID(Constants.CASHIER_ID_LENGTH));
                db.addProduct(generator.randomFloatValue(2), generator.random(100), generator.createBarcodeForProduct(),productArray[i%productArray.Length], generator.createID(Constants.PRODUCT_ID_LENGTH));
            }

        }
        private Basket basketGenerator(int productCount)
        {
            Random random = new Random();
            Generator generator = new Generator();
            int index = int.MaxValue;
            Basket basket = new Basket(generator.createID(Constants.BASKET_ID_LENGTH));
            for (int i = 0; i < productCount-1; ++i)
            {
                while (index>this.db.productList.Count)
                    index = (random.Next(100) % db.productList.Count);
                basket.addProduct(db.productList[index].ID);
            }
            return basket;
        }
        private DatabaseFunctions createDatabase()
        {
            return new DatabaseFunctions();
        }
    }
}
