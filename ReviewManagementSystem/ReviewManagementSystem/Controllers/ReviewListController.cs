using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReviewManagementSystem.DbModels;

namespace ReviewManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewListController : ControllerBase
    {
        private EmployeeDBContext _context;
        private IConfiguration _config;

        public ReviewListController(IConfiguration config, EmployeeDBContext context)
        {
            _context = context;
            _config = config;
        }


        // GET: api/ReviewList/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var XReview = _context.Review.FirstOrDefault(r => r.Rid == id);

            return Ok(XReview);
        }

        // POST: api/ReviewList

    }
}
