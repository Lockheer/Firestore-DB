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

namespace TableFirebase
{
    public class Customers : Activity
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }

        public TableLayout tableLayoutCustomers;

        public void addRow(string fname, string mname, string lname)
        {
            TextView firstname = new TextView(Application.Context);
            firstname.Text = fname;
            firstname.SetTextColor(Android.Graphics.Color.Black);

            TextView middlename = new TextView(Application.Context);
            middlename.Text = mname;
            middlename.SetTextColor(Android.Graphics.Color.Black);

            TextView lastname = new TextView(Application.Context);
            lastname.Text = lname;
            lastname.SetTextColor(Android.Graphics.Color.Black);

            TableRow tr = new TableRow(Application.Context);

            tr.AddView(firstname);
            tr.AddView(middlename);
            tr.AddView(lastname);
            tableLayoutCustomers.AddView(tr);
        }
    }
}