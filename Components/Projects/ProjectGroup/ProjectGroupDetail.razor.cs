using Microsoft.AspNetCore.Components;
using SO.Data;

namespace SO.Components.Projects;


public struct RoomProfileProps
{
    public string Title { get; set; }
}

public partial class ProjectGroupDetail : ComponentBase
{
    [Inject]
    private ProjectStore? _projectStore { get; set; }

    [Parameter]
    public string? ProjectLinkId { get; set; }

    [Parameter]
    public string? ProjectGroupLinkId { get; set; }

    private ProjectView? _project;
    private ProjectGroupView? _projectGroup;
    private IQueryable<ProductView> _products = new List<ProductView>().AsQueryable();
    private bool IsLoading = true;

    private List<RoomProfileProps> _roomProfileProps = new List<RoomProfileProps>();

    protected override async Task OnInitializedAsync()
    {
        _project = await _projectStore!
            .ReadableStore
            .GetOne(p => p.LinkID == ProjectLinkId);
        if(_project == null) {
            throw new Exception("Project not found");
        }
        _projectGroup = _project!.ProjectGroups
            .FirstOrDefault(g => g.LinkID == ProjectGroupLinkId);
        if(_projectGroup == null) {
            throw new Exception("Project Group not found");
        }
        _products = _projectGroup
            .ProjectGroupProducts
            .AsQueryable();
        IsLoading = false;

        _roomProfileProps.Add(new RoomProfileProps { Title = "Door Style" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Finish" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Interior Finish" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Drawer Hardware" });
    }
}