namespace Customer.Api.Controllers;

using System.Threading.Tasks;
using Customer.API.Helpers;
using Customer.Repository.Helpers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Net;

[Route("api/[controller]")]
[ApiController]
public class CustomerDetailsController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomerDetailsController(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    [HttpGet]
    public IActionResult Index()
    {
        return Ok(HttpStatusCode.NotImplemented);
    }


    /// <summary>
    /// management Functions for Customer Details
    /// </summary>
    /// 
    #region Admin Functions

    /// <summary>
    /// Create New Customer
    /// </summary>
    /// <param name="CustomerDetailsModel"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerDetailsModel model)
    {
        #region Validation
        if (!ModelState.IsValid)
            return BadRequest(new { message = GetErrors() });
        #endregion

        var customer = _mapper.Map<CustomerDetails>(model);

        // add customer object for inserting
        await _unitOfWork.Customer.InsertAsync(customer);
        int complete = await _unitOfWork.Complete();

        return Ok(complete);
    }

    /// <summary>
    /// Fetch Customer Details by Id
    /// </summary>
    /// <param name="id">id of customer in database</param>
    /// <returns>CustomerDetailsModel</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        #region Validation
        if (id <= 0)
            return BadRequest(new { message = "Id must be greater than 0!" });
        #endregion

        //fetch customer by id
        var picture = await _unitOfWork.Customer.GetByIdAsync(id);
        await _unitOfWork.Complete();

        if (picture == null)
            return BadRequest(new { message = "Customer does not exist!" });

        var customerModel = _mapper.Map<CustomerDetailsModel>(picture);

        return Ok(customerModel);
    }


    /// <summary>
    /// Edit a Customer Details
    /// </summary>
    /// <param name="id">Id of the Customer to update</param>
    /// <param name="CustomerModel">Model of data to update</param>
    /// <returns></returns>
    [HttpPut()]
    public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDetailsModel model)
    {
        #region Validation
        if (!ModelState.IsValid)
            return BadRequest(new { message = GetErrors() });
        #endregion

        CustomerDetails customer = _mapper.Map<CustomerDetails>(model);

        //add customer object for updating
        await _unitOfWork.Customer.Update(customer, model.Id);

        return Ok(await _unitOfWork.Complete());
    }


    /// <summary>
    /// Delete a Customer
    /// </summary>
    /// <param name="Id">Id of Customer</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCustomer(int id)
    {
        #region Validation
        if (id <= 0)
            return BadRequest(new { message = "Id must be greater than 0" });
        #endregion

        _unitOfWork.Customer.Delete(id);

        return Ok(await _unitOfWork.Complete());
    }

    /// <summary>
    /// Fetch Customer List
    /// </summary>
    /// <returns>A list of Customers</returns>
    [HttpGet("list")]
    public async Task<IActionResult> GetAll()
    {
        var customerist = await _unitOfWork.Customer.GetAllAsync();
        await _unitOfWork.Complete();
        return Ok(customerist);
    }

    #endregion
}
