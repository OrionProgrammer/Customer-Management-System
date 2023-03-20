using Customer.Domain.Helpers;
using Customer.Repository.Helpers;

namespace Customer.Repository { }

public class CustomerRepository : GenericRepository<CustomerDetails>, ICustomerRepository
{
    public CustomerRepository(DataContext context) : base(context) { }

}
