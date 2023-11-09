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
    public class SaveWorkflowAssignmentController : ControllerBase
    {
        private readonly SaveWorkflowAssignmentContext _context;
        public SaveWorkflowAssignmentController(SaveWorkflowAssignmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int wfid, string title, string desc, int assignmentNumber, bool completed)
        {
            var Sqlstr = "EXEC SaveWorkflowAssignment @WFId, @Title, @Description, @WOwner, @WUser";
            SqlParameter parameterS = new SqlParameter("@WFId", wfid.ToString());
            SqlParameter parameterD = new SqlParameter("@Title", title != null ? title : "");
            SqlParameter parameterP = new SqlParameter("@Description", desc != null ? desc : "");
            SqlParameter parameterK = new SqlParameter("@WOwner", assignmentNumber);
            SqlParameter parameterL = new SqlParameter("@WUser", completed);
            var users = await _context.SaveWorkflowAssignment.FromSqlRaw(Sqlstr, parameterS, parameterD, parameterP, parameterK, parameterL).ToListAsync();
            return Ok(users);
        }
    }
}