namespace CleanArchMvc.Domain.Validations;

public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string err) : base(err)
    {}

    public static void When(bool hasError, string error){
        if(hasError) throw new DomainExceptionValidation(error);
    }
}
