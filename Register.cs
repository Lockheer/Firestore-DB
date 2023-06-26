using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase;
using Firebase.Firestore;
using Android.Locations;
using Java.Util;

namespace TableFirebase
{
    [Activity(Label = "User Register")]
    public class Register : Activity
    {
        EditText editTextEmail, editTextAddress, editTextContact;
        Button buttonReturn;
        FirebaseFirestore db;
        AppDataHelper.AppDataHelper helper = new AppDataHelper.AppDataHelper();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.register);

            editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            editTextAddress = FindViewById<EditText>(Resource.Id.editTextAddress);
            editTextContact = FindViewById<EditText>(Resource.Id.editTextContact);
            buttonReturn = FindViewById<Button>(Resource.Id.buttonReturn);

            db = helper.getFireStore();

            buttonReturn.Click += ButtonReturn_Click;
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            if (editTextEmail.Text != "" && editTextAddress.Text != "" && editTextContact.Text != "")
            {
                if (editTextEmail.Text.Contains("@"))
                {
                    string FirstName, MiddleName, LastName, Email, ContactNo, Address;

                    FirstName = Intent.GetStringExtra("firstName");
                    MiddleName = Intent.GetStringExtra("middleName");
                    LastName = Intent.GetStringExtra("lastName");
                    Email = editTextEmail.Text;
                    Address = editTextAddress.Text;
                    ContactNo = editTextContact.Text;

                    HashMap userMap = new HashMap();
                    userMap.Put("First Name", FirstName);
                    userMap.Put("Middle Name", MiddleName);
                    userMap.Put("Last Name", LastName);
                    userMap.Put("Email", Email);
                    userMap.Put("Contact Number", ContactNo);
                    userMap.Put("Address", Address);

                    DocumentReference userRef = db.Collection("Customers Database").Document();
                    userRef.Set(userMap);

                    Toast.MakeText(this, "Successfully registered your information.", ToastLength.Short).Show();
                    StartActivity(typeof(Home));

                } else
                {
                    Toast.MakeText(this, "Please enter a valid email address", ToastLength.Short).Show();
                }   
            } 
           
            else
            {
                Toast.MakeText(this, "Please fill out the fields provided!", ToastLength.Short).Show();
            }
        }
    }
}