using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SO.Data;

namespace SO.Components.Projects;


public partial class ProjectGroupForm : ComponentBase {
    [Inject]
    private NavigationManager? _navigationManager { get; set; }

    [Inject]
    private ProjectStore? _projectStore { get; set; }

    [Inject]
    private ILogger<ProjectGroupForm>? _logger { get; set; }


    [Parameter]
    public string? ProjectLinkId { get; set; }

    [Parameter]
    public string? ProjectGroupLinkId { get; set; }


    [SupplyParameterFromForm]
    private ProjectGroupView? _room { get; set; }
    private EditForm _editForm = default!;
    private bool _isSubmitting = false;
    private bool _isNew = true;

    private ProjectView? _project { get; set; }
    private IQueryable<ProductView> _products = new List<ProductView>().AsQueryable();
    private bool IsLoading = true;

    private List<RoomProfileProps> _roomProfileProps = new List<RoomProfileProps>();

    protected override async Task OnInitializedAsync() {
        _project = await _projectStore!
            .ReadableStore
            .GetOne(p => p.LinkID == ProjectLinkId);

        if(ProjectGroupLinkId != null) {
            _room = await _projectStore!
                .GetRoomById(
                    ProjectGroupLinkId!,
                    ProjectLinkId!
                );
            _products = _room!
                .ProjectGroupProducts
                .AsQueryable();
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

    private async Task AddRoom()
    {
        _isSubmitting = true;
        _logger!.LogInformation($"Creating new room: {_room!.Name}");
        ProjectGroupView newRoom = await _projectStore!
            .AddRoom(
                ProjectLinkId!,
                _room!
                
            );
        _logger!.LogInformation($"Created new room: {newRoom.Name}");
        _navigationManager!.NavigateTo($"/quotes/{ProjectLinkId}");
        _isSubmitting = false;
    }

    private async Task UpdateRoom() {
        _isSubmitting = true;
        _logger!.LogInformation($"Updating room: {_room!.Name}");
        ProjectGroupView updatedRoom = await _projectStore!
            .UpdateRoom(
                ProjectLinkId!,
                _room!
            );
        _logger!.LogInformation($"Updated room: {updatedRoom.Name}");
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