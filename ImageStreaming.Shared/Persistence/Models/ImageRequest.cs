using System;
namespace ImageStreaming.Shared.Persistence.Models
{
	public class ImageRequest
	{
        public Guid Id { get; set; } = new Guid();
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}

