using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CashCount
{
    [Serializable]
    class Transaction
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Transaction()
        {
        }

        public Transaction(double amount, DateTime date, string description)
        {
            this.Amount = amount;
            this.Date = date;
            this.Description = description;
        }
    }
}