using SMART.Common.Base;

namespace SmartEstimate.Models;


public class AddressView : SMARTBaseClass {

    public AddressView(string LinkID) : base(LinkID) { }

    public string Street { get; set; }
    public string StreetLine2 { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string PostalCode { get; set; }
}
