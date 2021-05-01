using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Team_B.DbModels;

namespace Team_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private employeeDBContext _context;
        private IConfiguration _config;

        public AdminController(IConfiguration config, employeeDBContext context)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Admin
        [HttpGet]
        public IActionResult AdminGet()
        {
            var reviewList = _context.Review.ToList();
            return Ok(reviewList);
        }

        /*  // GET: api/Admin/5
          [HttpGet("{id}", Name = "Get")]
          public string Get(int id)
          {
              return "value";
          }*/

        // POST: api/Admin
        [HttpPost]
        public IActionResult Post([FromBody] ReviewInfo reviewInfo)
        {
            reviewInfo.Status = "Initiate";

            var empList = _context.EmpLogin.ToList();

            for (int i = 0; i < empList.Capacity; i++)
            {
                Review XReview = new Review();
                XReview.EmpId = empList[i].EmpId;
                XReview.Status = reviewInfo.Status;
                _context.Review.Add(XReview);
                _context.SaveChanges();

            }
            return Ok("added User");
        }

    }
}
