using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
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
	public sealed partial class InkView : Page
	{
		private MemoryStream inkStream;
		private InkManager inkManager;

		public InkView()
		{
			this.InitializeComponent();
			inkStream = new MemoryStream();
			inkManager = new InkManager();
			Ink.InkPresenter.IsInputEnabled = true;
			Ink.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch;
        }

		private async void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			await inkManager.SaveAsync(inkStream.AsOutputStream());
		}
		private async void LoadButton_Click(object sender, RoutedEventArgs e)
		{
			if ((inkStream != null) && (inkStream.Length > 0))
			{
				inkStream.Position = 0;
				await inkManager.LoadAsync(inkStream.AsInputStream());
			}
		}
		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			var strokes = inkManager.GetStrokes();
			foreach (var stroke in strokes)
			{
				stroke.Selected = true;
			}
			inkManager.DeleteSelected();
		}
		private void RecognizeButton_Click(object sender, RoutedEventArgs e)
		{
			var sb = new StringBuilder();
			var results = inkManager.GetRecognitionResults();
			foreach (var result in results)
			{
				sb.AppendLine(result.GetTextCandidates().FirstOrDefault());
			}
			RecognitionText.Text = sb.ToString();
		}
	}
}
