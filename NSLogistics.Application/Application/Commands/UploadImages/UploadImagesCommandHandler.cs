using Ardalis.Specification;

using MediatR;

using Microsoft.AspNetCore.Http;

using NSLogistics.Core.Application;
using NSLogistics.Core.Application.Enums;

using SixLabors.ImageSharp.Processing;

namespace NSLogistics.Application.Application.Commands.UploadImages;

public class UploadImagesCommandHandler : IRequestHandler<UploadImagesCommand, bool>
{
    private readonly IRepositoryBase<ApplicationEntity> _applicationRepository;
    private readonly IRepositoryBase<Image> _imageRepository;

    private ImageOriginType? _imageOrigin;
    public UploadImagesCommandHandler(IRepositoryBase<ApplicationEntity> applicationRepository,
        IRepositoryBase<Image> imageRepository)
    {
        _applicationRepository = applicationRepository;
        _imageRepository = imageRepository;
    }

    public async Task<bool> Handle(UploadImagesCommand request, CancellationToken cancellationToken)
    {
        var application = await _applicationRepository.GetByIdAsync(request.ApplicationId, cancellationToken)
            ?? throw new ApplicationNotFoundException("application was not found");

        _imageOrigin = request.ImageOrigin;

        var imageDtos = new List<ImageDto>();

        foreach (var file in request.Data)
        {
            if (file.Length <= 0)
                continue;
            var imageDto = await ProcessImageAsync(file);
            imageDtos.Add(imageDto);
        }

        AddImages(imageDtos, application);

        await _applicationRepository.SaveChangesAsync(cancellationToken);

        return true;
    }

    public static void AddImages(IEnumerable<ImageDto> images, ApplicationEntity application)
    {
        foreach (var imageDto in images)
        {
            application.CarImages.Add(new Image
            {
                ImageId = Guid.NewGuid(),
                Name = imageDto.Name,
                ImageBytes = imageDto.ImageBytes,
                ImageType = imageDto.ImageType,
                ImageOrigin = imageDto.ImageOrigin,
                ApplicationId = application.ApplicationId,
            });
        }
    }

    private async Task<ImageDto> ProcessImageAsync(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);

        var imageBytes = memoryStream.ToArray();
        var processedImageBytes = ResizeAndConvertToJpg(imageBytes);

        return new ImageDto
        {
            Name = file.FileName,
            ImageBytes = processedImageBytes,
            ImageType = "image/jpeg",
            ImageOrigin = _imageOrigin.Value
        };
    }

    private byte[] ResizeAndConvertToJpg(byte[] imageBytes)
    {
        using var inputStream = new MemoryStream(imageBytes);
        using var image = SixLabors.ImageSharp.Image.Load(inputStream);

        // Resize image to 500x500
        image.Mutate(x => x.Resize(500, 500));

        using var outputStream = new MemoryStream();
        var encoder = new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder { Quality = 85 }; // Adjust quality if needed
        image.Save(outputStream, encoder);

        return outputStream.ToArray();
    }

    public class ImageDto
    {
        public string Name { get; set; } = null!; // Added name
        public byte[] ImageBytes { get; set; } = null!;
        public string ImageType { get; set; } = null!;
        public ImageOriginType ImageOrigin { get; set; }
    }
}
