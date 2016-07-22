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

           SeekBar seekbar = FindViewById<SeekBar>(Resource.Id.seekBar1);
           seekbar.StopTrackingTouch += BlurImageHandler;
        }

        private void BlurImageHandler(object sender, SeekBar.StopTrackingTouchEventArgs e)
        {
            int radius = e.SeekBar.Progress;
            if (radius == 0)
            {
                ImageView imageView = FindViewById<ImageView>(Resource.Id.container);
                // We don't want to blur, so just load the un-altered image.
                imageView.SetImageResource(Resource.Drawable.winter);
            }
            else
            {
                DisplayBlurredImage(radius);
            }
        }
        private void DisplayBlurredImage(int radius)
        {
            SeekBar seekbar = FindViewById<SeekBar>(Resource.Id.seekBar1);
            ImageView imageView = FindViewById<ImageView>(Resource.Id.container);
            seekbar.StopTrackingTouch -= BlurImageHandler;
            seekbar.Enabled = false;

           // ShowIndeterminateProgressDialog();

            Task.Factory.StartNew(() => {
                Bitmap bmp = CreateBlurredImage(radius);
                return bmp;
            })
            .ContinueWith(task => {
                Bitmap bmp = task.Result;
                imageView.SetImageBitmap(bmp);
                seekbar.StopTrackingTouch += BlurImageHandler;
                seekbar.Enabled = true;
               // DismissIndeterminateProgressDialog();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private Bitmap CreateBlurredImage(int radius)
        {
            // Load a clean bitmap and work from that.
            Bitmap originalBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.winter);

            // Create another bitmap that will hold the results of the filter.
            Bitmap blurredBitmap;
            blurredBitmap = Bitmap.CreateBitmap(originalBitmap);

            // Create the Renderscript instance that will do the work.
            RenderScript rs = RenderScript.Create(this);

            // Allocate memory for Renderscript to work with
            Allocation input = Allocation.CreateFromBitmap(rs, originalBitmap, Allocation.MipmapControl.MipmapFull, AllocationUsage.Script);
            Allocation output = Allocation.CreateTyped(rs, input.Type);

            // Load up an instance of the specific script that we want to use.
            ScriptIntrinsicBlur script = ScriptIntrinsicBlur.Create(rs, Element.U8_4(rs));
            script.SetInput(input);

            // Set the blur radius
            script.SetRadius(radius);

            // Start the ScriptIntrinisicBlur
            script.ForEach(output);

            // Copy the output to the blurred bitmap
            output.CopyTo(blurredBitmap);

            return blurredBitmap;
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

