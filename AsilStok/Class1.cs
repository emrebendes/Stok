using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsilStok
{
    public class Stock
    {
        String tip;
        decimal price;
        int amount = 10;
        public Stock(String tip) => this.tip = tip;

        public delegate void EHandler();
        public event EHandler PriceChanced;

        public decimal Price
        {
            get => price;
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;
                PriceChanced?.Invoke();// olay tetiklendi
            }
        }



    }


    public class PriceChancedEventArgs : EventArgs
    {
        public readonly decimal oldPrice;
        public readonly decimal newPrice;
        public PriceChancedEventArgs(decimal oldPrice, decimal newPrice)
        {
            this.oldPrice = oldPrice;
            this.newPrice = newPrice;
        }
    }
}
