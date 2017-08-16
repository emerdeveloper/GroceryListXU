using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace GroceryList
{
	[Activity(Label = "Grocery List", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		public static List<Item> Items = new List<Item>();

		protected override void OnCreate(Bundle bundle)
		{
			Items.Add(new Item("Milk",     2));
			Items.Add(new Item("Crackers", 1));
			Items.Add(new Item("Apples",   5));

			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			FindViewById<Button>(Resource.Id.itemsButton  ).Click += OnItemsClick;
			FindViewById<Button>(Resource.Id.addItemButton).Click += OnAddItemClick;
			FindViewById<Button>(Resource.Id.aboutButton  ).Click += OnAboutClick;
		}

		void OnItemsClick(object sender, EventArgs e)
		{
            var intent = new Intent(this, typeof(ItemsActivity));//Explicit Intent
            StartActivity(intent);
		}

		void OnAddItemClick(object sender, EventArgs e)
		{
            var intent = new Intent(this, typeof(AddItemActivity));//Explicit Intent
            //init and go to other activity. its useful when we don't want retrieve data of go back 
            //StartActivity(intent);
            //this is the same that StartActivity, but this allows sent a identifer to identity an Activity of go back, 
            // this value will be useful when come back from second activity 
            StartActivityForResult(intent,//Bundle
                100);//identifer
        }

		void OnAboutClick(object sender, EventArgs e)
		{
            StartActivity(typeof(AboutActivity));//Intent
		}

        //This method is execute when we come back here from the second activity
        //we use this method to retrieve data that come from other Activity
		protected override void OnActivityResult(int requestCode, //this value help to identify the activity from we come back, this code is send from other Activity and have to the same that we send start, //identifer that we send initially when we use the method OnAddItemClick  
            Result resultCode, //A result code is an enum that an Activity uses to indicate success/failure
            Intent data)//The Intent loaded by the Target Activity
		{
            if (resultCode == Result.Ok && requestCode == 100) {
                //Retrieve the item name and count from the Intent Extras. 
                string name = data.GetStringExtra("ItemName");
                int count = data.GetIntExtra("ItemCount", -1);
                Items.Add(new Item(name , count));
            }
        }
	}
}