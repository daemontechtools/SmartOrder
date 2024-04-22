using System.ComponentModel.DataAnnotations;
using SMART.Common.ProjectManagement;
namespace SO.Data;

public class ProjectFormView : SmartBaseClass { 
    public ProjectFormView() : base("") { }
    public ProjectFormView(string LinkID) : base(LinkID) { }

    [Required]
    [StringLength(50, ErrorMessage = "Id too long (50 character limit).")]
    public string Name { get; set; } = "";
   
    [Required]
    public bool IsShipped { get; set; } = false;
    public string LinkIDEmployeeSoldBy { get; set; } = "";
    
    [RequiredIf(
        "IsShipped", 
        true, 
        ErrorMessage = "Shipping Location is required when IsShipped is true."
    )]
    [ValidateComplexType]
    public ShipLocationFormView ProjectShipLocation { get; set; }

    public IList<ProjectGroup> ProjectGroups { get; set; } = new List<ProjectGroup>();
}