using GetsDoneApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace GetsDoneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveWorkflowController : ControllerBase
    {
        private readonly SaveWorkflowContext _context;
        public SaveWorkflowController(SaveWorkflowContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int wfid, string title, string desc, string jwtToken, string wUser, DateTime? deadline)
        {
            var token = new JwtSecurityToken(jwtToken);
            int uid = int.TryParse(token.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value, out int a) ? a : 0;
            var expirationDate = token.ValidTo;

            if (uid > 0 && expirationDate > DateTime.Now)
            {
                var Sqlstr = "EXEC SaveWorkflow @WFId, @Title, @Description, @WOwner, @WUser, @Deadline";
                SqlParameter parameterS = new SqlParameter("@WFId", wfid.ToString());
                SqlParameter parameterD = new SqlParameter("@Title", title != null ? title : "");
                SqlParameter parameterP = new SqlParameter("@Description", desc != null ? desc : "");
                SqlParameter parameterK = new SqlParameter("@WOwner", uid.ToString());
                SqlParameter parameterL = new SqlParameter("@WUser", wUser != null ? wUser : "");
                SqlParameter parameterJ = new SqlParameter("@Deadline", deadline != null ? deadline : DBNull.Value);
                var users = await _context.SaveWorkflow.FromSqlRaw(Sqlstr, parameterS, parameterD, parameterP, parameterK, parameterL, parameterJ).ToListAsync();
                return Ok(users);
            }

            return null;
        }
    }
}