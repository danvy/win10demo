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

namespace Win10Demo
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class KeyAcceleratorView : Page
	{
		public KeyAcceleratorView()
		{
			this.InitializeComponent();
		}

		private void KeyT_Pressed(KeyAccelerator sender, object args)
		{
			KeyPressedText.Text = "'T' key pressed";
		}
		private void KeyCtrlT_Pressed(KeyAccelerator sender, object args)
		{
			KeyPressedText.Text = "'T' key pressed with 'Control'";
		}
		private void KeyMenuT_Pressed(KeyAccelerator sender, object args)
		{
			KeyPressedText.Text = "'T' key pressed with 'Menu'";
		}
	}
}
