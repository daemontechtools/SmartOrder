using System.ComponentModel.DataAnnotations;
namespace SO.Data;

public class ShipLocationFormView : SmartBaseClass {

    public ShipLocationFormView() : this("") { }
    public ShipLocationFormView(string LinkID) : base(LinkID) {
        Contact = new ContactFormView();
        Address = new AddressFormView();
    }

    [Required]
    public string LocationName { get; set; } = "";

    [Required]
    [ValidateComplexType]
    public ContactFormView Contact { get; set; }
    
    [Required]
    [ValidateComplexType]
    public AddressFormView Address { get; set; }
}