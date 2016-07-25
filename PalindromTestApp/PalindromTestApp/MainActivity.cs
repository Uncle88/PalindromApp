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

         //   if (MyEditText.Text !=null)
         //   {
         //   string toast = string.Format(" {0} ", PalindromClass.Palindromtest(a));
         //   Toast.MakeText(this, toast, ToastLength.Long).Show();
         //   }
          
         //else
         //   {
         //       string toast1 = string.Format(" {0} ", "You did not enter a word(number)");
         //       Toast.MakeText(this, toast1 , ToastLength.Long).Show();
         //       return;
         //   }
        }

        protected override void OnStop()
        {
            Button button = FindViewById<Button>(Resource.Id.MyButton);//dich'
            base.OnStop();
            button.Click -= OnButtonClicked;
        }
    }
}

