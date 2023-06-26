using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Firebase.Firestore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableFirebase
{
    [Activity(Label = "RodriguezFirebaseTable", Theme = "@style/AppTheme", MainLauncher = true)]
    public class Home : Activity, IOnSuccessListener, IOnFailureListener
    {
        TableLayout tableLayoutCustomers;
        Button buttonRegister;
        AppDataHelper.AppDataHelper appDataHelper = new AppDataHelper.AppDataHelper();
        FirebaseFirestore database;
        Customers customers = new Customers();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.home);

            // Create your application here

            tableLayoutCustomers = FindViewById<TableLayout>(Resource.Id.tableLayoutCustomers);
            buttonRegister = FindViewById<Button>(Resource.Id.buttonRegister);
            
            customers.tableLayoutCustomers = tableLayoutCustomers;
            database = appDataHelper.getFireStore();
            fetchData();

            buttonRegister.Click += ButtonRegister_Click;
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof (MainActivity));
            StartActivity(intent);
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            var snapshot = (QuerySnapshot)result;

            if (!snapshot.IsEmpty)
            {
                var documents = snapshot.Documents;

                foreach (var item in documents)
                {
                    customers.firstName = item.Get("First Name").ToString();
                    customers.lastName = item.Get("Last Name").ToString();
                    customers.middleName = item.Get("Middle Name").ToString();

                    customers.addRow(customers.firstName, customers.lastName, customers.middleName);
                }
            }
        }

        public void OnFailure(Java.Lang.Exception e)
        {
            Toast.MakeText(this, "Load data failed!", ToastLength.Short).Show();
        }
        
        void fetchData()
        {
            database.Collection("Customers Database").Get()
                .AddOnSuccessListener(this)
                .AddOnFailureListener(this);
        }
    }
}