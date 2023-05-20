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
    public partial class CashierInterface : Form
    {
        public CashierInterface()
        {
            InitializeComponent();
        }
        DatabaseFunctions db;
        Cashier cashier;
        Tax currentTax;
        Card currentCard;
        Sales currentSales;
        Product currentProduct;
        private void CashierInterface_Load(object sender, EventArgs e)
        {
            this.init();
        }
        private void init()
        {
            this.db = Constants.db;
            this.cbCashiers.Items.Add("Yeni Kasiyer Ekle");
            this.addCashiers();
        }
        private void addCashiers()
        {
            for(int i=0;i<this.db.cashiers.Count;++i)
                this.cbCashiers.Items.Add(this.db.cashiers[i].name);
        }
        private void installCashier()
        {
            for (int i = 0; i < this.db.cashiers.Count; ++i)
                if (this.cbCashiers.Text == this.db.cashiers[i].name)
                {
                    this.cashier = this.db.cashiers[i];
                    return;
                }
        }
        private bool cashierControl()
        {
            return this.cashier == null;
        }
        private void setItemsVisible(bool enable)
        {
            this.cbProcess.Visible = enable;
            this.txtData.Visible = enable;
            this.lblScreen.Visible = enable;
            this.lvScreen.Visible = enable;
            this.lblData.Visible = enable;
            this.lblData2.Visible = this.lblData3.Visible = this.txtData2.Visible = this.txtData3.Visible =this.btnRun.Visible=this.gbCashierInfo.Visible= enable;
        }
        private void setContents()
        {
            this.cbProcess.Text = this.txtData.Text = this.txtData2.Text=this.txtData3.Text = "";
        }
        private void setLabelData()
        {
            if (this.cbProcess.Text == "")
            {
                this.lblData.Visible = false;
                this.txtData.Visible = false;
            }
            else
                this.lblData.Text = this.cbProcess.Text;

        }
        private void chooseCashier()
        {
            if (this.cbCashiers.Text == "Yeni Kasiyer Ekle")
            {
                this.setItemsVisible(false);
                this.setContents();
                this.setLabelData();
                return;
            }
            else
            {
                this.setItemsVisible(false);
                this.setContents();
                this.setLabelData();
                this.installCashier();
                this.lblShopID.Text = this.cashier.ID;
                this.lblCashierName.Text = this.cashier.name;
                this.gbCashierInfo.Visible = true;
                this.lblScreen.Visible = this.lvScreen.Visible = true;
                this.cbProcess.Visible =true;
            }

        }
            private void process()
        {
            
            switch (this.cbProcess.Text)
            {
                
                case "Ödeme Yap":
                    this.setContents();
                    this.lblData.Text = "Kart Numarası:";
                    this.lblData2.Text = "Banka ID";
                    this.setContents();
                    this.btnRun.Visible = true;
                    this.txtData3.Visible = this.lblData3.Visible = false;
                    this.lblData.Visible = this.lblData2.Visible = this.txtData.Visible = this.txtData2.Visible  = true;
                    break;
                case "İade Oluştur":
                    this.setContents();
                    this.lblData.Text = "Kart Numarası:";
                    this.lblData2.Text = "Banka ID"; 
                    this.lblData3.Text = "Fiş Numarası:";
                    this.setContents();
                    this.btnRun.Visible = true;
                    this.lblData.Visible = this.lblData2.Visible = this.lblData3.Visible = this.txtData.Visible = this.txtData2.Visible = this.txtData3.Visible = true;
                    break;
                case "Ürün Oku":
                    this.setContents();
                    this.lblData.Text = "Ürün Barkodu:";
                    this.lblData.Visible = this.txtData.Visible = true;
                    this.btnRun.Visible = true;
                    this.lblData2.Visible = this.lblData3.Visible = this.txtData2.Visible = this.txtData3.Visible = false;
                    break;
                default:
                    MessageBox.Show("Bir işlem seçin");
                    break;
            }
        }
        private void readCard()
        {
         this.currentCard = this.db.getCard(this.txtData.Text, this.txtData2.Text);
        }
        private void readBarcode()
        {

        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            
        }

        private void cbCashiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chooseCashier();
        }

        private void btnRun_Click_1(object sender, EventArgs e)
        {
            switch (this.cbProcess.Text)
            {
                case "Ödeme Yap":
                    this.readCard();
                    this.cashier.pay(this.currentCard.getCardNumber(this.currentCard.bankID), this.currentCard.bankID);
                    break;
                case "İade Oluştur":
                    this.readCard();
                    this.installTax(this.txtData3.Text);
                    this.cashier.giveback(this.currentTax.basketID, this.currentCard.getCardNumber(this.currentCard.bankID), this.currentCard.bankID);
                    break;
                case "Ürün Oku":
                    this.cashier.addProductIntoBasket(txtData.Text, Convert.ToInt32(txtData.Text));
                    break;
                default:
                    MessageBox.Show("Bir işlem seçin");
                    break;
            }
        }
        //eksik 
        private void installCurrentElements(int mode)
        {
            switch(mode)
            {
                case 0: // install current card
                    this.currentCard =  new Card(this.txtData.Text, DateTime.UtcNow, new Generator().createID(Constants.CVV_LENGTH), "customerID", "cardID",this.txtData2.Text, new Generator().randomFloatValue(5));
                    break;
                case 2: // install current Tax
                    this.currentTax = new Tax(this.currentSales.salesID,this.currentSales.getBasket(),DateTime.Now,this.currentSales.totalPrice,this.cashier.ID);
                    break;
                case 1: // install current sale
                    this.currentSales = new Sales(new Generator().createID(Constants.SALE_ID_LENGTH));
                    break;
                case 3: // install product
                    this.currentProduct = this.db.getProduct(this.txtData.Text);
                    break;
            }
        }
        private void installTax(string ID)
        {
            this.currentTax = this.db.getTax(ID);
        }
        private void createNewSale()
        {
            this.currentSales = new Sales(new Generator().createID(Constants.SALE_ID_LENGTH));
        }
        private void addBasket(Product p)
        {
            this.currentSales.getBasket().addProduct(p.ID);
        }
        private void removeBasket(Product p)
        {
            this.currentSales.getBasket().removeProduct(p.ID);
        }
        private void pay(string cardNumber,string bankID)
        {
            this.cashier.pay(cardNumber,bankID);
        }
        private void giveback(string tax,string cardNumber,string bankID)
        {
            this.cashier.giveback(tax,cardNumber,bankID);
        }

        private string randomProduct()
        {
           this.currentProduct =  this.db.randomProduct(new Generator().random(this.db.productList.Count-1));
            return this.currentProduct.getProductInfos();
        }

        private void cbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.process();
        }
    }
}
