using NSLogistics.Core.Application.Enums;

namespace NSLogistics.Core.Application;

public class Image
{
    public Guid ImageId { get; set; }
    public ImageOriginType ImageOrigin { get; set; }
    public byte[] ImageBytes { get; set; }
    public string ImageType { get; set; }
    public string Name { get; set; }
    public Guid ApplicationId { get; set; }

    public ApplicationEntity Application { get; set; }
}
