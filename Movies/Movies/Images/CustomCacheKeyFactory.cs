using FFImageLoading.Work;
using System;
using System.Collections.Generic;
using System.Text;
using FFImageLoading.Forms;

namespace Movies.Images
{
    public class CustomCacheKeyFactory : ICacheKeyFactory
    {
        public string GetKey(Xamarin.Forms.ImageSource imageSource, object bindingContext)
        {
            var keySource = imageSource as CustomStreamImageSource;

            if (keySource == null)
                return null;

            return keySource.Key;
        }
    }
}
