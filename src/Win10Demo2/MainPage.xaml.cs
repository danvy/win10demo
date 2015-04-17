using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Win10Demo2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		private ProtocolForResultsActivatedEventArgs pfrArgs;
		private string twitterId;

		public MainPage()
        {
            this.InitializeComponent();
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			pfrArgs = e.Parameter as ProtocolForResultsActivatedEventArgs;
			if (pfrArgs != null)
			{
				twitterId = pfrArgs.Data["TwitterId"] as string;
				IdBlock.Text = twitterId;
			}
		}

		private void ReturnResult()
		{
			if (pfrArgs != null)
			{
				var values = new ValueSet();
				values.Add("TimeStamp", DateTime.Now.ToString());
				values.Add("Authorized", (IdBlock.Text == "danvy").ToString());
				pfrArgs.ProtocolForResultsOperation.ReportCompleted(values);
			}
		}
		private void ValidateButton_Click(object sender, RoutedEventArgs e)
		{
			ReturnResult();
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			ReturnResult();
		}
	}
}
