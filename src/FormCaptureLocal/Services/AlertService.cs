using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FormCaptureLocal.Services
{
    /// <summary>
    /// Service for displaying or closing alerts.
    /// </summary>
    public class AlertService
    {
        /// <summary>
        /// Field for JSRuntime class instance.
        /// </summary>
        private readonly IJSRuntime _jSRuntime;

        public AlertService(IJSRuntime jSRuntime) => _jSRuntime = jSRuntime;

        /// <summary>
        /// Method for displaying confirm dialogs.
        /// </summary>
        /// <param name="message">Message that will be displayed on the dialog.</param>
        public async Task<bool> DisplayConfirmDialog(string message) => await _jSRuntime.InvokeAsync<bool>("confirmDialog", message);

        /// <summary>
        /// Method for displaying toast alerts.
        /// </summary>
        /// <param name="toastID">ID of a toast alert.</param>
        public async Task DisplayToast(string toastID) => await _jSRuntime.InvokeVoidAsync("displayToast", toastID);

        /// <summary>
        /// Method for hiding toast alerts.
        /// </summary>
        /// <param name="toastID">ID of a toast alert.</param>
        public async Task HideToast(string toastID) => await _jSRuntime.InvokeVoidAsync("closeAlert", toastID);
    }
}