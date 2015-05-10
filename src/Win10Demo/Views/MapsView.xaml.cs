using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
	public sealed partial class MapsView : Page
	{
		private RandomAccessStreamReference iconStream;
		public MapsView()
		{
			this.InitializeComponent();
			Loaded += MapsView_Loaded;
			Map.Loaded += Map_Loaded;
			iconStream = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/SmallLogoBlue.scale-100.png"));
		}
		private void Map_Loaded(object sender, RoutedEventArgs e)
		{
			Map.Center = new Geopoint(new BasicGeoposition() { Latitude = 48.832670, Longitude = 2.263034 });
			Map.ZoomLevel = 10;
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
		private void TrafficFlowToggle_Click(object sender, RoutedEventArgs e)
		{
			Map.TrafficFlowVisible = TrafficFlowToggle.IsChecked == true;
		}
		private void StyleCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (StyleCombo.SelectedIndex)
			{
				case 0:
					Map.Style = MapStyle.None;
					break;
				case 1:
					Map.Style = MapStyle.Road;
					break;
				case 2:
					Map.Style = MapStyle.Aerial;
					break;
				case 3:
					Map.Style = MapStyle.AerialWithRoads;
					break;
				case 4:
					Map.Style = MapStyle.Terrain;
					break;
			}
		}
		private void AddIconButton_Click(object sender, RoutedEventArgs e)
		{
			var icon = new MapIcon() { Location = Map.Center, Image = iconStream, ZIndex = 0 };
			Map.MapElements.Add(icon);
		}

		private void AddPolygonButton_Click(object sender, RoutedEventArgs e)
		{
			double lat = Map.Center.Position.Latitude;
			double lon = Map.Center.Position.Longitude;
			var polygon = new MapPolygon();
			polygon.Path = new Geopath(new List<BasicGeoposition>() {
				new BasicGeoposition() {Latitude = lat+0.0005, Longitude = lon-0.001 },
				new BasicGeoposition() {Latitude = lat-0.0005, Longitude = lon-0.001 },
				new BasicGeoposition() {Latitude = lat-0.0005, Longitude = lon+0.001 },
				new BasicGeoposition() {Latitude = lat+0.0005, Longitude = lon+0.001 },
			});
			polygon.FillColor = Colors.Transparent;
			polygon.StrokeColor = Colors.Green;
			polygon.StrokeThickness = 2;
			//mapPolygon.StrokeDashed = false;
			polygon.ZIndex = 0;
			Map.MapElements.Add(polygon);
		}
	}
}
