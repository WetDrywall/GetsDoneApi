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
    public class UserLoginController : ControllerBase
    {
        private readonly UserLoginContext _context;
        public UserLoginController(UserLoginContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email, string password)
        {
            var Sqlstr = "EXEC UserLogin @Email, @Password";
            SqlParameter parameterS = new SqlParameter("@Email", email);
            SqlParameter parameterD = new SqlParameter("@Password", password);
            var users = await _context.UserLogin.FromSqlRaw(Sqlstr, parameterS, parameterD).ToListAsync();
            return Ok(users);
        }
    }
}