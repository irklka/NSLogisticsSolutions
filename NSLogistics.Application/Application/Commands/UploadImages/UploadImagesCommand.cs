using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Http;

using NSLogistics.Core.Application.Enums;

namespace NSLogistics.Application.Application.Commands.UploadImages;

public class UploadImagesCommand : IRequest<bool>
{
    public Guid ApplicationId { get; set; }
    public List<IFormFile> Data { get; set; }
    public ImageOriginType ImageOrigin { get; set; }
}

public class UploadImagesCommandValidator : AbstractValidator<UploadImagesCommand>
{
    public UploadImagesCommandValidator()
    {
        RuleFor(x => x.ApplicationId)
            .NotEmpty()
            .WithMessage("Application ID is required.");

        RuleFor(x => x.Data)
            .NotEmpty()
            .WithMessage("At least one image file is required.")
            .Must(data => data.All(file => file.Length > 0))
            .WithMessage("All files must have content.");

        RuleForEach(x => x.Data).ChildRules(file =>
        {
            file.RuleFor(f => f.Length)
                .LessThanOrEqualTo(5 * 1024 * 1024) // Max 5 MB
                .WithMessage("Each image file must be less than or equal to 5 MB.");

            file.RuleFor(f => f.ContentType)
                .Must(contentType => contentType == "image/jpeg" || contentType == "image/png")
                .WithMessage("Only JPEG and PNG formats are supported.");
        });

        RuleFor(x => x.ImageOrigin)
            .IsInEnum()
            .WithMessage("Invalid image origin specified.");
    }
}
