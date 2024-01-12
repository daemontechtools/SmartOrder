

namespace SmartEstimate.Models;

public class LibraryProductView : SMARTBaseClassView {
    public LibraryProductView(string LinkID) : base(LinkID) { }

    public string Name { get; set; }
    public string ProductCode { get; set; }
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
    public float PriceLibrary { get; set; }
}