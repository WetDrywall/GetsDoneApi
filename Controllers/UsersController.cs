using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GetsDoneApi.Models;

namespace GetsDoneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly UsersContext _context;
        public CustomerController(UsersContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetCustomers()
        {
            return _context.Users.ToList();
        }

        // GET: api/Customer/1
        [HttpGet("{id}")]
        public ActionResult<Users> GetCustomer(int id)
        {
            var customer = _context.Users.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Users> CreateCustomer(Users customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            _context.Users.Add(customer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.UId }, customer);
        }
    }
}