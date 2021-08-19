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
using Com.Airbnb.Lottie;
using Android.Animation;

namespace ResponderApp.Droid
{
    [Activity(Label = "EEDC Responder", MainLauncher = true, NoHistory = true, Theme = "@style/MyTheme.Splash")]
    public class SplashScreen : Activity, Animator.IAnimatorListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashLayout);

            var animation = FindViewById<LottieAnimationView>(Resource.Id.animation_view);

            animation.AddAnimatorListener(this);
        }


        public void OnAnimationCancel(Animator animation)
        {

        }

        public void OnAnimationEnd(Animator animation)
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public void OnAnimationRepeat(Animator animation)
        {

        }

        public void OnAnimationStart(Animator animation)
        {

        }
     
    }
}