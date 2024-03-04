
using SMART.Common.ProductionManagement;

namespace SO.Data;

public class ProductView : SMARTBaseClassView {
    public ProductView(string LinkID) : base(LinkID) { }
    
    public ProductTypes Type { get; set; }
    public string CategoryName { get; set; }
    public string LinkIDCategory { get; set; }
    public string Name { get; set; }
    public string Comments { get; set; }
    public float PriceLibrary { get; set; }
    public string ProductDoorSwing { get; set; }
    public string ProductDoorStyle { get; set; }
    public string ProductLeftSide { get; set; }
    public string ProductRightSide { get; set; }
    public string ProductFinishExterior { get; set; }
    public string ProductFinishInterior { get; set; }
    public string ProductSlide { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Depth { get; set; }
    public float Quantity { get; set; }
}
