using Microsoft.AspNetCore.Components;

namespace SmartEstimate.Pages;


public struct ProjectDetailNavProps {
    public string ProjectId { get; set; }
    public int ProjectDocumentCount { get; set; }
} 

public partial class ProjectDetailNav : ComponentBase {

    [Parameter] 
    public ProjectDetailNavProps? Props { get; set; }

    private (string, string)[] MenuOptions { get; set; } = new (string, string)[]{};

    protected override void OnInitialized() {
        MenuOptions = new (string, string)[] {
            ("Rooms", $"/quotes/{Props?.ProjectId}"),
            ("Shipping", $"/quotes/{Props?.ProjectId}/shipping"),
            ($"Documents (2)", $"/quotes/{Props?.ProjectId}/documents"),
        };
    }
}