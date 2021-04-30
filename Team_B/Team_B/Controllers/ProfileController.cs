using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team_B.DbModels;

namespace Team_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private EmployeeDBContext _context;

        public ProfileController(EmployeeDBContext context)
        {
            _context = context;
        }
        // GET: api/Profile
        [HttpGet]
        public ActionResult GetAllEmp()
        {
            var emplist = _context.ProfileData.ToList();
            return Ok(emplist);
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            var emp = _context.ProfileData.Where(x => x.EmpId == id);
            return Ok(emp);
        }


        // POST: api/Profile
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
