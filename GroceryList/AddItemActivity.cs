using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GroceryList
{
	[Activity(Label = "Add Item")]			
	public class AddItemActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.AddItem);

			FindViewById<Button>(Resource.Id.saveButton  ).Click += OnSaveClick;
			FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
		}

        void OnSaveClick(object sender, EventArgs e)
        {
            string name = FindViewById<EditText>(Resource.Id.nameInput).Text;
            int count = int.Parse(FindViewById<EditText>(Resource.Id.countInput).Text);

            var intent = new Intent();
            intent.PutExtra("ItemName", name);
            intent.PutExtra("ItemCount", count);
            //this let's save data of we want to return
            SetResult(Result.Ok, //A result code is an enum that an Activity uses to indicate success/failure
                 intent);
            //SetResult(Result.Ok);
            Finish();//we come back to MainActivity
		}

		void OnCancelClick(object sender, EventArgs e)
		{
            Finish();// Finish an Activity, this we go back to Activity before
		}
	}
}