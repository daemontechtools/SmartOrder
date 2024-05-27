using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using SMART.Common.ProjectManagement;
using Daemon.RazorUI.Icons;
using Daemon.RazorUI.Modal;
namespace SO.Components.Projects;

public partial class Projects : ComponentBase {
    [Inject]
    private ModalService? _modalService { get; set; }

    [Inject]
    private SmartService? _smartService { get; set; }

    [Inject]
    private ILogger<Projects>? _logger { get; set; }

    [Inject]
    private NavigationManager? _navigationManager { get; set; }

    private IQueryable<Project>? _projects;
    private bool IsLoading { get; set; } = true;

    private ModalContentProps _deleteConfirmationInput;
    
    private Project? _projectToDelete;
    private string? _searchQuery;

    private PaginationState _pagination = new PaginationState { ItemsPerPage = 10 };
    private GridSort<Project> _sortByName = GridSort<Project>
        .ByAscending(p => p.Name);

    protected override async Task OnInitializedAsync() {
        _projects = await _smartService!.GetClient()!
            .Project
            .GetProjectsAsQueryable();
        _projects = _projects
            .OrderByDescending(p => p.DateOrderSubmit);
        _deleteConfirmationInput = new ModalContentProps {
            Title = "Delete Quote",
            Description = "Are you sure you want to delete this quote?",
            IconType = typeof(TrashIcon),
            IconProps = new IconProps() { Class = "stroke-red-500" },
            IconBackgroundClass = "bg-red-100",
            ButtonClass = "bg-red-500 hover:bg-red-400",
            OnConfirm = OnDeleteConfirm 
        };
        IsLoading = false;
    }

    private async Task OnDeleteConfirm(bool confirmed) {
       if (confirmed && _projectToDelete != null) {
            await _smartService!.GetClient()
                .Project
                .DeleteProject(_projectToDelete);
            // TODO: Checrk if this is necessary
            // _projects = await _orderApi!
            //     .Project
            //     .GetProjectsAsQueryable(true);
            _projectToDelete = null;
            StateHasChanged();
        }
        _modalService!.Hide();
    }

    private async void OnStateChanged(object sender, EventArgs e) {
        var projects = await _smartService!.GetClient()
            .Project
            .GetProjects();
        await InvokeAsync(StateHasChanged);
    }

    private async Task AddQuote() {
        _navigationManager?.NavigateTo("/quotes/new");
    }

    private void DeleteQuote(Project project) {
        _projectToDelete = project;
        _modalService!.Show(_deleteConfirmationInput);
    }

    // TODO: Abstract this out?
    private async Task OnSearchInput(string input) {
        _searchQuery = input;
        if(string.IsNullOrWhiteSpace(input)) {
            var projects = await _smartService!.GetClient()
                .Project
                .GetProjects();
            _projects = projects.AsQueryable();
        } else {
            _projects = SearchProducts(input);
        }   
    }

    private IQueryable<Project> SearchProducts(string? query) {
        if(string.IsNullOrWhiteSpace(query)) {
            return _projects!;
        }
        return _projects!
            .Where(q => 
                q.Name.Contains(query, StringComparison.OrdinalIgnoreCase)
            )
            .AsQueryable();
    }
}