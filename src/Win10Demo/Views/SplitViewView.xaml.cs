using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
	public sealed partial class SplitViewView : Page
	{
		public SplitViewView()
		{
			this.InitializeComponent();
		}

		private void MenuButton_Click(object sender, RoutedEventArgs e)
		{
			Split.IsPaneOpen = !Split.IsPaneOpen;
		}

		private void RadioButton_Click(object sender, RoutedEventArgs e)
		{
			Split.IsPaneOpen = false;
			var button = sender as RadioButton;
			if (button != null)
			{
				SelectedMenuText.Text = button.Content.ToString();
			}
		}
	}
}
