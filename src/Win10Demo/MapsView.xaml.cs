using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	public sealed partial class MapsView : Page
	{
		public MapsView()
		{
			this.InitializeComponent();
			Loaded += MapsView_Loaded;
		}

		private void MapsView_Loaded(object sender, RoutedEventArgs e)
		{
			//Set the MapServiceToken
			//See how to https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn741528.aspx
			Map.MapServiceToken = "zTQEnMOtljUcQ_kEE9gedw";
		}
		private bool CheckMapServiceToken()
		{
			return !string.IsNullOrEmpty(Map.MapServiceToken);
		}
		private async void LocationAccessButton_Click(object sender, RoutedEventArgs e)
		{
			var status = await Geolocator.RequestAccessAsync();
			if (status == GeolocationAccessStatus.Allowed)
			{
				var message = new MessageDialog("Now I know where you are ;)");
				await message.ShowAsync();
			}
		}
		private async void FindMeButton_Click(object sender, RoutedEventArgs e)
		{
			var status = await Geolocator.RequestAccessAsync();
			if (status == GeolocationAccessStatus.Allowed)
			{
				var locator = new Geolocator();
				locator.DesiredAccuracy = PositionAccuracy.Default;
				var pos = await locator.GetGeopositionAsync();
				await Map.TrySetViewAsync(pos.Coordinate.Point, 10);
			}
		}

		private void ZoomSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
		{
			if (Map == null)
				return;
			Map.ZoomLevel = ZoomSlider.Value;
		}
	}
}
