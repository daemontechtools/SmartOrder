

namespace SmartEstimate.Models;


public enum ProductCategoryTypes {
    Upper,
    Base,
    Tall,
    Vanity,
    Panel,
    Filler,
    Moulding,
    Accessory,
    Unknown
}

public struct ProductAddOn {
    public string Name { get; set; }
    public List<string> Options { get; set; }
}