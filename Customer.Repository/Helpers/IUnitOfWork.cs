namespace Customer.Repository.Helpers;

public interface IUnitOfWork
{

    ICustomerRepository Customer { get; }

    Task<int> Complete();

}
