using System;
using AutoMapper;
using ImageStreaming.Application.Common.Interfaces;
using ImageStreaming.Domain.Entities;
using ImageStreaming.Infrastructure.Common.Interfaces;
using ImageStreaming.Shared.Persistence.Models;
using ImageStreaming.Shared.Persistence.Services;

namespace ImageStreaming.Application.Services
{
	public class ImageService : BaseService<Image>, IImageService
    {
		private readonly IImageRepository pureImageRepository;
        public ImageService(IMapper mapper, IImageRepository repository) : base(mapper, repository)
		{
			pureImageRepository = _repository as IImageRepository;
        }

		public ImageResponse GetLatestImage()
		{
			try
			{
                var image = pureImageRepository.GetLatestImage();
				var count = pureImageRepository.GetTotalImages();

				var response = _mapper.Map<ImageResponse>(image);
				response.Count = count;

				return response;
            } catch (Exception)
            {
                throw;
				// We can throw our custom exceptions
            }
		}

		public ImageResponse InsertImage(ImageRequest imageRequest)
		{
			try
			{
                var image = _mapper.Map<Image>(imageRequest);

                var newImage = pureImageRepository.InsertImage(image);
                var count = pureImageRepository.GetTotalImages();

                var response = _mapper.Map<ImageResponse>(newImage);
                response.Count = count;

				return response;
            } catch (Exception)
			{
                throw;
            }
        }
	}
}

