using Microsoft.AspNetCore.Components;

namespace SmartEstimate.Pages;


public struct QuoteDetailNavProps {
    public int QuoteId { get; set; }
    public int QuoteDocumentCount { get; set; }
} 

public partial class QuoteDetailNav : ComponentBase {

    [Parameter] 
    public QuoteDetailNavProps? Props { get; set; }

    private (string, string)[] MenuOptions { get; set; } = new (string, string)[]{};

    protected override void OnInitialized() {
        MenuOptions = new (string, string)[] {
            ("Rooms", $"/quotes/{Props?.QuoteId}"),
            ("Shipping", $"/quotes/{Props?.QuoteId}/shipping"),
            ($"Documents (2)", $"/quotes/{Props?.QuoteId}/documents"),
        };
    }
}