using System.ComponentModel.DataAnnotations;

namespace Customer.Domain { }

public class CustomerDetails
{
    [Key]
    public int Id { get; set; }

    [ConcurrencyCheck]
    public string FirstName { get; set; }

    [ConcurrencyCheck]
    public string Surname { get; set; }
}
