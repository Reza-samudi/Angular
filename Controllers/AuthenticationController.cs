using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Amoozeshyar.Database;
using Amoozeshyar.Models.Requests;
using Amoozeshyar.Models.Responses;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Amoozeshyar.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly AmoozeshyarDB _db;

        public AuthenticationController(AmoozeshyarDB db){
            this._db = db;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest){

            var intern=_db.Interns.FirstOrDefault(m=>m.Mobile==loginRequest.Mobile);
                if(intern==null) 
                {
                    return Ok(new LoginResponse{
                        IsAuthenticated= false , 
                        Message ="نام کاربری یا کلمه ی عبور صحیح نمی باشد"
                });
                }

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: loginRequest.Password,
                    salt: intern.Salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));
                if(hashed==intern.Password){
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("fgdbdaxzcvDSG@!#%cgbfdfghsdbg");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[] { 
                            new Claim("Mobile", intern.Mobile.ToString()) 
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    return Ok(new LoginResponse{
                    IsAuthenticated= true, 
                    Message ="با موفقیت وارد شدید",
                    Token=tokenHandler.WriteToken(token),
                    Role="Intern"
                });
            }
            return Ok(new LoginResponse{
                IsAuthenticated= false, 
                 Message ="نام کاربری یا کلمه ی عبور صحیح نمی باشد"
             });
            

            }
        
        }
    }
