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
    }
}