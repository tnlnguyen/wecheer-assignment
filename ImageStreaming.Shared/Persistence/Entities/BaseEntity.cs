using System;
namespace ImageStreaming.Shared.Persistence.Entities
{
	public class BaseEntity
	{
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}

