using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuickOnline.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace LearnQuickOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        LearnQuickOnlineContext context = new LearnQuickOnlineContext();

        // GET api/values
        [HttpGet]
        public List<User> Get()
        {
            try{
                var tt =  context.Users.CountDocuments<User>(user => true);
                context.Users.InsertOne(new User{ Username = "test_user" , Password = "niewuewib" });

                return context.Users.Find<User>(user => true).ToList();
            }catch(Exception ex){
                var t = ex;
                return null;   
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
