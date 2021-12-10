using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using Sample.Domain.Product;
using Sample.Domain.Product.Exceptions;

namespace Sample.UnitTests.Domain
{
    public class ProductTests
    {
        [Test]
        public void Create_ValidData_ShouldCreateProduct()
        {
            //Arrange
            var name = "valid";

            //Act
            var product = Product.Create("valid");

            //Arrange
            product.Name.Should().Be(name);
            product.Id.Should().NotBe(default(Guid));
        }

        [TestCase("")]
        [TestCase(null)]
        public void Create_InvalidName_ShouldThroeException(string name)
        {
            //Arrange
            Action createProduct = () => Product.Create(name);

            //Act & assert
            createProduct.Should().Throw<RequiredFieldNotProvidedException>();
        }
    }
}
