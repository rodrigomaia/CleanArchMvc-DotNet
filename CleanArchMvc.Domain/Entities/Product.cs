using CleanArchMvc.Domain.Validations;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        Validate(name, description, price, stock, image);

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        Validate(id, name, description, price, stock, image);

        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        Validate(name, description, price, stock, image);

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        CategoryId = categoryId;
    }

    private void Validate(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cant be null or empty");
        DomainExceptionValidation.When(name.Length < 3, "Name must be have 3 or more chars");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description cant be null or empty");
        DomainExceptionValidation.When(description.Length < 5, "Description must be have 5 or more chars");

        DomainExceptionValidation.When(price < 0, "Price must have bigger than 0");
        DomainExceptionValidation.When(stock < 0, "Stock must have bigger than 0");

        DomainExceptionValidation.When(image?.Length > 250, "Image name is too long");
    }

    private void Validate(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(id < 0, "Id invalid");
        Validate(name, description, price, stock, image);
    }
}