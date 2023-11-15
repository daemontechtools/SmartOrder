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
    private QuoteStore? QuoteStore { get; set; }

    [Parameter]
    public int QuoteId { get; set; }

    [Parameter]
    public int RoomId { get; set; }

    private QuoteView _quote = new();
    private RoomView _room = new();
    private IQueryable<ProductView> _products = new List<ProductView>().AsQueryable();
    private bool IsLoading = true;

    private List<RoomProfileProps> _roomProfileProps = new List<RoomProfileProps>();

    protected override async Task OnInitializedAsync()
    {
        _quote = await QuoteStore?.ReadableStore.GetById(QuoteId);
        _room = _quote.Rooms.FirstOrDefault(r => r.Id == RoomId);
        _products = _room.Products.AsQueryable();
        IsLoading = false;

        _roomProfileProps.Add(new RoomProfileProps { Title = "Door Style" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Finish" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Interior Finish" });
        _roomProfileProps.Add(new RoomProfileProps { Title = "Drawer Hardware" });
    }
}