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
    public class QarController : ControllerBase
    {
        private employeeDBContext _context;
        private IConfiguration _config;

        public QarController(IConfiguration config, employeeDBContext context)
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
            var ReviewList = _context.Review.Where(r => r.QaName == name && r.Status == "Reviewer Level");

            return Ok(ReviewList);
        }



        // PUT: api/Qar/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReviewInfo TempReview)
        {
            Review XReview = _context.Review.FirstOrDefault(R => R.Rid == id);
            XReview.Status = "Closed";

            XReview.RqEffect = TempReview.RqEffect;
            XReview.RqEffectStatus = TempReview.RqEffectStatus;
            XReview.RqLead = TempReview.RqLead;
            XReview.RqLeadStatus = TempReview.RqLeadStatus;
            XReview.RqFeed = TempReview.RqFeed;
            XReview.RqFeedStatus = TempReview.RqFeedStatus;
            XReview.RqGrowth = TempReview.RqGrowth;
            XReview.RqGrowthStatus = TempReview.RqGrowthStatus;
            _context.Review.Update(XReview);
            _context.SaveChanges();
            return Ok(id);
        }

    }
}
