using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    public CustomerController()
    {
    }

    [HttpGet]
    public ActionResult<List<Customer>> GetAll() =>
    CustomerService.GetAll();


    // POST action

    // PUT action

    // DELETE action
}