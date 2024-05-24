using System.ComponentModel.DataAnnotations;
namespace SO.Data;

public class ShipLocationFormView : SmartBaseClass {

    public ShipLocationFormView() : this("") { }
    public ShipLocationFormView(string LinkID) : base(LinkID) {
        Address = new AddressFormView();
    }

    [Required]
    public string LocationName { get; set; } = "";

    public string ContactLinkID { get; set; } = "";
    
    [Required]
    [ValidateComplexType]
    public AddressFormView Address { get; set; }
}