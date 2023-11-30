using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

using Daemon.RazorUI.Modal;
using Daemon.RazorUI.Icons;
using SMART.Common.ProjectManagement;

using SmartEstimate.Models;



namespace SmartEstimate.Pages;

public partial class ProjectList : ComponentBase, IDisposable
{
    [Inject]
    private ModalService? _modalService { get; set; }

    [Inject]
    private SMARTStore? _smartStore { get; set; }

    [Inject]
    private ILogger<ProjectList>? _logger { get; set; }

    [Inject]
    private NavigationManager? _navigationManager { get; set; }

    [Inject]
    private PersistentComponentState? _applicationState { get; set; }
    private PersistingComponentStateSubscription? _stateSubscription;

    //private IQueryable<QuoteView> _quotes = new List<QuoteView>().AsQueryable();
    //private IQueryable<QuoteView> _visibleQuotes = new List<QuoteView>().AsQueryable();

    private IQueryable<ProjectView> _projects = new List<ProjectView>().AsQueryable();
    private bool IsLoading { get; set; } = true;

    private ModalContentProps _deleteConfirmationInput;
    
    private int? _itemIdToDelete;
    private string? _searchQuery;

    private PaginationState _pagination = new PaginationState { ItemsPerPage = 10 };
    private GridSort<Project> _sortByName = GridSort<Project>
        .ByAscending(p => p.Name);


    protected override async Task OnInitializedAsync()
    {
        _stateSubscription = _applicationState?.RegisterOnPersisting(PersistProjects);
        if(!_applicationState!.TryTakeFromJson("projects", out List<ProjectView>? restoredProjects)) {
            _projects = await _smartStore!.GetProjects();
        } else {
            _logger?.LogInformation("Restored project groups from state");
            _projects = restoredProjects!.AsQueryable();
        }
        _logger!.LogInformation("OnInitializedAsync ProjectList");

        //List<QuoteView> _viewList = await _quoteStore!.ReadableStore.GetAll();
        //_quotes = _viewList.AsQueryable();
        //_visibleQuotes = _quotes;
        //TODO: Can this be more specific?
        //_quoteStore.Storage.OnStateChanged += OnStateChanged!;

        _deleteConfirmationInput = new ModalContentProps 
        {
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

    private Task PersistProjects()
    {
        _applicationState?.PersistAsJson("projects", _projects);
        return Task.CompletedTask;
    }


    private async Task OnDeleteConfirm(bool confirmed)
    {
       if (confirmed && _itemIdToDelete != null)
        {
            //await _quoteStore!.WritableStore.Delete(_itemIdToDelete.Value);
            _itemIdToDelete = null;
            //_visibleQuotes = SearchQuotes(_searchQuery);
        }
        _modalService!.Hide();
    }

    private async void OnStateChanged(object sender, EventArgs e)
    {
        //List<QuoteView> _newQuotes = await _quoteStore!.ReadableStore.GetAll();
        //_quotes = _newQuotes.AsQueryable();
        await InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        //_quoteStore!.Storage.OnStateChanged -= OnStateChanged!;
        _stateSubscription?.Dispose();
    }


    private async Task AddQuote()
    {
        _logger.LogInformation("AddQuote");
        _navigationManager?.NavigateTo("/quotes/new");
    }

    private void DeleteQuote(string quoteId)
    {
        //_itemIdToDelete = quoteId;
        _modalService!.Show(_deleteConfirmationInput);
    }


    // TODO: Abstract this out?
    private void OnSearchInput(string input) {
        _searchQuery = input;
        if(string.IsNullOrEmpty(input)) {
            //_visibleQuotes = _quotes;
        } else {
            //_visibleQuotes = SearchQuotes(input);
        }   
    }

    //private IQueryable<QuoteView> SearchQuotes(string? query) {
    private void SearchQuotes(string? query) {
        if(string.IsNullOrWhiteSpace(query)) {
            //return _quotes;
        }
        // return _quotes
        //     .Where(q => 
        //         q.Name.Contains(query, StringComparison.OrdinalIgnoreCase)
        //     );
    }
}



