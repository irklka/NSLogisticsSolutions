namespace NSLogistics.Core.Shipping;

public class LocationEntity
{
    public Guid LocationId { get; set; }
    public string LocationName { get; set; }
    public string Country { get; set; }
    public string PortCode { get; set; }
}

