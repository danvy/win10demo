using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Devices.Power;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.System.Power;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Win10Demo.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class SysInfoView : Page
	{
		private Battery battery;
		public SysInfoView()
		{
			this.InitializeComponent();
			Loaded += SysInfoView_Loaded;
		}

		private void SysInfoView_Loaded(object sender, RoutedEventArgs e)
		{
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
			if (report.Status != BatteryStatus.NotPresent)
			{
				level = 100 * report.RemainingCapacityInMilliwattHours / report.FullChargeCapacityInMilliwattHours;
			}
			BatteryLevelText.Text = string.Format("Level={0}%", level);

			var sb = new StringBuilder();
			sb.AppendFormat("App Memory Usage Level={0}\n", MemoryManager.AppMemoryUsageLevel);
			//sb.AppendFormat("App Memory Usage={0}\n", MemoryManager.AppMemoryUsage);
			sb.AppendFormat("App Memory usage limit={0}\n", MemoryManager.AppMemoryUsageLimit);
			//var appReport = MemoryManager.GetAppMemoryReport();
			//sb.AppendFormat("Peak Private Commit Usage={0}\n", appReport.PeakPrivateCommitUsage);
			//sb.AppendFormat("Private Commit Usage={0}\n", appReport.PrivateCommitUsage);
			//sb.AppendFormat("Total Commit Limit={0}\n", appReport.TotalCommitLimit);
			//sb.AppendFormat("Total Commit Usage={0}\n", appReport.TotalCommitUsage);
			//var processReport = MemoryManager.GetProcessMemoryReport();
			//sb.AppendFormat("Private Working Set Usage={0}\n", processReport.PrivateWorkingSetUsage);
			//sb.AppendFormat("Total Working Set Usage={0}\n", processReport.TotalWorkingSetUsage);
			ReportText.Text = sb.ToString();

		}
	}
}
