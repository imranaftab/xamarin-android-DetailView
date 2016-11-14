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
using Android.Graphics;
using System.Net;
using System.Net.Http;

namespace NKitchen.Utilities
{
    public class ImageUtil
    {
        public static async System.Threading.Tasks.Task<Bitmap> GetImgFromURL(string url)
        {
            Bitmap img = null;
            using (var client = new HttpClient())
            {
                var imageData = await client.GetByteArrayAsync(url);
                if (imageData != null && imageData.Length > 0)
                    img = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            }

            return img;
        }
    }
}