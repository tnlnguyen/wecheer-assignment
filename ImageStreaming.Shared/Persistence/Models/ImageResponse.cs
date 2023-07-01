using System;
namespace ImageStreaming.Shared.Persistence.Models
{
    public class ImageResponse
	{
        public Guid Id { get; set; } = new Guid();
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public long Count { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

