using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Win10Demo.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class DragDropView : Page
	{
		public DragDropView()
		{
			this.InitializeComponent();
			//CoreDragDropManager.AllowDragTo = CoreDragDropScope.All;
			//CoreDragDropManager.AllowDropFrom = CoreDragDropScope.All;
			//var dragDropMan = CoreDragDropManager.GetForCurrentView();
			//dragDropMan.AreConcurrentOperationsEnabled = true;
			//dragDropMan.TargetRequested += DragDropMan_TargetRequested;
        }

		private void DragDropMan_TargetRequested(CoreDragDropManager sender, CoreDropOperationTargetRequestedEventArgs args)
		{
			Debug.WriteLine("Target requested");
			//args.SetTarget();
		}
        private async void DropGrid_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Any())
                {
                    DroppedBlock.Text = items[0].Name;
                    if (items[0].Name.ToLowerInvariant().Contains(".jpg"))
                    {
                        var file = items[0] as StorageFile;
                        var bitmap = new BitmapImage();
                        bitmap.SetSource(await file.OpenAsync(FileAccessMode.Read));
                        DroppedImage.Source = bitmap;
                    }
                }
            }
        }
        private void DropGrid_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                //var items = await e.DataView.GetStorageItemsAsync();
                //if (items.Any() && (items[0].Name.ToLowerInvariant().Contains(".jpg")))
                //    {
                //        e.DragUIOverride.Caption = "Dragging JPEG file";
                //        e.DragUIOverride.IsCaptionVisible = true;
                //        e.DragUIOverride.IsContentVisible = true;
                //        e.DragUIOverride.IsGlyphVisible = true;
                //    }
            }
            //e.DragUIOverride.SetContentFromBitmapImage(new BitmapImage(new Uri("ms-appx:///Assets/clippy.jpg")));
        }
        private void DropGrid_DragEnter(object sender, DragEventArgs e)
        {
            Log("DragEnter");
        }
        private void DropGrid_DragLeave(object sender, DragEventArgs e)
        {
            Log("DragLeave");
        }
        private void DropGrid_DropCompleted(UIElement sender, DropCompletedEventArgs args)
        {
            Log("DragCompleted");
        }
        private void Log(string message)
        {
            StatusBlock.Text = string.Format("{0} {1}", DateTime.Now, message);
        }
    }
}
