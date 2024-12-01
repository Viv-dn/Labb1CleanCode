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
        var goodResult = Assert.IsType<OkObjectResult>(result.Result);
        var resultProduct = Assert.IsType<List<Product>>(goodResult.Value);
        Assert.Equal(2, resultProduct.Count);
    }

    [Fact]
    public void AddProduct_ReturnsOkResult()
    {
        // Arrange

        // Act

        // Assert
    }
}