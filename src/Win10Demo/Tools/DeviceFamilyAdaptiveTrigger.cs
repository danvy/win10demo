using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Win10Demo.Tools
{ 
    public enum DeviceFamily
    {
        Unknown = 0, Desktop = 1, Mobile = 2, IoT = 3
    }
    public class DeviceFamilyAdaptiveTrigger : StateTriggerBase
    {
        private static string deviceFamily = string.Empty;
        public DeviceFamilyAdaptiveTrigger()
        {
            if (string.IsNullOrEmpty(deviceFamily))
            {
                var qualifiers = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().QualifierValues;
                if (qualifiers.ContainsKey("DeviceFamily"))
                    deviceFamily = qualifiers["DeviceFamily"];
            }
        }
        public static readonly DependencyProperty DeviceFamilyProperty =
            DependencyProperty.Register("DeviceFamily", typeof(string), typeof(DeviceFamilyAdaptiveTrigger),
            new PropertyMetadata(DeviceFamily.Unknown, OnDeviceFamilyPropertyChanged));
        public DeviceFamily DeviceFamily
        {
            get
            {
                return (DeviceFamily)GetValue(DeviceFamilyProperty);
            }
            set
            {
                SetValue(DeviceFamilyProperty, value);
            }
        }
        private static void OnDeviceFamilyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (DeviceFamilyAdaptiveTrigger)d;
            var val = (DeviceFamily)e.NewValue;
            if (deviceFamily == "Desktop")
            {
                obj.SetActive(val == DeviceFamily.Desktop);
            }
            else if (deviceFamily == "Mobile")
            {
                obj.SetActive(val == DeviceFamily.Mobile);
            }
            else
                obj.SetActive(val == DeviceFamily.Unknown);

        }
    }
}
