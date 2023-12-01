

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

public struct Product
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string Code { get; set; }
    public int Quantity { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Depth { get; set; }
    public bool Left { get; set; }
    public bool Right { get; set; }
    public string Comments { get; set; }
    public float Price { get; set; }
    public string EXT { get; set; }
    public string Name { get; set; }
}

