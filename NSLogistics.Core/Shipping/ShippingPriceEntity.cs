namespace NSLogistics.Core.Shipping;

public class ShippingPriceEntity
{
    public Guid ShippingPriceId { get; set; }
    public Guid OriginLocationId { get; set; }
    public Guid DestinationLocationId { get; set; }
    public decimal Price { get; set; }
    public int TransitDays { get; set; }
}
