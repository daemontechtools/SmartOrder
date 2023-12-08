using Microsoft.AspNetCore.Components;
using SmartEstimate.Models;

namespace SmartEstimate.Pages;


public struct RoomProfileProps
{
    public string Title { get; set; }
}

public partial class RoomDetail : ComponentBase
{
    [Inject]
    private ProjectStore? _projectStore { get; set; }

    [Parameter]
    public string? ProjectLinkId { get; set; }

    [Parameter]
    public string? ProjectGroupLinkId { get; set; }

    private ProjectView? _project;
    private ProjectGroupView? _projectGroup;
    //private IQueryable<ProductView> _products = new List<ProductView>().AsQueryable();
    private bool IsLoading = true;

    private List<RoomProfileProps> _roomProfileProps = new List<RoomProfileProps>();

    protected override async Task OnInitializedAsync()
    {
        _project = await _projectStore!
            .ReadableStore
            .GetById(ProjectLinkId!);
        //_projectGroup.ProjectGroup
        _projectGroup = _project.ProjectGroups
            .FirstOrDefault(g => g.LinkID == ProjectGroupLinkId);
        //_products = _room.Products.AsQueryable();
        IsLoading = false;

        _roomProfileProps.Add(new RoomProfileProps { Title = "Door Style" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Finish" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Interior Finish" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Drawer Hardware" });
    }
}