using System.ComponentModel.DataAnnotations;

namespace SmartEstimate.Models;

public class ProjectGroupView : SMARTBaseClassView {

    public ProjectGroupView(string LinkID) : base(LinkID) { }

    [Required]
    public string Name { get; set; }
    public string ProductDoorStyle { get; set; }
    public string ProductFinishExterior { get; set; }
    public string ProductFinishInterior { get; set; }
    //public string ProductHinge { get; set; }
    public string ProductSlide { get; set; }
    public double PriceSubTotal { get; set; }

    public IList<ProductView> ProjectGroupProducts { get; set; }
}