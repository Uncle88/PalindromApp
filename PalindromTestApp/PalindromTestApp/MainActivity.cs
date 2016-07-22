using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Renderscripts;

namespace PalindromTestApp
{
    [Activity(Label = "Palindrom", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += OnButtonClicked;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            EditText MyEditText = FindViewById<EditText>(Resource.Id.edittext);
            string a = MyEditText.Text;

            string toast = string.Format(" {0} ", PalindromClass.Palindromtest(a));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        protected override void OnStop()
        {
            Button button = FindViewById<Button>(Resource.Id.MyButton);//dich'
            base.OnStop();
            button.Click -= OnButtonClicked;
        }
    }
}

