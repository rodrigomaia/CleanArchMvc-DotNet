using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validations;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Description", 10, 100, "image");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", "Description", 10, 100, "image");
        action.Should()
            .Throw<DomainExceptionValidation>()
             .WithMessage("Id invalid");
    }
    [Fact]
    public void CreateProduct_WithShortName_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Ca", "Description", 10, 100, "image");
        action.Should().Throw<DomainExceptionValidation>()
                        .WithMessage("Name must be have 3 or more chars");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void CreateProduct_WithNullNameOrMissing_DomainExceptionShortName(string name)
    {
        Action action = () => new Product(1, name, "Description", 10, 100, "image");
        action.Should().Throw<DomainExceptionValidation>()
                        .WithMessage("Name cant be null or empty");
    }
    [Fact]
    public void CreateProduct_WithShortDescription_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Product Name", "Desc", 10, 100, "image");
        action.Should().Throw<DomainExceptionValidation>()
                        .WithMessage("Description must be have 5 or more chars");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void CreateProduct_WithNullDescriptionOrMissing_DomainExceptionShortName(string description)
    {
        Action action = () => new Product(1, "Product Name", description, 10, 100, "image");
        action.Should().Throw<DomainExceptionValidation>()
                        .WithMessage("Description cant be null or empty");
    }

    [Fact]
    public void CreateProduct_WithNegativePrice_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Product Name", "Description", -1, 100, "image");
        action.Should().Throw<DomainExceptionValidation>()
                        .WithMessage("Price must have bigger than 0");
    }

    [Fact]
    public void CreateProduct_WithNegativeStock_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Product Name", "Description", 10m, -1, "image");
        action.Should().Throw<DomainExceptionValidation>()
                        .WithMessage("Stock must have bigger than 0");
    }

    [Fact]
    public void CreateProduct_WithImageTooLong_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Product Name", "Description", 10, 100, "".PadRight(251, 'x'));
        action.Should().Throw<DomainExceptionValidation>()
                        .WithMessage("Image name is too long");
    }

    [Fact]
    public void CreateProduct_WithImageNull_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Description", 10, 100, null);
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_WithImageNull_NullReferenceException()
    {
        Action action = () => new Product(1, "Product Name", "Description", 10, 100, null);
        action.Should().NotThrow<NullReferenceException>();
    }

}