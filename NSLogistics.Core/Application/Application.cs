using NSLogistics.Core.User;

namespace NSLogistics.Core.Application;

public class ApplicationEntity
{
    public Guid ApplicationId { get; set; }
    public Guid UserId { get; set; }
    public string CarBrand { get; set; } = null!;
    public string CarModel { get; set; } = null!;
    public string CarYear { get; set; } = null!;
    public string AuctionName { get; set; } = null!;
    public string VinCode { get; set; } = null!;
    public DateTime PurchaseDate { get; set; }
    public string? ContainerNumber { get; set; }
    public string? ShipmentName { get; set; }
    public decimal AuctionPrice { get; set; }
    public decimal ShipmentPrice { get; set; }
    public DateTime? ArrivalDate { get; set; }
    public DateTime? OpeningDate { get; set; }

    public UserEntity User { get; set; }
    public ICollection<Image> CarImages { get; set; }
}
