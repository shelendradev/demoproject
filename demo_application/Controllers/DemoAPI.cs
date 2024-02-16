using demo_application.Models;
using DemoBAL.interfaces;
using DemoDAL.Interfaces;
using DemoDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo_application.Controllers
{
    [Route("demo")]
    public class DemoAPI : Controller
    {

        private readonly IDemoAPIBAL _demoApiBal;
        public DemoAPI(IDemoAPIBAL demoAPIDAL)
        {
            _demoApiBal = demoAPIDAL;
        }

        [HttpGet]
        [Route("/demo")]
        public async Task<IActionResult> GetUsers()
        {

            try {
                List<UserModel> users = await _demoApiBal.GetAllUsers();

                return Ok(users);
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Route("createuser")]
        [HttpPost]
        public async Task<IActionResult> SetUser([FromBody] UserModel userModel)
        {
            try {
                Console.Write($"roleid {userModel.RoleID},lastname {userModel.LastName},firstname {userModel.FirstName}");
                
                await _demoApiBal.CreateUser(userModel);
                
                return Ok("Created");
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message); 
                return BadRequest(ex.Message);
            }
        }
    }
}
