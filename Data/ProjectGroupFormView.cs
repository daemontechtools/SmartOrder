using System.ComponentModel.DataAnnotations;
using SMART.Common.LibraryManagement;
namespace SO.Data;

public class ProjectGroupFormView : SmartBaseClass {

    public ProjectGroupFormView() : base("") { }
    public ProjectGroupFormView(string LinkID) : base(LinkID) { }

    [Required]
    public string Name { get; set; } = default!;
    public string ProductDoorStyle { get; set; } = default!;
    public string ProductFinishExterior { get; set; } = default!;
    public string ProductFinishInterior { get; set; } = default!;
    //public string ProductHinge { get; set; }
    public string ProductSlide { get; set; } = default!;
    public double PriceSubTotal { get; set; } = default!;
    public IList<LibraryProduct> ProjectGroupProducts { get; set; } = default!;
}