using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TeamB_Final.DbModels;

namespace TeamB_Final.Controllers
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
        // GET: api/Self
        [HttpGet]
        public IActionResult ListOfAllReviewsAdmin()
        {
            var reviewList = _context.Review.ToList();
            return Ok(reviewList);
        }
        // GET: api/Admin
        /* [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }

         // GET: api/Admin/5
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

        // PUT: api/Admin/5
        /* [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }

         // DELETE: api/ApiWithActions/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
}
