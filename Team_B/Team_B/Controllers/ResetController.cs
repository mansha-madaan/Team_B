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
    public class ResetController : ControllerBase
    {
    private EmployeeDBContext _context;
    private IConfiguration _config;

    public ResetController(IConfiguration config, EmployeeDBContext context)
    {
        _context = context;
        _config = config;
    }

    [HttpPut]
    public string ResetPassword([FromBody] EmpLoginRequest empLoginRequest)
        {
            //need a new db with time limit 
            // new route to validate that otp sent from smtp
            // cross check password from ui and backend
            return "password changed";
        }

    }
}