using System.ComponentModel.DataAnnotations;
using SMART.Common.Base;

namespace SmartEstimate.Models;


public class ContactView : SMARTBaseClassView {

    public ContactView(string LinkID) : base(LinkID) { 
        DefaultEmail = new CommunicationLinkView("");
        DefaultPhone = new CommunicationLinkView("");
    }

    [Required]
    public string DisplayName { get; set; }

    public CommunicationLinkView DefaultEmail { get; set; }

    public CommunicationLinkView DefaultPhone { get; set; }
}