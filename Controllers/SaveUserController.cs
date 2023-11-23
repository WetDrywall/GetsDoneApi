using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GetsDoneApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.VisualBasic;

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
        public async Task<IActionResult> Get(string jwtToken, string name, string email, string password)
        {
            int uid = 0;
            var expirationDate = DateTime.Now.AddDays(1);

            if (jwtToken != "new")
            {
                var token = new JwtSecurityToken(jwtToken);
                uid = int.TryParse(token.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value, out int a) ? a : 0;
                expirationDate = token.ValidTo;
            }
            

            if ((uid > 0 && expirationDate > DateTime.Now) || (jwtToken == "new"))
            {
                var Sqlstr = "EXEC SaveUser @UId, @Name, @Email, @Password, @SendEmail";
                SqlParameter parameterS = new SqlParameter("@UId", uid);
                SqlParameter parameterD = new SqlParameter("@Name", name != null ? name : "");
                SqlParameter parameterP = new SqlParameter("@Email", email != null ? email : "");
                SqlParameter parameterK = new SqlParameter("@Password", password != null ? password : "");
                SqlParameter parameterJ = new SqlParameter("@SendEmail", false);
                var users = await _context.SaveUser.FromSqlRaw(Sqlstr, parameterS, parameterD, parameterP, parameterK, parameterJ).ToListAsync();
                return Ok(users);
            }
            return null;
        }        
    }
}