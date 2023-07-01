using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageStreaming.Application.Common.Interfaces;
using ImageStreaming.Shared.Persistence.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageStreaming.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : Controller
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet(Urls.V1.Event.Get, Name = nameof(GetLatest))]
    public ActionResult<IEnumerable<ImageResponse>> GetLatest()
    {
        var response = _imageService.GetLatestImage();

        return Ok(response);
    }

    [HttpPost(Urls.V1.Event.Post, Name = nameof(Post))]
    public ActionResult<ImageResponse> Post([FromBody] ImageRequest req)
    {
        var response = _imageService.InsertImage(req);
        return Ok(response);
    }
}

