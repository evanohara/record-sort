using CraftJackRecordSortShared.Dto;
using CraftJackRecordSortShared.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using CraftJackRecordSortShared.Data;
using CraftJackRecordSortAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http;
using System.Web.Http.Routing;

namespace CraftJackRecordSortAPI.Tests
{
    [TestFixture]
    public class RecordsControllerTests
    {
        RecordsController recordsController;
        HttpConfiguration httpConfig;

        [SetUp]
        public void SetUp()
        {
            var recordsRepository = new Mock<IRecordsRepository>();
            recordsController = new RecordsController(recordsRepository.Object);
            httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();
            httpConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{sortType}",
                defaults: new { sortType = RouteParameter.Optional }
            );
            recordsController.Configuration = httpConfig;
        }

        [Test]
        public void Post_WhenRecordIsNull_ReturnBadRequest()
        {
            // No Additional Arrangement Needed

            // Act
            var result = recordsController.Post(null);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestResult>());
        }

        [Test]
        [Ignore("Model isnt binding, from what I read on Integration tests, I think this falls in that category.")]
        public void Post_WhenRecordParametersAreInvalid_ReturnBadRequestWithModel()
        {
            // Arrange
            var invalidRecordDto = new Mock<RecordDto>();
            invalidRecordDto.Object.LastName = "Washington";

            // Act
            var result = recordsController.Post(invalidRecordDto.Object);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestErrorMessageResult>());
        }

        [Test]
        public void Post_WhenRecordParametersAreValid_ReturnBadRequestWithModel()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/records/");
            recordsController.Url = new UrlHelper(request);
            recordsController.Request = request;

            // Act
            var result = recordsController.Post(new RecordDto(
                "Potter", "Harry", "Male", "Red", new DateTime(1974, 12, 18)
                ));

            // Assert
            Assert.That(result, Is.TypeOf<CreatedNegotiatedContentResult<RecordDto>>());
        }

        [Test]
        [TestCase("gender")]
        [TestCase("birthdate")]
        [TestCase("name")]
        //TODO Package these categories and do this test with a reference to the package
        public void Get_WhenValidSortTypeIsRequested_ExpectOkResponse(string sortType)
        {
            var result = recordsController.Get(sortType);
            // Assert
            Assert.That(result, Is.TypeOf<OkNegotiatedContentResult<IList<Record>>>());
        }

        [Test]
        public void Get_WhenInvalidSortTypeIsRequested_ExpectOkResponse()
        {
            var result = recordsController.Get("bumblebeetuna");
            // Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}
