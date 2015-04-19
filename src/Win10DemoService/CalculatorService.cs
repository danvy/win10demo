using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace Win10DemoService
{
	public sealed class CalculatorService : IBackgroundTask
	{
		private AppServiceConnection connection;
		private BackgroundTaskDeferral deferral;

		public void Run(IBackgroundTaskInstance taskInstance)
		{
			deferral = taskInstance.GetDeferral();
			taskInstance.Canceled += TaskInstance_Canceled;
			var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
			connection = details.AppServiceConnection;
			connection.RequestReceived += Connection_RequestReceived; ;
		}

		private async void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
		{
			var reqDeferral = args.GetDeferral();
			var message = args.Request.Message;
            var result = new ValueSet();
			if (args.Request.Message.ContainsKey("service"))
			{
				var serviceName = message["service"] as string;
				if (serviceName.Equals("add", StringComparison.OrdinalIgnoreCase))
				{
					if (message.ContainsKey("a") && message.ContainsKey("b"))
					{
						result.Add("result", Add((int)message["a"], (int)message["b"]));
					}
				}
				else if (serviceName.Equals("sub", StringComparison.OrdinalIgnoreCase))
				{
					if (message.ContainsKey("a") && message.ContainsKey("b"))
					{
						result.Add("result", Sub((int)message["a"], (int)message["b"]));
					}
				}
			}
			await args.Request.SendResponseAsync(result);
			reqDeferral.Complete();
		}
		private void TaskInstance_Canceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
		{
			if (deferral != null)
				deferral.Complete();
		}
		private int Add(int a, int b)
		{
			return a + b;
		}
		private int Sub(int a, int b)
		{
			return a - b;
		}
	}
}
