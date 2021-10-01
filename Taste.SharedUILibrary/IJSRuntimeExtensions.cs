using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Taste.SharedUILibrary
{
    public static class IJSRuntimeExtensions
    {
        public static ValueTask DiplayMessage(this IJSRuntime js , string message) 
        {
            return js.InvokeVoidAsync("Swal.fire", message);
        }

        public static ValueTask DiplayMessage(this IJSRuntime js , string title , string message , SweetAlertMessageType sweetAlertMessageType)
        {
            return js.InvokeVoidAsync("Swal.fire", title, message, sweetAlertMessageType.ToString().ToLower());
        }

        public static ValueTask<bool> Confirm(this IJSRuntime js, string title, string message, SweetAlertMessageType sweetAlertMessageType)
        {
            return js.InvokeAsync<bool>("CustomConfirm", title, message, sweetAlertMessageType.ToString().ToLower());
        }
    }

    public enum SweetAlertMessageType
    {
        Question, Warning, Error, Success, Info 
    }
}
