using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Win10Demo
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
		private void KeyCtrlT_Pressed(KeyAccelerator sender, object args)
		{
			//var dialog = new MessageDialog("You pressed CTRL+T");
			//await dialog.ShowAsync();
		}
		private void MediaSourceButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MediaSourceView));
		}
		private void TitleBarButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(TitleBarView));
		}
		private void KeyAcceleratorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(KeyAcceleratorView));
		}
		private void DrapDropButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(DragDropView));
		}
		private void BatteryButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(BatteryView));
		}
		private void TestButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(TestView));
		}
		private void MemoryButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MemoryView));
		}
		private void LauncherButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(LauncherView));
		}

		private void RelativePanelButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(RelativePanelView));
		}
		private void PivotButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(PivotView));
		}
		private void InkButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(InkView));
		}
		private void SplitViewButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(SplitViewView));
		}

		private void MapControlButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MapsView));
		}

		private void SpeechButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(SpeechView));
		}
	}
}
