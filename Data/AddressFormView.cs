using System.ComponentModel.DataAnnotations;
namespace SO.Data;

public class AddressFormView : SmartBaseClass {
    public AddressFormView() : base("") { }
    public AddressFormView(string LinkID) : base(LinkID) { }

    [Required]
    public string Street { get; set; } = "";

    public string StreetLine2 { get; set; } = "";

    [Required]
    public string City { get; set; } = "";

    [Required]
    public string StateProvince { get; set; } = "";

    [Required]
    public string PostalCode { get; set; } = "";

    public string AddressNotes { get; set; } = "";
}
