using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Sample.Api.Controllers;
using Sample.Commands.Products.Add;

namespace Sample.UnitTests.Api
{
    public class ProductControllerTests
    {
        [Test]
        public async Task Create_ValidData_ShouldReturn201()
        {
            //Arrange
            var id = Guid.NewGuid();
            var name = "name";

            var mediator = new Mock<IMediator>();
            mediator
                .Setup(x => x.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(id);

            var expectedLocation = $"api/product/{id}";

            var sut = new ProductController(mediator.Object);

            //Act
            var result = await sut.Create(new AddProductCommand(name));

            //Arrange
            result.Should().BeOfType<CreatedResult>();
            result.As<CreatedResult>().Location.Should().Be(expectedLocation);
        }
    }
}
