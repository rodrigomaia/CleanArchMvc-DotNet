using CleanArchMvc.Domain.Validations;

namespace CleanArchMvc.Domain.Entities;
public sealed class Category : Entity
{
    public string Name { get; private set; }
    public ICollection<Product> Products { get; set; }

    public Category(string name)
    {
        Validate(name);
        Name = name;
    }

    public Category(int id, string name)
    {
        Validate(id, name);
        Id = id;
        Name = name;
    }

    public void Update(string name)
    {
        Validate(name);
        Name = name;
    }

    private void Validate(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cant be null or empty");
        DomainExceptionValidation.When(name.Length < 3, "Name must be have 3 or more chars");
    }

    private void Validate(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Id invalid");
        Validate(name);
    }
}