using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuickOnline.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace LearnQuickOnline.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase {
        LearnQuickOnlineContext context = new LearnQuickOnlineContext ();

        // GET api/values
        [HttpGet]
        public List<Topic> Get () {
            return null;
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}