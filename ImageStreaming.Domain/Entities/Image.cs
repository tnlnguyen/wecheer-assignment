using System;
using ImageStreaming.Shared.Persistence.Entities;

namespace ImageStreaming.Domain.Entities
{
	public class Image : BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}

