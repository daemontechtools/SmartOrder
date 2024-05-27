using Microsoft.AspNetCore.Components;
using SMART.Common.ProjectManagement;
using SMART.Common.LibraryManagement;
namespace SO.Components.Projects;

public struct RoomProfileProps {
    public string Title { get; set; }
}

public partial class ProjectGroupDetail : ComponentBase {
    [Inject]
    private SmartService? _smartClient { get; set; }

    [Parameter]
    public string? ProjectLinkId { get; set; }

    [Parameter]
    public string? ProjectGroupLinkId { get; set; }

    private Project? _project;
    private ProjectGroup? _projectGroup;
    private IQueryable<Product>? _products;
    private bool _isLoading = true;

    private List<RoomProfileProps> _roomProfileProps = new List<RoomProfileProps>();

    protected override async Task OnInitializedAsync() {
        _project = await _smartClient!.GetClient()
            .Project
            .GetProjectById(ProjectLinkId!)
            ?? throw new Exception("Project not found");
        _projectGroup = _smartClient!.GetClient()
            .ProjectGroup
            .GetProjectGroupById(
                ProjectGroupLinkId!,
                _project
            )
            ?? throw new Exception("Project Group not found");
        _products =  _smartClient!.GetClient()
            .ProjectGroup
            .GetProjectGroupProductsAsQueryable(
                _projectGroup.LinkID,
                _project
            );
        
        // _products = await _smartClient!.GetClient()
        //     .Product
        //     .GetCabinetsAsQueryable();
        _isLoading = false;

        // _roomProfileProps.Add(new RoomProfileProps { Title = "Door Style" });
        // _roomProfileProps.Add(new RoomProfileProps { Title = "Finish" });
        // _roomProfileProps.Add(new RoomProfileProps { Title = "Interior Finish" });
        // _roomProfileProps.Add(new RoomProfileProps { Title = "Drawer Hardware" });
    }

    private float GetRoomPrice() {
        if(_products == null) return 0;
        var roomTotal = _products?.Sum(p => p.PriceLibrary * p.Quantity) ?? 0;
        return (float)Math.Round(roomTotal, 2);
    }

    private string GetRoomInteriorFinish() {
        return (
            _projectGroup is null
            || String.IsNullOrWhiteSpace(_projectGroup.ProductFinishInterior)
        )
        ? "N/A"
        : _projectGroup.ProductFinishInterior;
    }

    private string GetRoomDrawer() {
        return (
            _projectGroup is null
            || String.IsNullOrWhiteSpace(_projectGroup.ProductSlide)
        )
        ? "N/A"
        : _projectGroup.ProductSlide;
    }
}