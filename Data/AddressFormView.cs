using System.ComponentModel.DataAnnotations;
using SMART.Common.Base;
namespace SO.Data;

public class AddressFormView : SMARTBaseClass {

    public AddressFormView(string LinkID) : base(LinkID) { }

    [Required]
    public string Street { get; set; } = default!;

    public string StreetLine2 { get; set; } = default!;

    [Required]
    public string City { get; set; } = default!;

    [Required]
    public string StateProvince { get; set; } = default!;

    [Required]
    public string PostalCode { get; set; } = default!;
}
