using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReviewManagementSystem.DbModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace ReviewManagementSystem.Controllers
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

        [Route("[action]")]
        [HttpPost]
        public ActionResult Signup([FromBody] EmpLoginRequest empLoginRequest)
        {
            var encrypPassword = EncodePasswordToBase64(empLoginRequest.EmpPassword);
            EmpLogin empLogin = new EmpLogin()
            {
                EmpEmailId = empLoginRequest.EmpEmailId,
                EmpPassword = encrypPassword

            };
            _context.EmpLogin.Add(empLogin);
            _context.SaveChanges();
            return Ok("Emp Added");
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
                response = Ok(new { token = tokenString, empId = emp.EmpId});
            }


            return response;
        }

        [HttpGet]
        public ActionResult GetLoginFeed()
        {
            //var columns = _context.EmpLogin.Select(n => new {
            //        n.EmpEmailId
            //    });
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
            if(authUser != null)
            {
                EmpLoginRequest user = null;


                var encrypPassword = EncodePasswordToBase64(empLoginRequest.EmpPassword);

                //Boolean ismatched = VerifyPassword()
                if (empLoginRequest.EmpEmailId == authUser.EmpEmailId && encrypPassword == authUser.EmpPassword)
                {
                    user = new EmpLoginRequest { EmpEmailId = empLoginRequest.EmpEmailId, EmpId = authUser.EmpId };
                }
                return user;
            }
            return null;
            
        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        } //this function Convert to Decord your Password
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}