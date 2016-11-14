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
using NKitchen.Utilities;

namespace NKitchen
{
    [Activity(Label = "Seekh Kabab", MainLauncher = true)]
    public class DishDetail : Activity
    {
        private ImageView img_Dish;
        private TextView lbl_DishName;
        private TextView lbl_DishDiscription;
        private TextView lbl_DishPrice;
        private EditText txt_OrderNoOfItems;
        private Button btn_Cancel;
        private Button btn_Buy;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.DishDetail);

            init_DishDetails();
            load_DishDetails();
            attach_Events();
        }

        private void attach_Events()
        {
            btn_Buy.Click += Btn_Buy_Click;
        }
        public void Btn_Buy_Click(object sender, EventArgs ev)
        {
            var d = new AlertDialog.Builder(this);
            int noOfItems;
            if (Int32.TryParse(txt_OrderNoOfItems.Text, out noOfItems))
            {
                d.SetTitle("Congratulations!");
                d.SetMessage("You bought" + txt_OrderNoOfItems.Text + " " + lbl_DishName.Text);
            }
            else
            {
                d.SetTitle("Invalid Input!");
                d.SetMessage("Please enter valid number!");
            }
            d.Show();
        }
        private async void load_DishDetails()
        {
            lbl_DishName.Text = "Seekh Kabab";
            lbl_DishDiscription.Text = "A delicious spicy recipe of beef seekh kebab cooked on your stove. Extra tender beef seekh kebab seasoned with raw papaya and flavorful ingredients";
            lbl_DishPrice.Text = "500 Rs/-";
            var img = await ImageUtil.GetImgFromURL("http://lh3.googleusercontent.com/-ysMvmXrN_wk/UxApr6KTn8I/AAAAAAAAA3w/PNw9CibeMM0/s1260/SeekhKabab.jpg");
            img_Dish.SetImageBitmap(img);
        }

        private void init_DishDetails()
        {
            lbl_DishName = FindViewById<TextView>(Resource.Id.dishNameTextView);
            lbl_DishDiscription = FindViewById<TextView>(Resource.Id.dishDescriptionTextView);
            lbl_DishPrice = FindViewById<TextView>(Resource.Id.dishPriceTextView);

            txt_OrderNoOfItems = FindViewById<EditText>(Resource.Id.itemsEditText);


            btn_Buy = FindViewById<Button>(Resource.Id.btnBuy);
            btn_Cancel = FindViewById<Button>(Resource.Id.btnCancel);

            img_Dish = FindViewById<ImageView>(Resource.Id.dishImage);

        }
    }
}