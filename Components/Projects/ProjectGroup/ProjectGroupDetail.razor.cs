using Microsoft.AspNetCore.Components;
using SMART.Common.ProjectManagement;
using SMART.Common.LibraryManagement;
using SMART.Web.OrderApi;
using SO.Data;

namespace SO.Components.Projects;


public struct RoomProfileProps {
    public string Title { get; set; }
}

public partial class ProjectGroupDetail : ComponentBase {
    [Inject]
    private SmartOrderApi? _orderApi { get; set; }

    [Parameter]
    public string? ProjectLinkId { get; set; }

    [Parameter]
    public string? ProjectGroupLinkId { get; set; }

    private Project? _project;
    private ProjectGroup? _projectGroup;
    private IList<LibraryProduct>? _products;
    private bool IsLoading = true;

    private List<RoomProfileProps> _roomProfileProps = new List<RoomProfileProps>();

    protected override async Task OnInitializedAsync() {
        _project = await _orderApi!
            .Project
            .GetProjectById(ProjectLinkId!);
        if(_project == null) {
            throw new Exception("Project not found");
        }
        _projectGroup = _orderApi.ProjectGroup.GetProjectGroupById(
            _project,
            ProjectGroupLinkId!
        );
        _products = await _orderApi!
            .Product
            .GetCabinets();
        IsLoading = false;

        _roomProfileProps.Add(new RoomProfileProps { Title = "Door Style" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Finish" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Interior Finish" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Drawer Hardware" });
    }
}