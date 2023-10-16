using System.ComponentModel.DataAnnotations;

namespace SmartEstimate.Models;

public struct QuoteView {

    [Required]
    public string Name { get; set; }

    [Required]
    public QuoteStatus Status  { get; set; }
    public string SalesAssociate { get; set; }
    public string ContactInfo { get; set; }
    public ShippingAddress  DealerAddress { get; set; }
    public ShippingAddress  CustomerAddress { get; set; }
    public bool IsPickup { get; set; }
    public bool IsDelivery { get; set; }
    public bool IsDealer { get; set; }
    public bool IsApartment { get; set; }
    public bool IsMultiLevel { get; set; }
    public bool IsFreightForwarder { get; set; }
    public string CatelogPdfUrl { get; set; }

    public List<Room> Rooms { get; set; }
}