// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Taste.UI.Pages.Admin.MenuItem
{
    #line hidden
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
#nullable restore
#line 3 "E:\Mahmoud\Application\Taste.APi\Taste.UI\Pages\Admin\MenuItem\Upsert.razor"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Mahmoud\Application\Taste.APi\Taste.UI\Pages\Admin\MenuItem\Upsert.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Mahmoud\Application\Taste.APi\Taste.UI\Pages\Admin\MenuItem\Upsert.razor"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Mahmoud\Application\Taste.APi\Taste.UI\Pages\Admin\MenuItem\Upsert.razor"
using System.IO;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Admin/MenuItem/Upsert/{MenuItemId:int?}")]
    public partial class Upsert : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 164 "E:\Mahmoud\Application\Taste.APi\Taste.UI\Pages\Admin\MenuItem\Upsert.razor"
       

    [Parameter]
    public int? MenuItemId { get; set; }

    MenuItemModel menuItem = new();

    MenuItemViewModel menuItemVM;

    private Task<IJSObjectReference> _module;
    private Task<IJSObjectReference> Module => _module ??=
        _js.InvokeAsync<IJSObjectReference>("import", "./js/category.js").AsTask();

    IJSObjectReference module;

    protected override async Task OnInitializedAsync()
    {
        menuItemVM = new MenuItemViewModel()
        {
            CategoryList = await _categoryService.GetCategoryListForDropDown(),
            FoodTypeList = await _foodTypeService.GetFoodTypeListForDropDown()

        };

        if (MenuItemId != null)
        {
            menuItemVM.MenuItem = await _menuItemService.GetMenuItemById(MenuItemId.Value);
        }


    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        module = await Module;

        await module.InvokeVoidAsync("initTinyMCE");

        StateHasChanged();
    }
    private async Task AddOrUpdate()
    {

        if (MenuItemId != null)
        {
            // Upadet

        }
        else
        {
            // Add New Category

            bool isAddedSuccessfuly = await _menuItemService.AddMenuItem(menuItemVM.MenuItem);


            if (isAddedSuccessfuly)
            {
                // Display Successful Toast
            }
            else
            {
                // Display Danger Tosat
            }
        }
    }

    private List<IBrowserFile> loadedFiles = new();
    private long maxFileSize = 1024 * 1024 * 5;
    private int maxAllowedFiles = 3;
    private bool isLoading;
    FileInfo fi;

    private async Task LoadFiles(InputFileChangeEventArgs e)
    {
        isLoading = true;
        loadedFiles.Clear();

        foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
        {
            try
            {
                loadedFiles.Add(file);
                fi = new FileInfo(file.Name);

                string fileName = Guid.NewGuid().ToString();
                //var trustedFileNameForFileStorage = Path.GetRandomFileName();
                //var path = Path.Combine(Environment.ContentRootPath,
                //        Environment.EnvironmentName, "unsafe_uploads",
                //        trustedFileNameForFileStorage);

                var uploads = Path.Combine(Environment.WebRootPath, "Images/MenuItems/", fileName + fi.Extension);
                //var extension = Path.GetExtension(file.FileName);
                await using FileStream fs = new(uploads, FileMode.Create);
                await file.OpenReadStream(maxFileSize).CopyToAsync(fs);

                menuItemVM.MenuItem.Image = "Images/MenuItems/" + fileName + fi.Extension;

                StateHasChanged();
            }
            catch (Exception ex)
            {

            }
        }

        isLoading = false;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IFoodTypeService _foodTypeService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICategoryService _categoryService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMenuItemService _menuItemService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime _js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWebHostEnvironment Environment { get; set; }
    }
}
#pragma warning restore 1591
