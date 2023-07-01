
using System;
using AutoMapper;
using ImageStreaming.Domain.Entities;
using ImageStreaming.Shared.Persistence.Models;

namespace ImageStreaming.Api.Mappings
{
	public class ImageMappings : Profile
	{
		public ImageMappings()
		{
			CreateMap<ImageRequest, Image>().ReverseMap();
            CreateMap<ImageResponse, Image>().ReverseMap();
        }
    }
}

