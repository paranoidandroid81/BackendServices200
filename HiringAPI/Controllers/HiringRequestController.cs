using HiringAPI.Models;
using HiringAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringAPI.Controllers
{
    public class HiringRequestController : ControllerBase
    {
        private readonly IHireEmployees _employeeHiringService;

        public HiringRequestController(IHireEmployees employeeHiringService)
        {
            _employeeHiringService = employeeHiringService;
        }

        [HttpPost("hiring-requests")]
        public async Task<ActionResult> AddHiringRequest([FromBody] PostHiringRequest request)
        {
            // Validate - if bad, return 400
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Save it (for us, to DB)
            // Return a response
            //    201 Created
            //    Location of URL of new thing
            //    Send them copy of it
            GetHiringResponse response = await _employeeHiringService.HireAsync(request);
            return Ok(response);
        }
    }
}
