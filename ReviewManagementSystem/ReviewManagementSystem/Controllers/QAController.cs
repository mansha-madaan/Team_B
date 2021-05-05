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
    
    [Route("api/[controller]")]
    [ApiController]
    public class QAController : ControllerBase
    {
        private EmployeeDBContext _context;
        private IConfiguration _config;

        public QAController(IConfiguration config, EmployeeDBContext context)
        {
            _context = context;
            _config = config;
        }



        // GET: api/Qar/5
        [HttpGet("{id}")]
        public IActionResult QarGet(int id)
        {

            var XProfile = _context.ProfileData.FirstOrDefault(R => R.EmpId == id);
            var name = XProfile.FirstName;
            var ReviewList = _context.Review.Where(r => r.QaName == name);

            return Ok(ReviewList);
        }



        // PUT: api/Qar/5
        [HttpPut("{id}")]
        public IActionResult edit(int id, [FromBody] ReviewRequest reviewRequest)
        {
            Review XReview = _context.Review.FirstOrDefault(R => R.Rid == id);
            XReview.Rstatus = "Closed";

            XReview.RqEffect = reviewRequest.RqEffect;
            XReview.RqEffectStatus = reviewRequest.RqEffectStatus;
            XReview.RqLead = reviewRequest.RqLead;
            XReview.RqLeadStatus = reviewRequest.RqLeadStatus;
            XReview.RqFeed = reviewRequest.RqFeed;
            XReview.RqFeedStatus = reviewRequest.RqFeedStatus;
            XReview.RqGrowth = reviewRequest.RqGrowth;
            XReview.RqGrowthStatus = reviewRequest.RqGrowthStatus;
            _context.Review.Update(XReview);
            _context.SaveChanges();
            return Ok(id);
        }
    }
}