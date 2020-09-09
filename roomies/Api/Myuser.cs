using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using roomies.Models;
using roomies.Models.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace roomies.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class Myuser : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public Myuser(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        // GET: api/<Myuser>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new List<User> { userRepository.GetUser(1)  };
        }

        // GET api/<Myuser>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Myuser>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<Myuser>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Myuser>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
