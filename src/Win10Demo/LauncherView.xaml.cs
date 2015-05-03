using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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
	public sealed partial class LauncherView : Page
	{
		public LauncherView()
		{
			this.InitializeComponent();
		}

		private async void LaunchFolder_Click(object sender, RoutedEventArgs e)
		{
			var options = new FolderLauncherOptions();
			options.DesiredRemainingView = ViewSizePreference.UseHalf;
			await Launcher.LaunchFolderAsync(KnownFolders.PicturesLibrary, options);
		}
		private async void LaunchSettings_Click(object sender, RoutedEventArgs e)
		{
			//More options available https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn741261.aspx
			await Launcher.LaunchUriAsync(new Uri("ms-settings://network/wifi"));
		}
		private async void LaunchUriForResult_Click(object sender, RoutedEventArgs e)
		{
			var protocol = "win10demo2://";
			var packageFamilyName = "0df93276-6bbb-46fa-96b7-ec223e226505_cb1hhkscw5m06";
			var status = await Launcher.QueryUriSupportAsync(new Uri(protocol), LaunchQuerySupportType.UriForResults, packageFamilyName);
			if (status == LaunchQuerySupportStatus.Available)
			{
				var options = new LauncherOptions
				{
					TargetApplicationPackageFamilyName = packageFamilyName
				};
				var values = new ValueSet();
				values.Add("TwitterId", "danvy");
				var result = await Launcher.LaunchUriForResultsAsync(new Uri(protocol), options, values);
				if (result.Status == LaunchUriStatus.Success)
				{
					var authorized = result.Result["Authorized"] as string;
					if (authorized == true.ToString())
					{
						var dialog = new MessageDialog("You are authorized :)");
						await dialog.ShowAsync();
					}
				}
			}
		}
		private async void CallService_Click(object sender, RoutedEventArgs e)
		{
			var connection = new AppServiceConnection();
			connection.PackageFamilyName = "0df93276-6bbb-46fa-96b7-ec223e226505_cb1hhkscw5m06"; // Windows.ApplicationModel.Package.Current.Id.FamilyName;
			connection.AppServiceName = "CalculatorService";
			var status = await connection.OpenAsync();
			if (status != AppServiceConnectionStatus.Success)
			{
				var dialog = new MessageDialog("Sorry, I can't connect to the service right now :S");
				await dialog.ShowAsync();
				return;
			}
			var message = new ValueSet();
			message.Add("service", OperatorCombo.Items[OperatorCombo.SelectedIndex]);
			message.Add("a", Convert.ToInt32(ValueABox.Text));
			message.Add("b", Convert.ToInt32(ValueBBox.Text));
			AppServiceResponse response = await connection.SendMessageAsync(message);
			if (response.Status == AppServiceResponseStatus.Success)
			{
				if (response.Message.ContainsKey("result"))
				{
					ResultBlock.Text = response.Message["result"] as string;
				}
			}
			else
			{
				var dialog = new MessageDialog(string.Format("Opps, I just get an error :S ({0})", response.Status));
				await dialog.ShowAsync();
			}
		}
        private async Task WriteFileAsync(string filename, string content)
		{
			var folder = ApplicationData.Current.GetPublisherCacheFolder("SharedFolder");
			var file = await folder.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.ReplaceExisting);
			var fs = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
			var outStream = fs.GetOutputStreamAt(0);
			var dataWriter = new Windows.Storage.Streams.DataWriter(outStream);
			dataWriter.WriteString(content);
			await dataWriter.StoreAsync();
			dataWriter.DetachStream();
			await outStream.FlushAsync();
		}

		private async void WriteSharedsFileButton_Click(object sender, RoutedEventArgs e)
		{
			await WriteFileAsync("SharedFile.txt", SharedFileBox.Text);
		}
	}
}
