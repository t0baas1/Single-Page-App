using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace backend.Controllers;

[ApiController]
[EnableCors]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    public CustomerController()
    {
    }

    [HttpGet]
    [EnableCors]
    public ActionResult<List<Customer>> GetAll() =>
    CustomerService.GetAll();


    // POST action

    // PUT action

    // DELETE action
}