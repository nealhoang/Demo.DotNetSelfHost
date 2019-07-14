using Microsoft.AspNetCore.Mvc;

namespace DotNetSelfHost.WinForms.Controllers
{
    [Route("/hello")]
    public class GreetingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var name = Program.Form.NameText;
            var greeting = "Hello " + name;
            return new JsonResult(greeting);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EventInfo eventInfo)
        {
            Program.Form.NameText = eventInfo.User.Name;
            return CreatedAtAction(nameof(Get), eventInfo.User.Name);
        }
    }

    public class EventInfo
    {
        public string Event { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
