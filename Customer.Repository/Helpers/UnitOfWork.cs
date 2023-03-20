namespace Customer.Repository.Helpers;

using System;
using Customer.Domain.Helpers;
using System.Threading.Tasks;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public ICustomerRepository Customer { get; }

    public UnitOfWork(DataContext dataContext,
        ICustomerRepository customerRepository )
    {
        this._context = dataContext;
        this.Customer = customerRepository;
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}