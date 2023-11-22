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
    public class ListWorkflowController : ControllerBase
    {
        private readonly ListWorkflowContext _context;
        public ListWorkflowController(ListWorkflowContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int wfid, string jwtToken)
        {
            var token = new JwtSecurityToken(jwtToken);
            int uid = int.TryParse(token.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value, out int a) ? a : 0;
            var expirationDate = token.ValidTo;

            if (uid > 0 && expirationDate > DateTime.Now)
            {
                var Sqlstr = "EXEC ListWorkflow @WFId, @UId";
                SqlParameter parameterS = new SqlParameter("@WFId", wfid);
                SqlParameter parameterD = new SqlParameter("@UId", uid);
                var users = await _context.ListWorkflow.FromSqlRaw(Sqlstr, parameterS, parameterD).ToListAsync();
                return Ok(users);
            }
            return null;
        }        
    }
}