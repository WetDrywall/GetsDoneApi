using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GetsDoneApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;

namespace GetsDoneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListUsersController : ControllerBase
    {
        private readonly ListUsersContext _context;
        public ListUsersController(ListUsersContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int uid)
        {
            var Sqlstr = "EXEC ListUsers @UId";
            SqlParameter parameterS = new SqlParameter("@UId", uid);
            var users = await _context.ListUsers.FromSqlRaw(Sqlstr, parameterS).ToListAsync();
            return Ok(users);
        }        
    }
}