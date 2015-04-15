using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
	public sealed partial class TitleBarView : Page
	{
		public TitleBarView()
		{
			this.InitializeComponent();
		}
		public void UpdateTitle(string title, Color backgroundColor, Color foregroundColor, Color buttonBackgroundColor, Color buttonForegroundColor, bool extended = false)
		{
			var appView = ApplicationView.GetForCurrentView();
			appView.Title = title;
			appView.TitleBar.ExtendViewIntoTitleBar = extended;
			appView.TitleBar.BackgroundColor = backgroundColor;
			appView.TitleBar.ForegroundColor = foregroundColor;
			appView.TitleBar.ButtonBackgroundColor = buttonBackgroundColor;
			appView.TitleBar.ButtonForegroundColor = buttonForegroundColor;
		}

		private void BlueTitleBarButton_Click(object sender, RoutedEventArgs e)
		{
			UpdateTitle("Life in blue", Colors.DarkBlue, Colors.White, Colors.Blue, Colors.White);
		}

		private void RedTitleBarButton_Click(object sender, RoutedEventArgs e)
		{
			UpdateTitle("Red flag", Colors.DarkRed, Colors.White, Colors.Red, Colors.White);
		}

		private void GreenTitleBarButton_Click(object sender, RoutedEventArgs e)
		{
			UpdateTitle("Green attitude", Colors.DarkRed, Colors.White, Colors.Red, Colors.White, true);
		}
	}
}
