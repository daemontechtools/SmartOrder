using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SMART.Common.LibraryManagement;
using SMART.Common.ProjectManagement;
using SMART.Web.OrderApi;
using SO.Data;

namespace SO.Components.Projects;


public partial class ProjectGroupForm : ComponentBase {
    [Inject]
    private NavigationManager? _navigationManager { get; set; }

    [Inject]
    private SmartOrderApi? _orderApi { get; set; }

    [Inject]
    private ILogger<ProjectGroupForm>? _logger { get; set; }


    [Parameter]
    public string? ProjectLinkId { get; set; }

    [Parameter]
    public string? ProjectGroupLinkId { get; set; }


    [SupplyParameterFromForm]
    private ProjectGroup? _room { get; set; }
    private EditForm _editForm = default!;
    private bool _isSubmitting = false;
    private bool _isNew = true;

    private Project? _project { get; set; }
    private IQueryable<LibraryProduct>? _products;
    private bool IsLoading = true;

    private List<RoomProfileProps> _roomProfileProps = new List<RoomProfileProps>();

    protected override async Task OnInitializedAsync() {
        _project = await _orderApi!
            .Project
            .GetProjectById(ProjectLinkId!);
        if(ProjectGroupLinkId != null) {
            _room = _orderApi!
                .ProjectGroup
                .GetProjectGroupById(
                    _project,
                    ProjectGroupLinkId!
                );
            var products = await _orderApi!
                .Product
                .GetProducts();
            _products = products.AsQueryable();
            _isNew = false;
        } else {
            _room = new("");
        }
        IsLoading = false;
    }

    private async Task OnSubmitClick() {
        if (!_editForm!.EditContext!.Validate()) {
            return;
        }

        if(_isNew) {
            await AddRoom();
        } else {
            await UpdateRoom();
        }
    }

    private void OnCancelClick() {
        if(_isNew) {
            _room = new("");
            StateHasChanged();
        } else {
            _navigationManager!
                .NavigateTo($"/quotes/{ProjectLinkId}/rooms/{ProjectGroupLinkId}");
        }
    }

    private async Task AddRoom() {
        _isSubmitting = true;
        _logger!.LogInformation($"Creating new room: {_room!.Name}");
        ProjectGroup newRoom = await _orderApi!
            .ProjectGroup
            .AddProjectGroup(
                _project!,
                _room.Name
                
            );
        _logger!.LogInformation($"Created new room: {newRoom.Name}");
        _navigationManager!.NavigateTo($"/quotes/{ProjectLinkId}");
        _isSubmitting = false;
    }

    private async Task UpdateRoom() {
        _isSubmitting = true;
        _logger!.LogInformation($"Updating room: {_room!.Name}");
        await _orderApi!
            .ProjectGroup
            .UpdateRoom(_room);
        _logger!.LogInformation($"Updated room: {_room.Name}");
        _navigationManager!.NavigateTo($"/quotes/{ProjectLinkId}");
        _isSubmitting = false;
    }
    
    private void AddProduct() {
        _navigationManager!
            .NavigateTo($"/quotes/{ProjectLinkId}/rooms/{ProjectGroupLinkId}/products");
    }

    private void DeleteProduct(string productLinkId) {
        // _itemIdToDelete = productId;
        // ModalService!.Show(_deleteConfirmationInput);
    }
}