using System.ComponentModel.DataAnnotations;
using SMART.Common.Base;

namespace SO.Data;


public class CommunicationLinkView : SMARTBaseClass {

    public CommunicationLinkView(string LinkID) : base(LinkID) { }

    public string DisplayAs { get; set; }
}