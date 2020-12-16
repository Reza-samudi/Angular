using System;
using System.Linq;
using System.Threading.Tasks;
using Amoozeshyar.Database;
using Amoozeshyar.Models.Requests;
using Amoozeshyar.Models.Responses;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

                    return Ok(new LoginResponse{
                    IsAuthenticated= true, 
                    Message ="با موفقیت وارد شدید"
                });
            }
            return Ok(new LoginResponse{
                IsAuthenticated= false, 
                 Message ="نام کاربری یا کلمه ی عبور صحیح نمی باشد"
             });
            

            }
        
        }
    }
