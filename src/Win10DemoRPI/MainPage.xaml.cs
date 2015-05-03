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
        private GpioPin pin1 = null;
        private GpioPin pin2 = null;
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(500);
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, object e)
        {
            if (pin2 != null)
            {
                pin2.Read();
            }            
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
            HeartBeatStoryboard.Begin();
            if (ApiInformation.IsApiContractPresent("Windows.Devices.DevicesLowLevelContract", 0))
            {
                var gpio = GpioController.GetDefault();
                GpioOpenStatus status = default(GpioOpenStatus);
                if (gpio.TryOpenPin(1, GpioSharingMode.SharedReadOnly, out pin1, out status))
                {
                    if (status == GpioOpenStatus.PinOpened)
                    {
                        pin1.ValueChanged += Pin1_ValueChanged;
                    }
                }
                if (gpio.TryOpenPin(2, GpioSharingMode.SharedReadOnly, out pin2, out status))
                {
                    if (status == GpioOpenStatus.PinOpened)
                    {
                    }
                }
            }
        }
        private void Pin1_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            Debug.WriteLine("Pin1");
        }
    }
}
