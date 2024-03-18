using System.ComponentModel.DataAnnotations;
namespace SO.Data;

public class CommunicationLinkFormView : SMARTBaseClassView {
    public CommunicationLinkFormView(string LinkID) : base(LinkID) {}

    [Required]
    public string DisplayAs { get; set; } = "";
}