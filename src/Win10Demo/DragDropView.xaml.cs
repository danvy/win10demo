using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
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
	public sealed partial class DragDropView : Page
	{
		public DragDropView()
		{
			this.InitializeComponent();
			//CoreDragDropManager.AllowDragTo = CoreDragDropScope.All;
			//CoreDragDropManager.AllowDropFrom = CoreDragDropScope.All;
			var dragDropMan = CoreDragDropManager.GetForCurrentView();
			dragDropMan.AreConcurrentOperationsEnabled = true;
			dragDropMan.TargetRequested += DragDropMan_TargetRequested;
        }

		private void DragDropMan_TargetRequested(CoreDragDropManager sender, CoreDropOperationTargetRequestedEventArgs args)
		{
			Debug.WriteLine("Target requested");
			//args.SetTarget();
		}

		private void AvailableListBox_DragStarting(UIElement sender, DragStartingEventArgs args)
		{
			Debug.WriteLine("DragStarting");
			args.DragVisualKind = DragVisualKind.DataFormat;

			//if (item == null)
			//	return;
			//args.Data.Properties.Add("item", item);
			//args.Data.Properties.Add("gridSource", sender);
		}
		private void AvailableListBox_DragEnter(object sender, DragEventArgs e)
		{
			Debug.WriteLine("DragEnter");
		}
		private void AvailableListBox_DragLeave(object sender, DragEventArgs e)
		{
			Debug.WriteLine("DragLeave");
		}

		private void AvailableListBox_DragOver(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
			Debug.WriteLine("DragOver");
		}

		private void AvailableListBox_Drop(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
			object sourceItem;
			e.Data.Properties.TryGetValue("item", out sourceItem);
			if (sourceItem != null)
			{
				SelectedListBox.Items.Add(sourceItem);
			}
			Debug.WriteLine("Drop");
		}

		private void AvailableListBox_DropCompleted(UIElement sender, DropCompletedEventArgs args)
		{
			Debug.WriteLine("DropCompleted");
		}
	}
}
