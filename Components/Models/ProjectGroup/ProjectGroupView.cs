using System.ComponentModel.DataAnnotations;
using SMART.Common.Base;

namespace SmartEstimate.Models;

public class ProjectGroupView : SMARTBaseClass {

    public ProjectGroupView(string LinkID) : base(LinkID) { }

    [Required]
    public string Name { get; set; }
    public string ProductDoorStyle { get; set; }
    public string ProductFinishExterior { get; set; }
    public string ProductFinishInterior { get; set; }
    public string ProductHinge { get; set; }
    public double PriceSubTotal { get; set; }
}