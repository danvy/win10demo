using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Streaming.Adaptive;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Win10Demo.Views
{
	public sealed partial class MediaSourceView : Page
	{
		public MediaSourceView()
		{
			this.InitializeComponent();
			Loaded += MediaSourceView_Loaded;
		}
		private void MediaSourceView_Loaded(object sender, RoutedEventArgs e)
		{
			Media.BufferingProgressChanged += Media_BufferingProgressChanged;
			Media.CurrentStateChanged += Media_CurrentStateChanged;
		}
		private void Media_CurrentStateChanged(object sender, RoutedEventArgs e)
		{
			CurrentStateText.Text = string.Format("Current state={0}", Media.CurrentState);
		}
		private void Media_BufferingProgressChanged(object sender, RoutedEventArgs e)
		{
			BufferingProgressText.Text = string.Format("Buffering progress={0}", Media.BufferingProgress);
		}
		private async void VideoButton1_Click(object sender, RoutedEventArgs e)
		{
			await UpdateMediaSource("http://www.nasa.gov/multimedia/nasatv/NTV-Public-IPS.m3u8");
        }
		private async void VideoButton2_Click(object sender, RoutedEventArgs e)
		{
			await UpdateMediaSource("http://dash.edgesuite.net/dash264/TestCases/2a/qualcomm/1/MultiResMPEG2.mpd");
		}
		private async void VideoButton3_Click(object sender, RoutedEventArgs e)
		{
			await UpdateMediaSource("");
		}
		private async Task UpdateMediaSource(string url)
		{
			var mediaUri = new Uri(url);
			var mediaSource = await AdaptiveMediaSource.CreateFromUriAsync(mediaUri);
			if (mediaSource.Status == AdaptiveMediaSourceCreationStatus.Success)
				Media.SetMediaStreamSource(mediaSource.MediaSource);
		}
	}
}
