using System.ComponentModel.DataAnnotations;
using SMART.Common.Base;

namespace SO.Data;


public class ShipLocationFormView : SMARTBaseClass {

    public ShipLocationFormView(string LinkID) : base(LinkID) {}

    [Required]
    public string LocationName { get; set; } = default!;

    public ContactFormView DefaultContact { get; set; } = new ContactFormView("");
    
    [Required]
    [ValidateComplexType]
    public AddressFormView DefaultAddress { get; set; } = new AddressFormView("");
}