using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Appointment
{
	[Activity (Label = "Appointment", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private TextView dateDisplay;
		private Button pickDate;
		private DateTime date;

		string[] items;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			dateDisplay = FindViewById<TextView> (Resource.Id.dateDisplay);
			pickDate = FindViewById<Button> (Resource.Id.pickDate);
			date = DateTime.Today;

			pickDate.Click += delegate 
			{
				Dialog SelectDate = new DatePickerDialog (this, OnDateSet, date.Year, date.Month - 1, date.Day);
				SelectDate.Show();
			};

			UpdateDisplay ();

			items = new string[] {
				"9.00 утро вечера мудренее", 
				"11.00 дорога к обеду ложка", 
				"13.00 сделал дело - гуляй смело",
				"15.00 время приёма занято",
				"17:00 время приёма 20 минут",
				"19:00 назвался груздем - полезай в кузов",
				"21:00 делу - время, потехе - час",
				"23:00 время приема окончено"
			};

			ListView MainList = FindViewById<ListView> (Resource.Id.mainList);
			IListAdapter MainListAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItem1, items);
			MainList.Adapter = MainListAdapter;

		}

		private void UpdateDisplay()
		{
			dateDisplay.Text = date.ToString ("dd-MM-yyyy");
		}

		void OnDateSet (object sender, DatePickerDialog.DateSetEventArgs e)
		{
			this.date = e.Date;
			UpdateDisplay ();
		}
	}	
}
