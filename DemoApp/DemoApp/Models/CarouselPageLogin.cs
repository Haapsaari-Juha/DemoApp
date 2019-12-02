using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace DemoApp.Models
{
    public class CarouselPageLogin
    {
        public ImageSource Image { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }

        public CarouselPageLogin(ImageSource imageSource, string title) : this(imageSource, title, null)
        {
        }

        public CarouselPageLogin(ImageSource imageSource, string title, string text)
        {
            this.Image = imageSource;
            this.Title = title;
            this.Text = text;
        }
    }
}
