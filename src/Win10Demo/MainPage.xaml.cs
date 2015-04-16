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
		private void MenuButton_Click(object sender, RoutedEventArgs e)
		{
			MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
		}
		private void Navigate(Type view)
		{
			var frame = this.DataContext as Frame;
			Page page = frame?.Content as Page;
			if (page?.GetType() != view)
			{
				frame.Navigate(view);
			}
			MenuSplitView.IsPaneOpen = false;
        }
		private void MediaSourceButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(MediaSourceView));
		}
		private void TitleBarButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(TitleBarView));
		}
		private void KeyAcceleratorButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(KeyAcceleratorView));
		}
		private void DrapDropButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(DragDropView));
		}
		private void TestButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(TestView));
		}
		private void LauncherButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(LauncherView));
		}
		private void RelativePanelButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(RelativePanelView));
		}
		private void PivotButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(PivotView));
		}
		private void InkButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(InkView));
		}
		private void SplitViewButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(SplitViewView));
		}
		private void MapControlButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(MapsView));
		}
		private void SpeechButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(SpeechView));
		}
		private void CalendarViewButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(CalendarViewView));
		}
		private void HomeButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(HomeView));
		}
		private void SysInfoButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(typeof(SysInfoView));
		}
	}
}
