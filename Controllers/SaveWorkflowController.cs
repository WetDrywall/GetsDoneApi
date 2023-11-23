using GetsDoneApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Get(int wfid, string title, string desc, int wOwner, string wUser, DateTime? deadline)
        {
            var Sqlstr = "EXEC SaveWorkflow @WFId, @Title, @Description, @WOwner, @WUser, @Deadline";
            SqlParameter parameterS = new SqlParameter("@WFId", wfid.ToString());
            SqlParameter parameterD = new SqlParameter("@Title", title != null ? title : "");
            SqlParameter parameterP = new SqlParameter("@Description", desc != null ? desc : "");
            SqlParameter parameterK = new SqlParameter("@WOwner", wOwner.ToString());
            SqlParameter parameterL = new SqlParameter("@WUser", wUser != null ? wUser : "");
            SqlParameter parameterJ = new SqlParameter("@Deadline", deadline != null ? deadline : DBNull.Value);
            var users = await _context.SaveWorkflow.FromSqlRaw(Sqlstr, parameterS, parameterD, parameterP, parameterK, parameterL, parameterJ).ToListAsync();
            return Ok(users);
        }
    }
}