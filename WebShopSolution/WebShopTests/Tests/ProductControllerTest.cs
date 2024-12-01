using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebShop;
using WebShop.Controllers;
using WebShop.Repositories;
using WebShop.UnitOfWork;

namespace WebShopTests.Tests;

public class ProductControllerTest
{
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly ProductController _controller;
    private readonly IUnitOfWork _unitOfWork;

    public ProductControllerTest()
    {
        _mockProductRepository = new Mock<IProductRepository>();

        // Ställ in mock av Products-egenskapen
    }

    [Fact]
    public void GetProducts_ReturnsOkResult_WithAListOfProducts()
    {
        // Arrange
        var testProduct = new List<Product>
        {
            new Product { Id = 1, Name = "Rose", Price = 100 },
            new Product { Id = 2, Name = "Lily", Price = 300 }
        };

        // Act
        var result = _controller.GetProducts();

        // Assert
        var goodResult = Assert.IsType<ActionResult<List<Product>>>(result);
        var resultProduct = Assert.IsType<List<Product>>(goodResult.Value);
        Assert.Equal(2, resultProduct.Count);
    }

    [Fact]
    public void AddProduct_ReturnsOkResult()
    {
        // Arrange
        var product = new Product { Name = "Vitsippa" };

        // Act
        var result = _controller.AddProduct(product);

        // Assert
        var goodResult = Assert.IsType<OkResult>(result);
        _mockProductRepository.Verify(repository => repository.Add(It.Is<Product>(p => p.Name == "Vitsippa")), Times.Once);
        Assert.Equal("Vitsippa", product.Name);
    }
}