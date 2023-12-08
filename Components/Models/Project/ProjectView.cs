using System.ComponentModel.DataAnnotations;
using SMART.Common.Base;
using SMART.Common.CompanyManagement;

namespace SmartEstimate.Models;


public class ProjectView : SMARTBaseClass {

    public ProjectView(string LinkID) : base(LinkID) { }

    [Required]
    [StringLength(30, ErrorMessage = "Id too long (30 character limit).")]
    public string Name { get; set; }

   
    public bool IsShipped { get; set; } = false;
    public string LinkIDEmployeeSoldBy { get; set; }

  
    public ShipLocation ProjectShipLocation { get; set; }

    public IList<ProjectGroupView> ProjectGroups { get; set; }
}