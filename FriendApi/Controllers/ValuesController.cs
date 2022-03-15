using FriendApi.DataAccess;
using FriendApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        FriendDA friendDA=null;
        public FriendController()
        {
            friendDA = new FriendDA();
        }

        [HttpPost("")]
        public IActionResult Insert([FromBody] Friend friend)
        {
            Friend friend1 = new Friend();
            friend1 = friendDA.Insert(friend);
            return Ok(friend);
        }

        [HttpGet("")]
        public IActionResult Get(int id)
        {
            Friend friend1 = new Friend();
            friend1 = friendDA.Get(id);
            return Ok(friend1);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            
            friendDA.Delete(id);
            return Ok();
        }
    }
}
