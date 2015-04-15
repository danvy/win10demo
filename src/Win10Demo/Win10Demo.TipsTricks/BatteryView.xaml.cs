using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.Power;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Win10Demo
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class BatteryView : Page
	{
		private Battery battery;
		public BatteryView()
		{
			this.InitializeComponent();
			Loaded += BatteryView_Loaded;
		}

		private void BatteryView_Loaded(object sender, RoutedEventArgs e)
		{
			//var devInfo = await DeviceInformation.FindAllAsync(Battery.GetDeviceSelector());
			//foreach (DeviceInformation device in devInfo)
			//{
			//	var battery = await Battery.FromIdAsync(device.Id);
			//	var report = battery.GetReport();
			//}
			battery = Battery.AggregateBattery;
            battery.ReportUpdated += async (s, args) =>
			{
				await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
				{
					UpdateUI();
				});
			};
			UpdateUI();
		}
		private void UpdateUI()
		{
			var report = battery.GetReport();
			BatteryStatusText.Text = string.Format("Status={0}", report.Status);
			BatteryLevelText.Text = string.Format("ChargeRateInMilliwatts={0}", report.ChargeRateInMilliwatts);
			BatteryLevelText.Text = string.Format("DesignCapacityInMilliwattHours={0}", report.DesignCapacityInMilliwattHours);
			BatteryLevelText.Text = string.Format("FullChargeCapacityInMilliwattHours={0}", report.FullChargeCapacityInMilliwattHours);
			BatteryLevelText.Text = string.Format("RemainingCapacityInMilliwattHours={0}", report.RemainingCapacityInMilliwattHours);
			int? level = 0;
			if (report.Status != Windows.System.BatteryStatus.NotPresent)
			{
				level = 100 * report.RemainingCapacityInMilliwattHours / report.FullChargeCapacityInMilliwattHours;
			}
			BatteryLevelText.Text = string.Format("Level={0}%", level);
		}
	}
}
