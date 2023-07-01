using System;
using ImageStreaming.Domain.Entities;
using ImageStreaming.Infrastructure.Common;
using ImageStreaming.Infrastructure.Common.Interfaces;
using ImageStreaming.Shared.Persistence.Repositories;

namespace ImageStreaming.Infrastructure.Repositories
{
	public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(InMemoryDbContext appDbContext) : base(appDbContext)
		{

        }

		public Image GetLatestImage()
		{
			var image = DbSet.OrderByDescending(x => x.CreatedDate).FirstOrDefault();

			return image ?? new Image();
		}

        public Image InsertImage(Image image)
        {
            var response = DbSet.Add(image);

            _dbContext.SaveChanges();

            return response.Entity;
        }

        public long GetTotalImages()
        {
            var response = DbSet
                .Where(x => x.CreatedDate > DateTime.Now.AddHours(-1) && x.CreatedDate <= DateTime.Now)
                .Count();

            return response;
        }
    } 
}

