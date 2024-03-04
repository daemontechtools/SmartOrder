using System.ComponentModel.DataAnnotations;
using SMART.Common.Base;

namespace SO.Data;


public class ShipLocationView : SMARTBaseClass {

    public ShipLocationView(string LinkID) : base(LinkID) { 
        DefaultContact = new ContactView("");
        DefaultAddress = new AddressView("");
    }

    [Required]
    public string LocationName { get; set; }

    public ContactView DefaultContact { get; set; }
    
    [Required]
    [ValidateComplexType]
    public AddressView DefaultAddress { get; set; }
}