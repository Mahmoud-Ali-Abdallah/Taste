using System;
using Taste.UIServices.IServices;

namespace Taste.UIServices.Services
{
    public class ToastService : IToastService
    {
        public event Action<ToastLevel, string, string> OnShow;

        public void ShowError(string message, string heading = "")
        {
            ShowToast(ToastLevel.Error, message, heading);
        }

        public void ShowInfo(string message, string heading = "")
        {
            ShowToast(ToastLevel.Error, message, heading);
        }

        public void ShowSuccess(string message, string heading = "")
        {
            ShowToast(ToastLevel.Error, message, heading);
        }

        public void ShowToast(ToastLevel level, string message, string heading = "")
        {
            OnShow?.Invoke(level, message, heading);
            
        }

        public void ShowWarning(string message, string heading = "")
        {
            ShowToast(ToastLevel.Error, message, heading);
        }
    }
}
