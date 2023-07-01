using System;
using ImageStreaming.Domain.Entities;
using ImageStreaming.Shared.Persistence.Common.Interfaces.Services;
using ImageStreaming.Shared.Persistence.Models;

namespace ImageStreaming.Application.Common.Interfaces
{
	public interface IImageService : IBaseService<Image>
	{
        ImageResponse GetLatestImage();
        ImageResponse InsertImage(ImageRequest imageRequest);
    }
}

