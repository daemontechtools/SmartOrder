using System.ComponentModel.DataAnnotations;
namespace SO.Data;

public class ContactFormView : SMARTBaseClassView {
    public ContactFormView(string LinkID) : base(LinkID) {}

    [Required]
    public string DisplayName { get; set; } = "";
    public CommunicationLinkFormView DefaultEmail { get; set; } = new("");
    public CommunicationLinkFormView DefaultPhone { get; set; } = new("");
}