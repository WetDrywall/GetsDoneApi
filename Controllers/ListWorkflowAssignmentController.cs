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
    public class ListWorkflowAssignmentController : ControllerBase
    {
        private readonly ListWorkflowAssignmentContext _context;
        public ListWorkflowAssignmentController(ListWorkflowAssignmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int wfid, int uid)
        {
            var Sqlstr = "EXEC ListWorkflowAssignment @WFId, @UId";
            SqlParameter parameterS = new SqlParameter("@WFId", wfid);
            SqlParameter parameterD = new SqlParameter("@UId", uid);
            var users = await _context.ListWorkflowAssignment.FromSqlRaw(Sqlstr, parameterS, parameterD).ToListAsync();
            return Ok(users);
        }        
    }
}