using System.Linq;
using System.Threading.Tasks;
using Amoozeshyar.Database;
using Amoozeshyar.Models.Requests;
using Amoozeshyar.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Amoozeshyar.Controllers
{
    public class AuthenticationContoller : Controller
    {
        private readonly AmoozeshyarDB _db;

        public AuthenticationContoller(AmoozeshyarDB db){
            this._db = db;
        }
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest){
            
            var result = _db.Interns.FirstOrDefault(m=>m.Mobile==loginRequest.Mobile && m.Password==loginRequest.Password);
            if(result!=null){
                 return Ok(new LoginResponse{
                  IsAuthenticated= true, 
                  Message ="با موفقیت وارد شدید"
            });

            }
            return Ok(new LoginResponse{
                IsAuthenticated= false , 
                Message ="نام کاربری یا کلمه ی عبور صحیح نمی باشد"
            });
        }
    }
}