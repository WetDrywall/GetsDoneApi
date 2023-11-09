using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GetsDoneApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace GetsDoneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveUserController : ControllerBase
    {
        private readonly SaveUserContext _context;
        public SaveUserController(SaveUserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int uid, string name, string email, string password)
        {
            var Sqlstr = "EXEC SaveUser @UId, @Name, @Email, @Password";
            SqlParameter parameterS = new SqlParameter("@UId", uid);
            SqlParameter parameterD = new SqlParameter("@Name", name != null ? name : "");
            SqlParameter parameterP = new SqlParameter("@Email", email != null ? email : "");
            SqlParameter parameterK = new SqlParameter("@Password", password != null ? password : "");
            var users = await _context.SaveUser.FromSqlRaw(Sqlstr, parameterS, parameterD, parameterP, parameterK).ToListAsync();
            return Ok(users);
        }
        //[HttpGet("{Id}")]
        //public async Task<IActionResult> GetById(int Id)
        //{
        //    var Sqlstr = "EXEC Student @Id=" + Id;
        //    var studentList = await _context.student.FromSqlRaw(Sqlstr).ToListAsync();
        //    return Ok(studentList);

        //}

        //// GET: api/Customer
        //[HttpGet]
        //public ActionResult<IEnumerable<Users>> GetCustomers()
        //{
        //    return _context.Users.ToList();
        //}

        //// GET: api/Customer/1
        //[HttpGet("{id}")]
        //public ActionResult<Users> GetCustomer(int id)
        //{
        //    var customer = _context.Users.Find(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return customer;
        //}

        //// POST: api/Customer
        //[HttpPost]
        //public ActionResult<Users> CreateCustomer(Users customer)
        //{
        //    if (customer == null)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Users.Add(customer);
        //    _context.SaveChanges();
        //    return CreatedAtAction(nameof(GetCustomer), new { id = customer.UId }, customer);
        //}
    }
}