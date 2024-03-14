using System.ComponentModel.DataAnnotations;
using SMART.Common.CompanyManagement;
namespace SO.Data;

public class ContactFormView : SMARTBaseClassView {
    public ContactFormView(string LinkID) : base(LinkID) {}

    [Required]
    public string DisplayName { get; set; } = default!;
    public CommunicationLink DefaultEmail { get; set; } = new();
    public CommunicationLink DefaultPhone { get; set; } = new();
}