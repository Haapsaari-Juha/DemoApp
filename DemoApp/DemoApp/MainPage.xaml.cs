using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Reflection;

namespace DemoApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private int carouselPosition;
        private List<Models.CarouselPageLogin> carouselPages;
        private string message;

        public MainPage()
        {
            InitializeComponent();
            
            var assembly = this.GetType();

            List<Models.CarouselPageLogin> carouselPages = new List<Models.CarouselPageLogin>
            {
                new Models.CarouselPageLogin(ImageSource.FromResource("DemoApp.Images.loginFirst.jpg"), "Welcome to the Bike APP!", "The app for every bicycle owner! Sign in and start to build your digital bike garage. You can sign in using your existing account (Facebook, Google or Microsoft), or you can create a new account just for Bike APP."),
                new Models.CarouselPageLogin(ImageSource.FromResource("DemoApp.Images.loginGarage.jpg"), "Your digital bike garage", "Build your bike configurations is easy with information other users have provided to database. Store your bike serial numbers, warranty information and keep track of components you own."),
                new Models.CarouselPageLogin(ImageSource.FromResource("DemoApp.Images.loginComponents.jpg"), "Find suitable components", "Ever wondered what components and spare parts fits your bike? Bike APP helps you to find suitable components for your bikes."),
                new Models.CarouselPageLogin(ImageSource.FromResource("DemoApp.Images.loginMaintenance.jpg"), "Keep your bike in shape", "Bikes require maintenance and Bike APP helps you to track and plan your bike maintenance. You get reminders when components need maintenance and also bike shops can track the maintenance for you."),
                new Models.CarouselPageLogin(ImageSource.FromResource("DemoApp.Images.loginSetups.jpg"), "Log and share setups", "What was tyre pressures and fork rebound adjustment in last year?. No worries, check from Bike APP your past setups and how those have worked.")
            };

            this.CarouselPages = carouselPages;
            this.Message = "Demo APP";

            this.BindingContext = this;
        }

        /*protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/

        public int CarouselPosition
        {
            get { return this.carouselPosition; }
            set
            {
                if (this.carouselPosition != value)
                {
                    this.carouselPosition = value;
                    OnPropertyChanged("CarouselPosition");
                    OnPropertyChanged("CurrentImage");
                }
            }
        }

        public ImageSource CurrentImage
        {
            get
            {
                ImageSource returnValue = null;

                if (this.CarouselPosition >= 0 && this.CarouselPages?.Count > 0)
                {
                    returnValue = this.CarouselPages[this.CarouselPosition].Image;
                }

                return returnValue;
            }
        }

        public List<Models.CarouselPageLogin> CarouselPages
        {
            get { return this.carouselPages; }
            set { 
                if (this.carouselPages != value)
                {
                    this.carouselPages = value;
                    OnPropertyChanged("CarouselPages");
                }
            }
        }

        public string Message
        {
            get { return this.message; }
            set
            {
                if (this.message != value)
                {
                    this.message = value;
                    OnPropertyChanged("Message");
                    OnPropertyChanged("ShowMessage");
                }
            }
        }

        public bool ShowMessage
        {
            get { return !String.IsNullOrWhiteSpace(this.Message); }
        }
    }
}
