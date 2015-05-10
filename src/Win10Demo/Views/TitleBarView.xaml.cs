using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
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

namespace Win10Demo.Views
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
			appView.TitleBar.BackgroundColor = backgroundColor;
			appView.TitleBar.ForegroundColor = foregroundColor;
			appView.TitleBar.ButtonBackgroundColor = buttonBackgroundColor;
			appView.TitleBar.ButtonForegroundColor = buttonForegroundColor;
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = extended;
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
			UpdateTitle("Green attitude extended", Colors.DarkGreen, Colors.White, Colors.Green, Colors.White, true);
		}
        private void CustomTitleBarButton_Click(object sender, RoutedEventArgs e)
        {
            //var bar = new Grid();
            //bar.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            //bar.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            //bar.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            //bar.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            ////var min = new Button() { Content = "-" };
            ////min.Click += Min_Click;
            //var title = new TextBlock() { Text = "Custom" };
            //bar.Children.Add(title);
            //Grid.SetColumn(title, 0);
            //Window.Current.SetTitleBar(bar);
            //Window.Current.SetTitleBar(CustomBlock);
        }
    }
}
