// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Taste.UI.Pages.Admin.User
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Taste.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Taste.UI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Taste.UIServices.IServices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Taste.UIServices.IServices.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Taste.UIServices.IServices.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Taste.UILibrary.JSExtensionMethods;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Taste.SharedModels.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Taste.SharedModels.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "E:\Mahmoud\Application\Taste.APi\Taste.UI\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Admin/User/Index")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IAsyncDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 62 "E:\Mahmoud\Application\Taste.APi\Taste.UI\Pages\Admin\User\Index.razor"
       

    // Load the module and keep a reference to it
    // You need to use .AsTask() to convert the ValueTask to Task as it may be awaited multiple times
    private Task<IJSObjectReference> _module;
    private Task<IJSObjectReference> Module => _module ??=
        _js.InvokeAsync<IJSObjectReference>("import", "./js/category.js").AsTask();

    IJSObjectReference module;

    List<ApplicationUserModel> users = new();


    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            users = (await _userService.GetAllUsers()).ToList();
            StateHasChanged();
            module = await Module;

            await module.InvokeVoidAsync("initializeDataTable", "userList");

        }
    }

    private async Task LockUnlock(string userId)
    {
        bool res = await _userService.LockUnlock(userId);

        if (res)
        {
            // Display Successful Message
        }
        else 
        {
        }

        await OnAfterRenderAsync(true);
    }

    public async ValueTask DisposeAsync()
    {
        if (_module != null)
        {
            var module = await _module;
            await module.DisposeAsync();
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.Toast.Services.IToastService ToastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime _js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserService _userService { get; set; }
    }
}
#pragma warning restore 1591
