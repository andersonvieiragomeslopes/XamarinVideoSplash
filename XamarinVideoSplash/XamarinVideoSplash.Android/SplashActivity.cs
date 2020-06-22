using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Media.MediaPlayer;

namespace XamarinVideoSplash.Droid
{
    [Activity(Label = "Splash Video", MainLauncher = true)]
    public class SplashActivity : Activity, IOnCompletionListener
    {
        VideoView VideoView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splash);
            Window.AddFlags(WindowManagerFlags.Fullscreen);

            VideoView = FindViewById<VideoView>(Resource.Id.videoviewsplash);
            VideoView.SetOnCompletionListener(this);
            var urlvideo = Android.Net.Uri.Parse("https://cdn.liftoff.io/customers/3372b4e3dc/videos/mobile/9efc794c8999720f15b4.mp4");
            VideoView.SetVideoURI(urlvideo);
            VideoView.Start();            

            // Create your application here
        }
        public void OnCompletion(MediaPlayer mediaPlayer)
        {
            Task.Delay(200).ContinueWith(t =>
            {
                StartActivity(new Intent(this, typeof(MainActivity)));
                Finish();
            });
        }
    }
}