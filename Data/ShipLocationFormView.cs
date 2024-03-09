using System.ComponentModel.DataAnnotations;
using SMART.Common.Base;

namespace SO.Data;


public class ShipLocationFormView : SMARTBaseClass {

    public ShipLocationFormView(string LinkID) : base(LinkID) { 
        DefaultContact = new ContactFormView("");
        DefaultAddress = new AddressFormView("");
    }

    [Required]
    public string LocationName { get; set; } = default!;

    public ContactFormView DefaultContact { get; set; }
    
    [Required]
    [ValidateComplexType]
    public AddressFormView DefaultAddress { get; set; }
}