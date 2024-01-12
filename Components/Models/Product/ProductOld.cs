

namespace SmartEstimate.Models;


public enum ProductType
{
    Upper,
    Base,
    Tall,
    Vanity,
    Panel,
    Moulding,
    Accessory
}

public struct ProductAddOn {
    public string Name { get; set; }
    public List<string> Options { get; set; }
}