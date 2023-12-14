using SMART.Common.Base;

namespace SmartEstimate.Models;


public class ShipLocationView : SMARTBaseClass {

    public ShipLocationView(string LinkID) : base(LinkID) { }

    public string LocationName { get; set; }

    public string LinkIDCompany { get; set; }
    public ContactView DefaultContact { get; set; }
    public AddressView DefaultAddress { get; set; }
}