using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CashCount
{
    [Activity(Label = "HistoryTracker")]
    public class HistoryTracker : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the layout resources
            SetContentView(Resource.Layout.HistoryTracker);

            // Recieve new transaction
            var byteArr = Intent.GetByteArrayExtra("transaction");
            var stream = new MemoryStream(byteArr);
            var formatter = new BinaryFormatter();
            var newTransac = formatter.Deserialize(stream) as Transaction;
        }
    }
}