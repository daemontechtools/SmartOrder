namespace SmartEstimate.Models;

public struct ProductTypeAddOns {
    public Dictionary<ProductType, List<ProductAddOn>> TypeAddOns { get; set; }

    public ProductTypeAddOns() {
        TypeAddOns = new Dictionary<ProductType, List<ProductAddOn>>();

        TypeAddOns.Add(ProductType.Upper, new List<ProductAddOn>
        {
            new ProductAddOn { Name = "Hinging", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Left End", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Right End", Options = new List<string> { "Option1", "Option2" } }
        });

        TypeAddOns.Add(ProductType.Base, new List<ProductAddOn>
        {
            new ProductAddOn { Name = "Hinging", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Left End", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Right End", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Interior Drawer Top", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Interior Drawer Bottom", Options = new List<string> { "Option1", "Option2" } }
        });

        TypeAddOns.Add(ProductType.Tall, new List<ProductAddOn>
        {
            new ProductAddOn { Name = "Hinging", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Left End", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Right End", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Interior Drawer Top", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Interior Drawer Bottom", Options = new List<string> { "Option1", "Option2" } }
        });

        TypeAddOns.Add(ProductType.Vanity, new List<ProductAddOn>
        {
            new ProductAddOn { Name = "Hinging", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Left End", Options = new List<string> { "Option1", "Option2" } },
            new ProductAddOn { Name = "Right End", Options = new List<string> { "Option1", "Option2" } }
        });

        TypeAddOns.Add(ProductType.Panel, new List<ProductAddOn>
        {

        });

        TypeAddOns.Add(ProductType.Moulding, new List<ProductAddOn>
        {

        });

        TypeAddOns.Add(ProductType.Accessory, new List<ProductAddOn>
        {

        });
    }
}