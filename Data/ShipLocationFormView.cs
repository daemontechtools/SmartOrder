using System.ComponentModel.DataAnnotations;
namespace SO.Data;

public class ShipLocationFormView : SmartBaseClass {

    public ShipLocationFormView() : base("") { }
    public ShipLocationFormView(string LinkID) : base(LinkID) { }

    [Required]
    public string LocationName { get; set; } = "";

    public IList<ContactFormView> Contacts { get; set; } = new List<ContactFormView>();
    
    [Required]
    [ValidateComplexType]
    public IList<AddressFormView> Addresses { get; set; } = new List<AddressFormView>();
}