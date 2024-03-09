
using SMART.Common.ProductionManagement;
namespace SO.Data;

public class ProductFormView : SMARTBaseClassView {
    public ProductFormView(string LinkID) : base(LinkID) {}
    public ProductTypes Type { get; set; } = default!;
    public string CategoryName { get; set; } = default!;
    public string LinkIDCategory { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Comments { get; set; } = default!;
    public float PriceLibrary { get; set; } = default!;
    public string ProductDoorSwing { get; set; } = default!;
    public string ProductDoorStyle { get; set; } = default!;
    public string ProductLeftSide { get; set; } = default!;
    public string ProductRightSide { get; set; } = default!;
    public string ProductFinishExterior { get; set; } = default!;
    public string ProductFinishInterior { get; set; } = default!;
    public string ProductSlide { get; set; } = default!;
    public float Width { get; set; } = default!;
    public float Height { get; set; } = default!;
    public float Depth { get; set; } = default!;
    public float Quantity { get; set; } = default!;
}
