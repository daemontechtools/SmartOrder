using System.ComponentModel.DataAnnotations;

namespace SO.Data;

public class ProjectGroupFormView : SMARTBaseClassView {

    public ProjectGroupFormView(string LinkID) : base(LinkID) { }

    [Required]
    public string Name { get; set; }
    public string ProductDoorStyle { get; set; }
    public string ProductFinishExterior { get; set; }
    public string ProductFinishInterior { get; set; }
    //public string ProductHinge { get; set; }
    public string ProductSlide { get; set; }
    public double PriceSubTotal { get; set; }

    public IList<ProductFormView> ProjectGroupProducts { get; set; }
}