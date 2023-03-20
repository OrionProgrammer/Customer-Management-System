namespace Customer.Services { }

public class CustomerDetailsService : BaseService<CustomerDetailsModel>, ICustomerDetailsService
{
    public CustomerDetailsService(string baseUrl) : base(baseUrl, "api/CustomerDetails/")
    {
    }
}
