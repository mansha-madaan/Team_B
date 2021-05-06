using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewManagementSystem.DbModels;

namespace ReviewManagementSystem.Controllers
{
    [Authorize]
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




    }
}