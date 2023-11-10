using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

using Daemon.RazorUI.Modal;
using Daemon.RazorUI.Icons;
using SmartEstimate.Models;

namespace SmartEstimate.Pages;

public partial class QuoteList : ComponentBase, IDisposable
{
    [Inject]
    private ModalService? _modalService { get; set; }

    [Inject]
    private QuoteStore? _quoteStore { get; set; }

    [Inject]
    ILogger<QuoteList>? _logger { get; set; }


    private IQueryable<QuoteView> _quotes = new List<QuoteView>().AsQueryable();
    private IQueryable<QuoteView> _visibleQuotes = new List<QuoteView>().AsQueryable();

    
    private bool IsLoading { get; set; } = true;

    private ModalContentProps _deleteConfirmationInput;
    //private ModalContentProps _createQuoteInput;
    
    private int? _itemIdToDelete;
    private string? _searchQuery;

    private PaginationState _pagination = new PaginationState { ItemsPerPage = 10 };
    private GridSort<QuoteView> _sortByName = GridSort<QuoteView>
        .ByAscending(q => q.Name);



    protected override async Task OnInitializedAsync()
    {
        List<QuoteView> _viewList = await _quoteStore!.ReadableStore.GetAll();
        _quotes = _viewList.AsQueryable();
        _visibleQuotes = _quotes;
        //TODO: Can this be more specific?
        _quoteStore.Storage.OnStateChanged += OnStateChanged!;

        _deleteConfirmationInput = new ModalContentProps 
        {
            Title = "Delete Category",
            Description = "Are you sure you want to deactivate your account? All of your data will be permanently removed from our servers forever. This action cannot be undone.",
            IconType = typeof(ClipboardIcon),
            IconProps = new IconProps() { Class = "stroke-red-500" },
            IconBackgroundClass = "bg-red-100",
            ButtonClass = "bg-red-500 hover:bg-red-400",
            OnConfirm = OnDeleteConfirm 
        };

        // _createQuoteInput = new ModalContentProps 
        // {
        //     Title = "Create New Quote",
        //     IconType = typeof(ClipboardIcon),
        //     IconProps = new IconProps() { Class = new TailwindColor("sky") },
        // };

        IsLoading = false;
    }


    private void ShowDeleteConfirmation(int id)
    {
        _itemIdToDelete = id;
        _modalService!.Show(_deleteConfirmationInput);
    }

    private async Task OnDeleteConfirm(bool confirmed)
    {
       if (confirmed && _itemIdToDelete != null)
        {
            await _quoteStore!.WritableStore.Delete(_itemIdToDelete.Value);
            _itemIdToDelete = null;
            _visibleQuotes = SearchQuotes(_searchQuery);
        }
        _modalService!.Hide();
    }

    private async void OnStateChanged(object sender, EventArgs e)
    {
        List<QuoteView> _newQuotes = await _quoteStore!.ReadableStore.GetAll();
        _quotes = _newQuotes.AsQueryable();
        await InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        _quoteStore!.Storage.OnStateChanged -= OnStateChanged!;
    }


    private async Task AddQuote()
    {
        QuoteView newQuote = QuoteMock.GenerateRandomQuoteView();
        await _quoteStore!.WritableStore.Create(newQuote);
        _visibleQuotes = SearchQuotes(_searchQuery);

    }

    private void DeleteQuote(int quoteId)
    {
        ShowDeleteConfirmation(quoteId);
    }


    // TODO: Abstract this out?
    private void OnSearchInput(string input) {
        _searchQuery = input;
        if(string.IsNullOrEmpty(input)) {
            _visibleQuotes = _quotes;
        } else {
            _visibleQuotes = SearchQuotes(input);
        }   
    }

    private IQueryable<QuoteView> SearchQuotes(string? query) {
        if(string.IsNullOrWhiteSpace(query)) {
            return _quotes;
        }
        return _quotes
            .Where(q => 
                q.Name.Contains(query, StringComparison.OrdinalIgnoreCase)
            );
    }
}



