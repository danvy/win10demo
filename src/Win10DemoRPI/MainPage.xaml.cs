using System;
using System.Diagnostics;
using Windows.Devices.Gpio;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Win10DemoRPI
{
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer;
        private GpioPin pin13 = null;
        private bool ledOn = true;
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
        }

        private void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
            pin13.Dispose();
        }

        private void Timer_Tick(object sender, object e)
        {
            if (pin13 != null)
            {
                pin13.Write(ledOn ? GpioPinValue.High : GpioPinValue.Low);
                ledOn = !ledOn;
            }
        }
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                await statusBar.HideAsync();
            }
            timer.Start();
            HeartBeatStoryboard.Begin();
            if (ApiInformation.IsTypePresent("Windows.Devices.Gpio.GpioController"))
            {
                var gpio = GpioController.GetDefault();
                if (gpio != null)
                {
                    pin13 = gpio.OpenPin(27);
                    pin13.SetDriveMode(GpioPinDriveMode.Output);
                }
            }
        }
    }
}
