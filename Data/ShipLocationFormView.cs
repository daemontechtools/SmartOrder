using System.ComponentModel.DataAnnotations;
namespace SO.Data;

public class ShipLocationFormView : SmartBaseClass {

    public ShipLocationFormView() : this("") { }
    public ShipLocationFormView(string LinkID) : base(LinkID) {
        Contacts = new List<ContactFormView>();
        Contacts.Add(new ContactFormView());
        Addresses = new List<AddressFormView>();
        Addresses.Add(new AddressFormView());
    }

    [Required]
    public string LocationName { get; set; } = "";

    public IList<ContactFormView> Contacts { get; set; }
    
    [Required]
    [ValidateComplexType]
    public IList<AddressFormView> Addresses { get; set; }
}