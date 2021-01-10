using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System;
using Android.Content;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CashCount
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        TextView TextViewTotalDisplay;
        Button ButtonSubtract;
        Button ButtonAdd;
        Button Button1;
        Button Button5;
        Button Button20;
        int amount = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Assign Buttons To Views
            TextViewTotalDisplay = FindViewById<TextView>(Resource.Id.txtTotalDisplay);
            ButtonSubtract = FindViewById<Button>(Resource.Id.btnSubtract);
            ButtonAdd = FindViewById<Button>(Resource.Id.btnAdd);
            Button1 = FindViewById<Button>(Resource.Id.btn1);
            Button5 = FindViewById<Button>(Resource.Id.btn5);
            Button20 = FindViewById<Button>(Resource.Id.btn20);

            // Button Button Click Events
            ButtonAdd.Click += ButtonAdd_Clicked;
            ButtonSubtract.Click += ButtonSubtract_Clicked;
            Button1.Click += Button1_Clicked;
            Button5.Click += Button5_Clicked;
            Button20.Click += Button20_Clicked;
        }

        void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            Transaction newTransac = new Transaction();
            newTransac.Amount = amount;
            newTransac.Date = DateTime.Now;
            newTransac.Description = "";

            Intent intent = new Intent(this, typeof(HistoryTracker));

            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, newTransac);

            intent.PutExtra("Transaction", stream.ToArray());
            StartActivity(intent);

            this.OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_out_bottom);
        }

        void ButtonSubtract_Clicked(object sender, EventArgs e)
        {

        }

        void Button1_Clicked(object sender, EventArgs e)
        {
            amount++;
            TextViewTotalDisplay.Text = amount.ToString();
        }

        void Button5_Clicked(object sender, EventArgs e)
        {
            amount = amount + 5;
            TextViewTotalDisplay.Text = amount.ToString();
        }

        void Button20_Clicked(object sender, EventArgs e)
        {
            amount = amount + 20;
            TextViewTotalDisplay.Text = amount.ToString();
        }
    }
}