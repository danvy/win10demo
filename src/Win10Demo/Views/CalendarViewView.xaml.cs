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
	public sealed partial class CalendarViewView : Page
	{
		public CalendarViewView()
		{
			this.InitializeComponent();
			//TODO MinDat MaxDate get an exception
			//CustomCalendar.MinDate = DateTimeOffset.UtcNow.AddDays(-5);
			//CustomCalendar.MaxDate = DateTimeOffset.UtcNow.AddDays(5);
		}
	}
}
