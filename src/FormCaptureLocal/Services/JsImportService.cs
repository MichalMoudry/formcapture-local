using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCaptureLocal.Services
{
    /// <summary>
    /// Service for working with JS modules.
    /// </summary>
    public class JsImportService
    {
        /// <summary>
        /// Field for JSRuntime class instance.
        /// </summary>
        private readonly IJSRuntime _jSRuntime;

        /// <summary>
        /// Field with JS module as <see cref="IJSObjectReference"/>.
        /// </summary>
        private IJSObjectReference _module;

        public JsImportService(IJSRuntime jSRuntime) => _jSRuntime = jSRuntime;

        /// <summary>
        /// Method for getting JS module as <see cref="IJSObjectReference"/>.
        /// </summary>
        public IJSObjectReference GetModule()
        {
            return _module;
        }

        /// <summary>
        /// Method for importing a JS module.
        /// </summary>
        /// <param name="modulePath">Path to the module.</param>
        /// <returns>A <see cref="Task"/> representing any asynchronous operation.</returns>
        public async Task<IJSObjectReference> ImportModule(string modulePath)
        {
            _module = await _jSRuntime.InvokeAsync<IJSObjectReference>("import", modulePath);
            return _module;
        }
    }
}
