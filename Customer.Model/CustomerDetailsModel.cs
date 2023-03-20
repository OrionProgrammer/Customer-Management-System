
using System.ComponentModel.DataAnnotations;

namespace Customer.Model { }

public class CustomerDetailsModel
{

    [Display(Name = "Customer Id")]
    public int Id { get; set; } = 0;

    [Required(ErrorMessage = "First Name is required!")]
    [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters!")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Surname is required!")]
    [StringLength(50, ErrorMessage = "Surname cannot be longer than 50 characters!")]
    [Display(Name = "Surname")]
    public string Surname { get; set; }
}