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
            if (string.IsNullOrEmpty(email))
            {
                // Handle the error, for example, return a bad request
                return BadRequest("Email cannot be null or empty");
            }
            //var Sqlstr = "EXEC SaveUser @UId='" + uid.ToString() + "', @Name='" + name + "', @Email='" + email + "', @Password='" + password + "'";
            //var users = await _context.SaveUser.FromSqlRaw(Sqlstr, uid, name, email, password).ToListAsync();
            //return Ok(users);

            var Sqlstr = "EXEC SaveUser @UId, @Name, @Email, @Password";
            SqlParameter parameterS = new SqlParameter("@UId", uid);
            SqlParameter parameterD = new SqlParameter("@Name", name);
            SqlParameter parameterP = new SqlParameter("@Email", email);
            SqlParameter parameterK = new SqlParameter("@Password", password);
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