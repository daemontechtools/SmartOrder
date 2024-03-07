using System.ComponentModel.DataAnnotations;
using SMART.Common.CompanyManagement;

namespace SO.Data;


public class ContactFormView : SMARTBaseClassView {

    public ContactFormView(string LinkID) : base(LinkID) { 
        DefaultEmail = new CommunicationLink("");
        DefaultPhone = new CommunicationLink("");
    }

    [Required]
    public string DisplayName { get; set; }

    public CommunicationLink DefaultEmail { get; set; }

    public CommunicationLink DefaultPhone { get; set; }
}