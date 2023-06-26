using Android.App;
using Android.Content;
using Android.Icu.Text;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase;
using Firebase.Firestore;
using Google.Android.Material.Tabs;
using Java.Lang;
using Java.Lang.Reflect;
using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace TableFirebase
{
    [Activity(Label = "Details")]
    public class MainActivity : AppCompatActivity
    {
        EditText editTextFname, editTextMname, editTextLname;
        Button buttonNext;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            editTextFname = FindViewById<EditText>(Resource.Id.editTextFname);
            editTextMname = FindViewById<EditText>(Resource.Id.editTextMname);
            editTextLname = FindViewById<EditText>(Resource.Id.editTextLname);
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);

            buttonNext.Click += ButtonNext_Click;
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (editTextFname.Text != "" && editTextMname.Text != "" && editTextLname.Text != "")
            {
                string FirstName, MiddleName, LastName;

                FirstName = editTextFname.Text;
                MiddleName = editTextMname.Text;
                LastName = editTextLname.Text;

                Intent intent = new Intent(this, typeof(Register));
                intent.PutExtra("firstName", FirstName);
                intent.PutExtra("middleName", MiddleName);
                intent.PutExtra("lastName", LastName);
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "Please fill out fields provided!", ToastLength.Short).Show();
            }
        }
    }
}