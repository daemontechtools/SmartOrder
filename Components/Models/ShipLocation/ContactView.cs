using System.ComponentModel.DataAnnotations;
using SMART.Common.Base;

namespace SmartEstimate.Models;


public class ContactView : SMARTBaseClass {

    public ContactView(string LinkID) : base(LinkID) { }

    [Required]
    public string DisplayName { get; set; }

    public string DefaultEmail { get; set; }

    public string DefaultPhone { get; set; }
}