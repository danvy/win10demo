using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechRecognition;
using Windows.Media.SpeechSynthesis;
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
	public sealed partial class SpeechView : Page
	{
		private MediaElement mediaElement;
		private SpeechSynthesizer speech;

		public SpeechView()
		{
			this.InitializeComponent();
		}
		private async void ReadButton_Click(object sender, RoutedEventArgs e)
		{
			if (speech == null)
			{
				speech = new SpeechSynthesizer();
				var language = CultureInfo.CurrentCulture.ToString();
				var voices = SpeechSynthesizer.AllVoices.Where(v => v.Language == language).OrderByDescending(v => v.Gender);
				speech.Voice = voices.FirstOrDefault(v => v.Gender == VoiceGender.Female);
			}
			if (mediaElement == null)
			{
				mediaElement = new MediaElement();
			}
			var message = MessageBox.Text;
			if (!string.IsNullOrEmpty(message))
			{
				var result = await speech.SynthesizeTextToStreamAsync(message);
				if (mediaElement.CurrentState != MediaElementState.Stopped)
					mediaElement.Stop();
				mediaElement.SetSource(result, result.ContentType);
				mediaElement.Play();
			}
		}

		private void ListenButton_Click(object sender, RoutedEventArgs e)
		{
			//var recognizer = new SpeechRecognizer();
			//recognizer.Constraints.Add(
			//recognizer.
			//var result = await recognizer.RecognizeAsync();
			//result.
		}
	}
}
