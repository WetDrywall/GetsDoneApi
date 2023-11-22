using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GetsDoneApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using NuGet.Protocol;

namespace GetsDoneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly UserLoginContext _context;
        private readonly IConfiguration _configuration;
        public UserLoginController(UserLoginContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email, string password)
        {
            var Sqlstr = "EXEC UserLogin @Email, @Password";
            SqlParameter parameterS = new SqlParameter("@Email", email);
            SqlParameter parameterD = new SqlParameter("@Password", password);
            var users = await _context.UserLogin.FromSqlRaw(Sqlstr, parameterS, parameterD).ToListAsync();

            string token = "";

            if (users[0].Findes)
            {
                token = CreateToken(users[0].UId);
            }
            //return Ok(users);
            return Ok(token.ToJson());
        }

        private string CreateToken(int uid)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, uid.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}