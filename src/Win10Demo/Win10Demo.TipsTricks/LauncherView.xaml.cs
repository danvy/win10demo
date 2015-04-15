using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
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
			options.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseHalf;
			await Launcher.LaunchFolderAsync(KnownFolders.PicturesLibrary, options);
		}
		private async void LaunchSettings_Click(object sender, RoutedEventArgs e)
		{
			await Launcher.LaunchUriAsync(new Uri("ms-settings://network/wifi"));
		}
        private async void LaunchUriForResult_Click(object sender, RoutedEventArgs e)
		{
			//TODO LaunchUriForResult
			var options = new LauncherOptions
			{
				TargetApplicationPackageFamilyName = "Desired.App_fahbwp72s5828"
			};
			var result = await Launcher.LaunchUriForResultsAsync(new Uri("custom://auth?username=test"), options);
			if (result.Status == LaunchUriStatus.Success)
			{
			}
		}
	}
}
