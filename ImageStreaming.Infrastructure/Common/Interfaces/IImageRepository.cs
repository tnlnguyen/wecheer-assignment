using System;
using ImageStreaming.Domain.Entities;
using ImageStreaming.Shared.Persistence.Common.Interfaces.Repositories;

namespace ImageStreaming.Infrastructure.Common.Interfaces
{
	public interface IImageRepository : IBaseRepository<Image>
    {
        Image GetLatestImage();
        Image InsertImage(Image image);
        long GetTotalImages();
    }
}

