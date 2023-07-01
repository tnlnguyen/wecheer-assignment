using System;
using AutoMapper;
using ImageStreaming.Api.Mappings;
using ImageStreaming.Application.Services;
using ImageStreaming.Domain.Entities;
using ImageStreaming.Infrastructure.Common;
using ImageStreaming.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace ImageStreaming.Tests.Services
{
	public class ImageServiceTest
	{
        [Test]
        public async Task TestInsertImage()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase(databaseName: "TestDb");

            var myProfile = new ImageMappings();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            // arrange
            using (var db = new InMemoryDbContext(dbOptionsBuilder.Options))
            {
                // fix up some data
                db.Set<Image>().Add(new Image()
                {
                    Description = "test",
                    ImageUrl = "testurl"
                });
                await db.SaveChangesAsync();
            }

            using (var db = new InMemoryDbContext(dbOptionsBuilder.Options))
            {
                var utilityServiceMock = new ImageRepository(db);

                // create the service
                var service = new ImageService(mapper, utilityServiceMock);

                // act
                var result = service.InsertImage(new Shared.Persistence.Models.ImageRequest { Description = "test", ImageUrl = "testurl"});

                // assert
                Assert.NotNull(result);
                Assert.AreEqual("test", result.Description);
                Assert.AreEqual("testurl", result.ImageUrl);
            }
        }
    }
}

