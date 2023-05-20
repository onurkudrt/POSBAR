using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Generator
    {
        Random randomObject;
        public Generator()
        {
            this.randomObject = new Random();
        }
        public string createBarcodeForProduct()
        {
            return this.stringGenerator(Constants.BARCODE_LENGTH);
        }
        public string createID(int length)
        {
            return this.integer32Generator(length);
        }
        public string createCardNumber()
        {
            return this.cardNumber();
        }
        public DateTime createDateTime()
        {
            return this.randomDate();
        }
        public int random()
        {
            return new Random().Next();
        }
        public int random(int maxValue)
        {
            return new Random().Next(maxValue);
        }
        public int random(int minValue,int maxValue)
        {
            return this.randomObject.Next(minValue, maxValue);
        }
        public float randomFloatValue(int maxDigit)
        {
            double number=this.randomObject.NextDouble();
            for (int i = 0; i < maxDigit; ++i)
                number *= 10;
            return (float)Math.Round(number, 2);
        }
        public float randomFloatValue(int minDigit,int maxDigit)
        {
            int limit = this.randomObject.Next(minDigit, maxDigit);
            double number =this.randomObject.NextDouble();
            for (int i = 0; i < limit; ++i)
                number *= 10;
            return (float)Math.Round(number, 2);
        }
        public string randomNameGenerator()
        {
            return this.nameGenerator();
        }
        private string stringGenerator(int stringLength)
        {
            int number = this.randomObject.Next(10, 100);
            string temp = "";
            for (int i=0;i<stringLength;++i)
            {
                while (number >= 30 && number <= 39 || number <= 90 && number >= 65)
                    number = this.randomObject.Next(10, 100);
                temp += (char)number;
            }
            return temp;
        }

        private string integer32Generator(int intLength)
        {
            string temp = "";
            for (int i = 0; i < intLength; ++i)
                temp += this.randomObject.Next(0, 9).ToString();
            return temp;
        }
        private string cardNumber()
        {
            string temp = "";
            for (int i = 0; i < 16; ++i)
                temp += (char)this.randomObject.Next(30, 39);
            return temp;
        }
        private DateTime randomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(this.randomObject.Next(range));
        }
        private string nameGenerator()
        {
            int name = nameArray.Length;
            int surname = surnameArray.Length;
            return this.nameArray[this.random(int.MaxValue)%name]+" "+this.surnameArray[this.random(int.MaxValue)%surname];
        }
        public string phoneGenerator()
        {
            return "053"+this.createID(7);
        }
        string[] nameArray = new string[] { "Onur", "İrem", "Gamze", "Salih", "Ümit", "Emine", "Çağdaş", "Meysem", "Ali", "Osman", "Manolya","Tarık", "Selin", "Selim" };
        string[] surnameArray = new string[] { "Kudret", "Nurlu", "Kumlu", "İnan", "Çalışkan", "Usta", "Nural", "Toprak", "Çay", "Çoruh", "Karaman", "Koyuncu", "Sönmez", "Açıkgöz" };
    }
}
