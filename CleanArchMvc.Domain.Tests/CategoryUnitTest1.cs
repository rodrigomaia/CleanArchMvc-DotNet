using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validations;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name ");
        action.Should()
            .Throw<DomainExceptionValidation>()
             .WithMessage("Id invalid");
    }
    [Fact]
    public void CreateCategory_WithShortName_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should().Throw<DomainExceptionValidation>()
                        .WithMessage("Name must be have 3 or more chars"); ;
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void CreateCategory_WithNullNameOrMissing_DomainExceptionShortName(string name)
    {
        Action action = () => new Category(1, name);
        action.Should().Throw<DomainExceptionValidation>()
                        .WithMessage("Name cant be null or empty"); ;
    }

}