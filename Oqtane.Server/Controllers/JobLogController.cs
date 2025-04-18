using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Oqtane.Models;
using Oqtane.Shared;
using Oqtane.Repository;

namespace Oqtane.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class JobLogController : Controller
    {
        private readonly IJobLogRepository _jobLogs;

        public JobLogController(IJobLogRepository jobLogs)
        {
            _jobLogs = jobLogs;
        }

        // GET: api/<controller>?jobid=x
        [HttpGet]
        [Authorize(Roles = RoleNames.Host)]
        public IEnumerable<JobLog> Get(string jobid)
        {
            return _jobLogs.GetJobLogs(int.Parse(jobid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Roles = RoleNames.Host)]
        public JobLog Get(int id)
        {
            return _jobLogs.GetJobLog(id);
        }
    }
}
