using Microsoft.AspNetCore.Components;

using Daemon.RazorUI.Modal;
using Daemon.RazorUI.Icons;
using Daemon.RazorUI.Color;
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

    
    private bool IsLoading { get; set; } = true;

    private ModalContentProps _deleteConfirmationInput;
    private ModalContentProps _createQuoteInput;
    
    private int? _itemIdToDelete;



    protected override async Task OnInitializedAsync()
    {
        List<QuoteView> _viewList = await _quoteStore!.ReadableStore.GetAll();
        _quotes = _viewList.AsQueryable();
        //TODO: Can this be more specific?
        _quoteStore.Storage.OnStateChanged += OnStateChanged!;

        _deleteConfirmationInput = new ModalContentProps 
        {
            Title = "Delete Category",
            Description = "Are you sure you want to deactivate your account? All of your data will be permanently removed from our servers forever. This action cannot be undone.",
            IconType = typeof(ClipboardIcon),
            IconProps = new IconProps() { Color = new TailwindColor("rose") },
            OnConfirm = OnConfirm 
        };

        _createQuoteInput = new ModalContentProps 
        {
            Title = "Create New Quote",
            IconType = typeof(ClipboardIcon),
            IconProps = new IconProps() { Color = new TailwindColor("sky") },
        };

        IsLoading = false;
    }


    private void ShowDeleteConfirmation(int id)
    {
        _itemIdToDelete = id;
        _modalService!.Show(_deleteConfirmationInput);
    }

    private async Task OnConfirm(bool confirmed)
    {
       if (confirmed && _itemIdToDelete != null)
        {
            await _quoteStore!.WritableStore.Delete(_itemIdToDelete.Value);
            _itemIdToDelete = null;
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
    }

    private void EditQuote(int quoteId)
    {
        if(_logger != null)
        {
            _logger.LogInformation($"Edit Quote {quoteId}");
        }
    }

    private void DeleteQuote(int quoteId)
    {
        ShowDeleteConfirmation(quoteId);
    }
}



