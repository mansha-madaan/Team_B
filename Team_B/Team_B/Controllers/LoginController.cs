using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Team_B.DbModels;

namespace Team_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private EmployeeDBContext _context;
        private IConfiguration _config;

        public LoginController(IConfiguration config, EmployeeDBContext context)
        {
            _context = context;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody]EmpLoginRequest empLoginRequest)
        {
            ActionResult response = Unauthorized();
            var emp = AuthenticateUser(empLoginRequest);
            if (emp != null)
            {
                var tokenString = GenerateJSONWebToken(empLoginRequest);
                response = Ok(new { token = tokenString });
            }


            return response;
        }

        [HttpGet]
        public ActionResult GetLoginFeed()
        {
            var empList = _context.EmpLogin.ToList();
            return Ok(empList);
        }

        private string GenerateJSONWebToken(EmpLoginRequest empLoginRequest)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private EmpLoginRequest AuthenticateUser(EmpLoginRequest empLoginRequest)
        {
            var authUser = _context.EmpLogin.FirstOrDefault(empInfo => empInfo.EmpEmailId == empLoginRequest.EmpEmailId);
            EmpLoginRequest user = null;

           


            //Boolean ismatched = VerifyPassword()
            if (empLoginRequest.EmpEmailId == authUser.EmpEmailId && empLoginRequest.EmpPassword == authUser.EmpPassword)
            {
                user = new EmpLoginRequest { EmpEmailId = empLoginRequest.EmpEmailId };
            }
            return user;
        }
    }
}