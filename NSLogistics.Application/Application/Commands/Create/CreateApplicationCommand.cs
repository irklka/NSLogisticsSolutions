using FluentValidation;

using MediatR;

namespace NSLogistics.Application.Application.Commands.Create;

public class CreateApplicationCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string CarBrand { get; set; }
    public string CarModel { get; set; }
    public string CarYear { get; set; }
    public string AuctionName { get; set; }
    public string VinCode { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string? ContainerNumber { get; set; }
    public string? ShipmentName { get; set; }
    public decimal AuctionPrice { get; set; }
    public decimal ShipmentPrice { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime OpeningDate { get; set; }
}

public class CreateApplicationCommandValidator : AbstractValidator<CreateApplicationCommand>
{
    public CreateApplicationCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.");

        RuleFor(x => x.CarBrand)
            .NotEmpty()
            .WithMessage("Car brand is required.")
            .MaximumLength(50)
            .WithMessage("Car brand cannot exceed 50 characters.");

        RuleFor(x => x.CarModel)
            .NotEmpty()
            .WithMessage("Car model is required.")
            .MaximumLength(50)
            .WithMessage("Car model cannot exceed 50 characters.");

        RuleFor(x => x.CarYear)
            .NotEmpty()
            .WithMessage("Car year is required.")
            .Matches(@"^\d{4}$")
            .WithMessage("Car year must be a valid 4-digit year.");

        RuleFor(x => x.AuctionName)
            .NotEmpty()
            .WithMessage("Auction name is required.")
            .MaximumLength(100)
            .WithMessage("Auction name cannot exceed 100 characters.");

        RuleFor(x => x.VinCode)
            .NotEmpty()
            .WithMessage("VIN code is required.")
            .Length(17)
            .WithMessage("VIN code must be exactly 17 characters.");

        RuleFor(x => x.PurchaseDate)
            .NotEmpty()
            .WithMessage("Purchase date is required.");

        RuleFor(x => x.AuctionPrice)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.ShipmentPrice)
            .GreaterThanOrEqualTo(0);
    }
}

