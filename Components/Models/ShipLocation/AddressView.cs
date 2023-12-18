using System.ComponentModel.DataAnnotations;
using SMART.Common.Base;

namespace SmartEstimate.Models;


public class AddressView : SMARTBaseClass {

    public AddressView(string LinkID) : base(LinkID) { }

    [Required]
    public string Street { get; set; }

    public string StreetLine2 { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string StateProvince { get; set; }

    [Required]
    public string PostalCode { get; set; }

    
    public string AddressNotes { get; set; }
}
