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
    [Activity(Label = "Palindrom", MainLauncher = true, Icon = "@drawable/imag")]
    public class MainActivity : Activity
    {
        private Button _button;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _button = FindViewById<Button>(Resource.Id.MyButton);
            _button.Click += OnButtonClicked;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            EditText MyEditText = FindViewById<EditText>(Resource.Id.edittext);
            string enteredText = MyEditText.Text;

            string palindromCheckResult = PalindromClass.Palindromtest(enteredText).ToString();
            Toast.MakeText(this, palindromCheckResult, ToastLength.Long).Show();
        }

        protected override void OnStop()
        {
            base.OnStop();
            _button.Click -= OnButtonClicked;
        }
    }
}

