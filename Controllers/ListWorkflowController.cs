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
    public class ListWorkflowController : ControllerBase
    {
        private readonly ListWorkflowContext _context;
        public ListWorkflowController(ListWorkflowContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int wfid, int uid)
        {
            var Sqlstr = "EXEC ListWorkflow @WFId, @UId";
            SqlParameter parameterS = new SqlParameter("@WFId", wfid);
            SqlParameter parameterD = new SqlParameter("@UId", uid);
            var users = await _context.ListWorkflow.FromSqlRaw(Sqlstr, parameterS, parameterD).ToListAsync();
            return Ok(users);
        }        
    }
}