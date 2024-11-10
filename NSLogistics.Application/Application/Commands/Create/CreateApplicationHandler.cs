using Ardalis.Specification;

using MediatR;

using NSLogistics.Application.Common.Services.User.Interfaces;
using NSLogistics.Core.Application;

namespace NSLogistics.Application.Application.Commands.Create;

public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, Guid>
{
    private readonly IRepositoryBase<ApplicationEntity> _applicationRepository;
    private readonly ICurrentUserService _currentUserService;

    public CreateApplicationCommandHandler(IRepositoryBase<ApplicationEntity> applicationRepository,
        ICurrentUserService currentUserService)
    {
        _applicationRepository = applicationRepository;
        _currentUserService = currentUserService;
    }

    public async Task<Guid> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
    {
        if (!_currentUserService.IsAdmin())
        {
            throw new UnauthorizedAccessException("Only admins can add new applications.");
        }

        var application = new ApplicationEntity
        {
            ApplicationId = Guid.NewGuid(),
            UserId = request.UserId,
            CarBrand = request.CarBrand,
            CarModel = request.CarModel,
            CarYear = request.CarYear,
            AuctionName = request.AuctionName,
            VinCode = request.VinCode,
            PurchaseDate = request.PurchaseDate,
            ContainerNumber = request.ContainerNumber,
            ShipmentName = request.ShipmentName,
            AuctionPrice = request.AuctionPrice,
            ShipmentPrice = request.ShipmentPrice,
            ArrivalDate = request.ArrivalDate,
            OpeningDate = request.OpeningDate,
        };

        //if (request.Images != null && request.Images.Any())
        //{
        //    AddImages(request.Images, application);
        //}

        await _applicationRepository.AddAsync(application, cancellationToken);
        await _applicationRepository.SaveChangesAsync(cancellationToken);

        return application.ApplicationId;
    }

    //public static void AddImages(IEnumerable<ImageDto> images, ApplicationEntity application)
    //{
    //    foreach (var imageDto in images)
    //    {
    //        application.CarImages.Add(new Image
    //        {
    //            ImageId = Guid.NewGuid(),
    //            Name = imageDto.Name,
    //            ImageBytes = imageDto.ImageBytes,
    //            ImageType = imageDto.ImageType,
    //            ImageOrigin = imageDto.ImageOrigin,
    //            ApplicationId = application.ApplicationId,
    //        });
    //    }
    //}
}
